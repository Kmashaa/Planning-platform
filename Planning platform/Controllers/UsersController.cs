using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Planning_platform.Data;
using Planning_platform.Entities;
using Planning_platform.Models;

namespace Planning_platform.Controllers
{
    public class UsersController : Controller
    {

        public ApplicationDbContext _context;

        UserManager<ApplicationUser> _userManager;
        public UsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;

        }

        public IActionResult Index() => View(_userManager.Users.ToList());




        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        //// GET: UserController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //// GET: UserController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: UserController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(string userId)
        {
            // получаем пользователя
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userClass = user.Class_id;
                var allClasses = await _context.Classes.ToListAsync();
                // получем список ролей пользователя
               // var userRoles = await _userManager.GetRolesAsync(user);
                //var allRoles = _roleManager.Roles.ToList();
                ChangeClassModel model = new ChangeClassModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserClasses = userClass,
                    AllClasses = allClasses
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<int> classes)
        {
            // получаем пользователя
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                int k = classes[0];
                user.Class_id = classes[0];
                // user.Class_id = (int)classes[0];
                // получаем все роли
                //var allRoles = _roleManager.Roles.ToList();
                //// получаем список ролей, которые были добавлены
                //var addedRoles = roles.Except(userRoles);
                //// получаем роли, которые были удалены
                //var removedRoles = userRoles.Except(roles);

                //await _userManager.AddToRolesAsync(user, addedRoles);

                //await _userManager.RemoveFromRolesAsync(user, removedRoles);
                _context.Update(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return NotFound();
        }

       
        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
