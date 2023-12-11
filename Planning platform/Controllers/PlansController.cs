using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Excel;
using NuGet.Versioning;
using Planning_platform.Data;
using Planning_platform.Entities;
using Planning_platform.Models;

using Planning_platform.Migrations;
using System.Linq;
using System.Numerics;
using Microsoft.AspNetCore.Authorization;

namespace Planning_platform.Controllers
{
    public class PlansController : Controller
    {
        private readonly ApplicationDbContext _context;
        RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUser> _userManager;
        public PlansController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: Plans
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var applicationDbContext = _context.Plans.Include(p => p.Lesson).Where(l=>l.Lesson.Teacher.Id==user.Id);

            

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Plans/Details/5
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plans == null)
            {
                return NotFound();
            }

            var plan = await _context.Plans
                .Include(p => p.Lesson)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // GET: Plans/Create
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> Create()
        {
            // Загрузить файл Excel
            var wb = new Aspose.Cells.Workbook("C:\\Users\\user\\Desktop\\математика 7 класс.xlsx");
            var collection = wb.Worksheets;
            for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
            {
                var worksheet = collection[worksheetIndex];
                int rows = worksheet.Cells.MaxDataRow;
                int cols = worksheet.Cells.MaxDataColumn;
                List<Plan> plans = new List<Plan>();
                List<Homework> homeworks = new List<Homework>();

                var user = await _userManager.GetUserAsync(HttpContext.User);
                List<Lesson> lessons = _context.Lessons.Include(p => p.Subject).Include(p => p.Class).ToList().Where(p => p.ClassId == 1004).Where(p=>p.SubjectId==1).ToList();
                int allLessonsCounter = 0;
                var i = 3;
                //var j = 3;
                int maxLessonsCounter = (int)worksheet.Cells[rows, 0].Value;
                List<int> hours = new List<int>();
                //DateTime dateValue = new DateTime(2023, 9, 1);
                //int lessonsCounterForDate = 0;
                List<DateTime> dates = new List<DateTime>();
                DateTime firstDay = new DateTime(2023, 9, 1);
                var dayOfWeek = (int)firstDay.DayOfWeek;//1,2,3,4,5
                //while (dayOfWeek > 5||dayOfWeek==0)
                //{
                //    firstDay=firstDay.AddDays(1);
                //    dayOfWeek = (int)firstDay.DayOfWeek;//1,2,3,4,5
                //}
                ////var currLesson = lessons[dayOfWeek - 1];

                //firstDay = firstDay.AddDays(1);

                //lessonsCounterpozitionForDays
                //plan.LessonId = lessons[pozition].Id;


                //Console.WriteLine(dateValue.ToString("dddd"));
                int chapter =0;
                int lessonsCounter = dayOfWeek - 1;
                while (true)
                {
                    var cell = worksheet.Cells[i, 3].Value;
                    
                    if (cell == null)
                    {
                        i++;
                        continue;
                    }
                    var homeworkReaded = worksheet.Cells[i, 6].Value;
                    var strHomework = (string)homeworkReaded;
                    var hoursValue = (int)cell;

                    hours.Add(hoursValue);
                    i += hoursValue;

                    allLessonsCounter += hoursValue;
                    try
                    {
                        var firstNumstr = strHomework.Substring(strHomework.IndexOf('№') + 1, strHomework.IndexOf('-') - 1);
                        chapter = Int32.Parse(firstNumstr.Substring(0, firstNumstr.IndexOf('.')));
                        int firstNum = Int32.Parse(firstNumstr.Substring(firstNumstr.IndexOf('.') + 1));

                        var lastNumstr = strHomework.Substring(strHomework.IndexOf('-') + 1);
                        int lastNum = Int32.Parse(lastNumstr.Substring(lastNumstr.IndexOf('.') + 1));

                        int step = (lastNum - firstNum) / hoursValue;

                        int firstNumOfHomework = firstNum;
                        while (firstNumOfHomework <= lastNum - step - step)
                        {
                            if(firstDay>=new DateTime(2023,10,29)&& firstDay <= new DateTime(2023, 11, 7))
                            {
                                firstDay = new DateTime(2023, 11, 8);
                            }

                            dayOfWeek = (int)firstDay.DayOfWeek;//1,2,3,4,5

                            while (dayOfWeek > 5 || dayOfWeek == 0)
                            {
                                firstDay = firstDay.AddDays(1);
                                dayOfWeek = (int)firstDay.DayOfWeek;//1,2,3,4,5
                            }
                            //var currLesson = lessons[dayOfWeek - 1];
                            if (firstDay >= new DateTime(2023, 10, 29) && firstDay <= new DateTime(2023, 11, 7))
                            {
                                firstDay = new DateTime(2023, 11, 8);
                            }

                            dayOfWeek = (int)firstDay.DayOfWeek;//1,2,3,4,5

                            Plan plan = new Plan();
                            int pozition = (dayOfWeek-1) % lessons.Count;
                            lessonsCounter++;
                            plan.LessonId = lessons[pozition].Id;
                            plan.Date = firstDay;//new DateTime(2023, 9, 1);
                            firstDay = firstDay.AddDays(1);

                            _context.Add(plan);
                            await _context.SaveChangesAsync();
                            var planId= _context.Plans.ToList()[_context.Plans.ToList().Count-1].Id;

                            Homework homework = new Homework();
                            string homeworkString = "№" + chapter.ToString() + '.' + firstNumOfHomework.ToString() + " - " + chapter.ToString() + '.' + (firstNumOfHomework + step - 1).ToString();
                            homework.Text = homeworkString;
                            homework.PlanId = planId;
                            homeworks.Add(homework);
                            firstNumOfHomework += step;
                            _context.Add(homework);
                            await _context.SaveChangesAsync();



                            //firstNumOfHomework += 1;
                        }
                        if (firstDay >= new DateTime(2023, 10, 29) && firstDay <= new DateTime(2023, 11, 7))
                        {
                            firstDay = new DateTime(2023, 11, 8);
                        }
                        dayOfWeek = (int)firstDay.DayOfWeek;//1,2,3,4,5
                        while (dayOfWeek > 5 || dayOfWeek == 0)
                        {
                            firstDay = firstDay.AddDays(1);
                            dayOfWeek = (int)firstDay.DayOfWeek;//1,2,3,4,5
                        }
                        Plan planLast = new Plan();
                        int pozitionLast = (dayOfWeek - 1) % lessons.Count;
                        lessonsCounter++;
                        planLast.LessonId = lessons[pozitionLast].Id;
                        planLast.Date = firstDay;//new DateTime(2023, 9, 1);
                        firstDay = firstDay.AddDays(1);

                        firstDay = firstDay.AddDays(1);
                        _context.Add(planLast);
                        await _context.SaveChangesAsync();
                        var planIdLast = _context.Plans.ToList()[_context.Plans.ToList().Count - 1].Id;

                        Homework homeworkLast = new Homework();
                        string homeworkStr = "№" + chapter.ToString() + '.' + firstNumOfHomework.ToString() + " - " + chapter.ToString() + '.' + (lastNum).ToString();
                        homeworkLast.Text = homeworkStr;
                        homeworkLast.PlanId = planIdLast;
                        homeworks.Add(homeworkLast);
                        _context.Add(homeworkLast);
                        await _context.SaveChangesAsync();


                    }
                    catch
                    {
                        if (firstDay >= new DateTime(2023, 10, 29) && firstDay <= new DateTime(2023, 11, 7))
                        {
                            firstDay = new DateTime(2023, 11, 8);
                        }
                        dayOfWeek = (int)firstDay.DayOfWeek;//1,2,3,4,5
                        while (dayOfWeek > 5 || dayOfWeek == 0)
                        {
                            firstDay = firstDay.AddDays(1);
                            dayOfWeek = (int)firstDay.DayOfWeek;//1,2,3,4,5
                        }
                        Plan planLast = new Plan();
                        int pozitionLast = (dayOfWeek - 1) % lessons.Count;
                        lessonsCounter++;
                        planLast.LessonId = lessons[pozitionLast].Id;
                        planLast.Date = firstDay;//new DateTime(2023, 9, 1);
                        firstDay = firstDay.AddDays(1);
                        _context.Add(planLast);
                        await _context.SaveChangesAsync();
                        var planIdLast = _context.Plans.ToList()[_context.Plans.ToList().Count - 1].Id;

                        Homework homeworkLast = new Homework();
                        homeworkLast.PlanId = planIdLast;

                        if (strHomework == null)
                        {
                            homeworkLast.Text = "";
                        }
                        else
                        {
                            homeworkLast.Text = strHomework;
                        }
                        homeworks.Add(homeworkLast);
                        _context.Add(homeworkLast);
                        await _context.SaveChangesAsync();

                    }
                    if (allLessonsCounter == maxLessonsCounter)
                    {
                        break;
                    }
                }

            }
                wb.Save("C:\\Users\\user\\Desktop\\output.pdf", Aspose.Cells.SaveFormat.Pdf);

            // Получить рабочий лист, используя его индекс
            //Worksheet worksheet = wb.Worksheets[0];

            //ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id");
            return RedirectToAction("Index","Homeworks");
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> Create([Bind("Id,LessonId,Date")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", plan.LessonId);
            return View(plan);
        }

        // GET: Plans/Edit/5
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plans == null)
            {
                return NotFound();
            }

            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", plan.LessonId);
            return View(plan);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> Edit(int id, [Bind("Id,LessonId,Date")] Plan plan)
        {
            if (id != plan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanExists(plan.Id))
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
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", plan.LessonId);
            return View(plan);
        }

        // GET: Plans/Delete/5
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plans == null)
            {
                return NotFound();
            }

            var plan = await _context.Plans
                .Include(p => p.Lesson)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "teacher")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plans == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Plans'  is null.");
            }
            var plan = await _context.Plans.FindAsync(id);
            if (plan != null)
            {
                _context.Plans.Remove(plan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "teacher")]

        private bool PlanExists(int id)
        {
          return (_context.Plans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
