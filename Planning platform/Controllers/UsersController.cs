using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Planning_platform.Data;
using Planning_platform.Entities;
using Planning_platform.Models;
using System.Security.Cryptography.X509Certificates;

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

        [Authorize(Roles = "moderator")]

        public async Task<IActionResult> Index() 
        {
            var users = _userManager.Users.ToList();
            var tempUsers = new List<ApplicationUser>(users);
            foreach (var user in tempUsers)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                if (!userRoles.Contains("student"))
                {
                    users.Remove(user);
                }
            }
            ViewData["Classses"] = _context.Classes.ToList();
            return View(users);
                }




        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        //// GET: UserController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: UserController/Details/5
        [Authorize(Roles = "moderator")]

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
        [Authorize(Roles = "moderator")]

        public async Task<IActionResult> Edit(string userId)
        {
            // получаем пользователя
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userClass = user.ClassId;
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
        [Authorize(Roles = "moderator")]

        public async Task<IActionResult> Edit(string userId, List<int> classes)
        {
            
            // получаем пользователя
            var user = await _context.Users
                    .FirstOrDefaultAsync(m => m.Id == userId);

            //ApplicationUser user = await _userManager.FindByIdAsync(userId).Include(l => l.Class);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                int k = classes[0];
                user.ClassId = classes[0];
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
        [Authorize(Roles = "moderator")]

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "moderator")]

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

        [Authorize(Roles = "moderator")]
        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
       

    }
}
