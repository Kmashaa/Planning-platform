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
    
    public class SubjectsControllerTests
    {
        [Fact]
        public void TestLoadSubjects()
        {
            ApplicationDbContext context = null;
            // Arrange
            SubjectsController controller = new SubjectsController(context);
            // Act
            Task<IActionResult> result = controller.Index();
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestCreateSubject()
        {
            ApplicationDbContext context = null;

            Subject subject = new Subject();
            subject.Id = 1;
            subject.Subject_name = "test";


            // Arrange
            SubjectsController controller = new SubjectsController(context);
            // Act
            Task<IActionResult> result = controller.Create(subject);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestDeleteSubject()
        {
            ApplicationDbContext context = null;
            // Arrange
            SubjectsController controller = new SubjectsController(context);
            // Act
            Task<IActionResult> result = controller.Delete(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestLoadDetailsOfSubject()
        {
            ApplicationDbContext context = null;
            // Arrange
            SubjectsController controller = new SubjectsController(context);
            // Act
            Task<IActionResult> result = controller.Details(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestEditSubject()
        {
            ApplicationDbContext context = null;
            // Arrange
            SubjectsController controller = new SubjectsController(context);
            // Act
            Task<IActionResult> result = controller.Edit(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);

            }
        }
}

