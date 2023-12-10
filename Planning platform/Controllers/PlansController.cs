using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Excel;
using Planning_platform.Data;
using Planning_platform.Entities;
using Planning_platform.Migrations;

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
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Plans.Include(p => p.Lesson);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Plans/Details/5
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
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var lessons =  _context.Lessons.Include(p=>p.Subject).Include(p=>p.Class).ToList().Where(p => p.ClassId == user.ClassId);
                int lessonscounter = 0;
                var cell = worksheet.Cells[3, 3].Value;

                //while (true)
                //{
                //}
                for (int i = 3; i < rows; i++)
                {

                    // Перебрать каждый столбец в выбранной строке
                    for (int j = 0; j < cols; j++)
                    {
                        // Значение ячейки Pring
                        Console.Write(worksheet.Cells[i, j].Value + " | ");
                    }
                    // Распечатать разрыв строки
                    Console.WriteLine(" ");
                }
            }

                wb.Save("C:\\Users\\user\\Desktop\\output.pdf", Aspose.Cells.SaveFormat.Pdf);

            // Получить рабочий лист, используя его индекс
            //Worksheet worksheet = wb.Worksheets[0];

            //ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id");
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        private bool PlanExists(int id)
        {
          return (_context.Plans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
