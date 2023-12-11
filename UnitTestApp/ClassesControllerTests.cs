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
    
    public class ClassesControllerTests
    {
        [Fact]
        public void TestLoadClasses()
        {
            ApplicationDbContext context = null;
            // Arrange
            ClassesController controller = new ClassesController(context);
            // Act
            Task<IActionResult> result = controller.Index();
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestCreateClass()
        {
            ApplicationDbContext context = null;

            Class clas = new Class();
            clas.Letter_of_class = 'A';
            clas.Num_of_class = 5;
            clas.Id = 1;

            // Arrange
            ClassesController controller = new ClassesController(context);
            // Act
            Task<IActionResult> result = controller.Create(clas);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestDeleteClass()
        {
            ApplicationDbContext context = null;
            // Arrange
            ClassesController controller = new ClassesController(context);
            // Act
            Task<IActionResult> result = controller.Delete(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestLoadDetailsOfClass()
        {
            ApplicationDbContext context = null;
            // Arrange
            ClassesController controller = new ClassesController(context);
            // Act
            Task<IActionResult> result = controller.Details(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestEditClass()
        {
            ApplicationDbContext context = null;
            // Arrange
            ClassesController controller = new ClassesController(context);
            // Act
            Task<IActionResult> result = controller.Edit(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);

        }
    }
}

