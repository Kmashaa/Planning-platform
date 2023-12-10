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

namespace UnitTestApp
{
    
    public class PlansControllerTests
    {
       [Fact]
        public void TestLoadPlans()
        {
            ApplicationDbContext context=null;
            // Arrange
            ReviewsController controller = new ReviewsController(context);
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

            Review review = new Review();
            review.Student_id = 1;
            review.Teacher_id = 2;
            review.Date = DateTime.Now;
            review.Text = "Test";



            // Arrange
            ReviewsController controller = new ReviewsController(context);
            // Act
            Task<IActionResult> result = controller.Create(review);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestDeletePlan()
        {
            ApplicationDbContext context = null;
            // Arrange
            ReviewsController controller = new ReviewsController(context);
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
            // Arrange
            ReviewsController controller = new ReviewsController(context);
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
            // Arrange
            ReviewsController controller = new ReviewsController(context);
            // Act
            Task<IActionResult> result = controller.Edit(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);

        }

    }
}

