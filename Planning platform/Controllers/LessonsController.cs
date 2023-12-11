using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Planning_platform.Data;
using Planning_platform.Entities;
using Planning_platform.Models;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations.Schema;


namespace Planning_platform.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUser> _userManager;
        public LessonsController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {

            if (User.IsInRole("moderator"))
            {

                var applicationDbContext = _context.Lessons.Include(l => l.Class).Include(l => l.Subject);
                return View(await applicationDbContext.ToListAsync());
            }
            else if (User.IsInRole("teacher"))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                var applicationDbContext = _context.Lessons.Include(l => l.Class).Include(l => l.Subject);
                var lst = applicationDbContext.Where(p => p.Teacher.Id == user.Id).ToList();
                var orderedLessons = from p in lst orderby p.Number_on_day select p;

                return View(orderedLessons);

            }
            else if (User.IsInRole("student"))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var classid = user.ClassId;
                var homeworks = _context.Plans.Include(l => l.Homeworks).ToList();
                //var b = homeworks[0].Plan.Lesson.Id;
                //ApplicationUser student = ;
                //var userId = await _userManager.GetUserIdAsync(user);
                DateTime nowDate = new DateTime(2023, 9, 1);
                DateTime lastDate = nowDate.AddDays(7);
                var lessons = _context.Lessons.Include(l => l.Class).Include(l => l.Subject).Include(l => l.Plans).ToList().Where(p => p.ClassId == classid);
                foreach (var lesson in lessons)
                {
                    var tempPlans = new List<Plan>(lesson.Plans);
                    foreach (var plan in tempPlans)
                    {
                        if (plan.Date > lastDate)
                        {
                            lesson.Plans.Remove(plan);
                        }

                    }
                }

                var orderedLessons = from p in lessons orderby p.Day_of_week select p;

                return View(orderedLessons);

            }
            return View();
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lessons == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .Include(l => l.Class)
                .Include(l => l.Subject)
                .Include(l=>l.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }



        // GET: Lessons/Create
        public async Task<IActionResult> Create()
        {

            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "FullName");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Subject_name");
            List<ApplicationUser> users = _context.Users.ToList();
            List<ApplicationUser> teachers = new List<ApplicationUser>();
            foreach (var item in users)
            {
                var userRoles = await _userManager.GetRolesAsync(item);
                if (userRoles.Contains("teacher"))
                {
                    teachers.Add(item);

                }

            }
            ViewData["TeacherId"] = new SelectList(teachers, "Id", "FullName");

            //string roleName = "Admin";
            //var role = _roleManager.Roles.SingleAsync(r => r.Name == roleName);

            //var users = _userManager.Users.Where(u => u.Roles.Any(r => r.RoleId == role.Id));
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Day_of_week,Number_on_day,SubjectId,ClassId,TeacherId")] LessonModel lesson)
        {
            Class clas = _context.Classes.Find(lesson.ClassId);
            Subject subject = _context.Subjects.Find(lesson.SubjectId);
            lesson.Class = null;
            lesson.Subject = null;
            //lesson.Class = clas;
            //lesson.Subject = subject;
            Lesson leson = lesson;

            ApplicationUser teacher = _context.Users.Find(lesson.TeacherId);
            leson.Teacher = teacher;
            //lesson.Teacher = null;

            var a = ModelState;
            if (ModelState.IsValid)
            {
                _context.Add(leson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", lesson.ClassId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", lesson.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Users, "Id", "Id", lesson.TeacherId);

            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lessons == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", lesson.ClassId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", lesson.SubjectId);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Day_of_week,Number_on_day,SubjectId,ClassId,TeacherId")] Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", lesson.ClassId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", lesson.SubjectId);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lessons == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .Include(l => l.Class)
                .Include(l => l.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lessons == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lessons'  is null.");
            }
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson != null)
            {
                _context.Lessons.Remove(lesson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
          return (_context.Lessons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
