using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Planning_platform.Data;
using Planning_platform.Entities;
using Planning_platform.Migrations;

namespace Planning_platform.Controllers
{
    public class HomeworksController : Controller
    {
        private readonly ApplicationDbContext _context;
        RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUser> _userManager;
        public HomeworksController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: Homework
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> Index()
        {

            DateTime nowDate = new DateTime(2023, 9, 1);
            DateTime lastDate = nowDate.AddDays(7);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var lessons = _context.Lessons.Include(l => l.Class).Include(l => l.Subject).Include(l => l.Plans).Where(p => p.Teacher.Id==user.Id).ToList();
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
            var orderedLessons = from p in lessons orderby p.Number_on_day select p;


            var applicationDbContext = _context.Homeworks.Include(h => h.Plan);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Homework/Details/5
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Homeworks == null)
            {
                return NotFound();
            }

            var homework = await _context.Homeworks
                .Include(h => h.Plan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homework == null)
            {
                return NotFound();
            }

            return View(homework);
        }

        // GET: Homework/Create
        [Authorize(Roles = "teacher")]

        public IActionResult Create()
        {
            ViewData["PlanId"] = new SelectList(_context.Plans, "Id", "Id");
            return View();
        }

        // POST: Homework/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> Create([Bind("Id,PlanId,Text")] Homework homework)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homework);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlanId"] = new SelectList(_context.Plans, "Id", "Id", homework.PlanId);
            return View(homework);
        }

        // GET: Homework/Edit/5
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Homeworks == null)
            {
                return NotFound();
            }

            var homework = await _context.Homeworks.FindAsync(id);
            if (homework == null)
            {
                return NotFound();
            }
            ViewData["PlanId"] = new SelectList(_context.Plans, "Id", "Id", homework.PlanId);
            return View(homework);
        }

        // POST: Homework/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> Edit(int id, [Bind("Id,PlanId,Text")] Homework homework)
        {
            homework.Plan = null;
            if (id != homework.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homework);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeworkExists(homework.Id))
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
            ViewData["PlanId"] = new SelectList(_context.Plans, "Id", "Id", homework.PlanId);
            return View(homework);
        }

        // GET: Homework/Delete/5
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Homeworks == null)
            {
                return NotFound();
            }

            var homework = await _context.Homeworks
                .Include(h => h.Plan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homework == null)
            {
                return NotFound();
            }

            return View(homework);
        }

        // POST: Homework/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Homeworks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Homeworks'  is null.");
            }
            var homework = await _context.Homeworks.FindAsync(id);
            if (homework != null)
            {
                _context.Homeworks.Remove(homework);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "teacher")]

        private bool HomeworkExists(int id)
        {
          return (_context.Homeworks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
