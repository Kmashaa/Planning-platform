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
    
    public class PlansControllerTests
    {
        [Fact]
        public void TestLoadPlans()
        {
            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;
            // Arrange
            PlansController controller = new PlansController(context, _roleManager, _userManager);
            // Act
            Task<IActionResult> result = controller.Index();
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestCreatePlan()
        {
            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;

            Plan plan = new Plan();

            plan.Date = DateTime.Now;


            // Arrange
            PlansController controller = new PlansController(context, _roleManager, _userManager);
            // Act
            Task<IActionResult> result = controller.Create(plan);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestDeletePlan()
        {
            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;
            // Arrange
            PlansController controller = new PlansController(context, _roleManager, _userManager);
            // Act
            Task<IActionResult> result = controller.Delete(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestLoadDetailsOfPlan()
        {
            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;
            // Arrange
            PlansController controller = new PlansController(context, _roleManager, _userManager);
            // Act
            Task<IActionResult> result = controller.Details(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestEditPlan()
        {

            ApplicationDbContext context = null;
            RoleManager<IdentityRole> _roleManager = null;
            UserManager<ApplicationUser> _userManager = null;
            // Arrange
            PlansController controller = new PlansController(context, _roleManager, _userManager);
            // Act
            Task<IActionResult> result = controller.Edit(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);

        }

    }
}

