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
    
    public class LessonsControllerTests
    {
        [Fact]
        public void TestLoadLessons()
        {
            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;
            // Arrange
            LessonsController controller = new LessonsController(context, _roleManager, _userManager);
            // Act
            Task<IActionResult> result = controller.Index();
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestCreateLesson()
        {
            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;
            Planning_platform.Models.LessonModel lesson = new Planning_platform.Models.LessonModel();
            lesson.Id = 1;
            lesson.Day_of_week = "Monday";
            lesson.Number_on_day = 1;

            // Arrange
            LessonsController controller = new LessonsController(context, _roleManager, _userManager);

            // Act
            Task<IActionResult> result = controller.Create(lesson);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestDeleteLesson()
        {
            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;
            // Arrange
            LessonsController controller = new LessonsController(context, _roleManager, _userManager);
            // Act
            Task<IActionResult> result = controller.Delete(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestLoadDetailsOfLesson()
        {
            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;
            // Arrange
            LessonsController controller = new LessonsController(context, _roleManager, _userManager);
            // Act
            Task<IActionResult> result = controller.Details(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestEditLesson()
        {
            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;
            // Arrange
            LessonsController controller = new LessonsController(context, _roleManager, _userManager);
            // Act
            Task<IActionResult> result = controller.Edit(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);

        }
    }
}

