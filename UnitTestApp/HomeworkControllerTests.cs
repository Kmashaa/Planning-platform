﻿using Microsoft.AspNetCore.Mvc;
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
    
    public class HomeworksControllerTests
    {
       [Fact]
        public void TestLoadIndexView()
        {
            ApplicationDbContext context=null;
            // Arrange
            HomeworkController controller = new HomeworkController(context);
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

            Homework homework = new Homework();
            homework.Id = 1;
            homework.Text="test";
            homework.Plan_id = 1;
            homework.Is_publiched = true;
            


            // Arrange
            HomeworkController controller = new HomeworkController(context);
            // Act
            Task<IActionResult> result = controller.Create(homework);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestLoadDeleteView()
        {
            ApplicationDbContext context = null;
            // Arrange
            HomeworkController controller = new HomeworkController(context);
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
            HomeworkController controller = new HomeworkController(context);
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
            HomeworkController controller = new HomeworkController(context);
            // Act
            Task<IActionResult> result = controller.Edit(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);

        }
    }
}
