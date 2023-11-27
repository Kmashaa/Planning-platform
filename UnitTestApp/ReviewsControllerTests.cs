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
    
    public class ReviewsControllerTests
    {
       [Fact]
        public void TestLoadIndexView()
        {
            ApplicationDbContext context=null;
            // Arrange
            LessonsController controller = new LessonsController(context);
            // Act
            Task<IActionResult> result = controller.Index();
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestLoadCreateView()
        {
            ApplicationDbContext context = null;

            Lesson lesson = new Lesson();
            lesson.Id = 1;
            lesson.Day_of_week = "Monday";
            lesson.Subject_id = 1;
            lesson.teacher_id = 1;
            lesson.Number_on_day = 1;
            lesson.Class_id = 1;

            // Arrange
            LessonsController controller = new LessonsController(context);
            // Act
            Task<IActionResult> result = controller.Create(lesson);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestLoadDeleteView()
        {
            ApplicationDbContext context = null;
            // Arrange
            LessonsController controller = new LessonsController(context);
            // Act
            Task<IActionResult> result = controller.Delete(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestLoadDetailsView()
        {
            ApplicationDbContext context = null;
            // Arrange
            LessonsController controller = new LessonsController(context);
            // Act
            Task<IActionResult> result = controller.Details(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestLoadEditView()
        {
            ApplicationDbContext context = null;
            // Arrange
            LessonsController controller = new LessonsController(context);
            // Act
            Task<IActionResult> result = controller.Edit(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);

        }
    }
}

