using Microsoft.AspNetCore.Mvc;
using Planning_platform.Controllers;
using Planning_platform.Data;
using Xunit;
using Moq;
using Planning_platform.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Planning_platform.Controllers;
using Planning_platform.Data;
using Planning_platform.Entities;
using Xunit;
using Microsoft.AspNetCore.Identity;

namespace UnitTestApp
{
    
    public class HomeworksControllerTests
    {
        [Fact]
        public void TestLoadHomeworks()
        {
            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;
            // Arrange
            HomeworksController controller = new HomeworksController(context, _roleManager, _userManager);
            // Act
            Task<IActionResult> result = controller.Index();
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestCreateHomework()
        {
            ApplicationDbContext context = null;

            Homework homework = new Homework();
            homework.Id = 1;
            homework.Text = "test";


            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;

            // Arrange
            HomeworksController controller = new HomeworksController(context, _roleManager, _userManager);
        // Act
        Task<IActionResult> result = controller.Create(homework);
        //ViewResult result = controller.Index() as ViewResult;
        // Assert
        Assert.NotNull(result);
         }

    [Fact]
        public void TestDeleteHomework()
        {
            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;
            // Arrange
            HomeworksController controller = new HomeworksController(context, _roleManager, _userManager);
            // Act
            Task<IActionResult> result = controller.Delete(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestLoadDetailsOfHomework()
        {
            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;
            // Arrange
            HomeworksController controller = new HomeworksController(context, _roleManager, _userManager);
            // Act
            Task<IActionResult> result = controller.Details(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestEditHomework()
        {
            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager=null;
            UserManager<ApplicationUser> _userManager=null;
            // Arrange
            HomeworksController controller = new HomeworksController(context, _roleManager, _userManager);
            // Act
            Task<IActionResult> result = controller.Edit(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);

        }
    }
}

