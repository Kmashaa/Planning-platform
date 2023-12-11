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
    
    public class AnnouncementsControllerTests
    {
        [Fact]
        public void TestLoadAnnouncements()
        {
            ApplicationDbContext context = null;
            // Arrange
            AnnouncementsController controller = new AnnouncementsController(context);
            // Act
            Task<IActionResult> result = controller.Index();
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestCreateAnnouncement()
        {
            ApplicationDbContext context = null;

            Announcement announcement = new Announcement();
            announcement.Id = 1;
            announcement.Date = DateTime.Now;
            announcement.Text = "Test";
            // Arrange
            AnnouncementsController controller = new AnnouncementsController(context);
            // Act
            Task<IActionResult> result = controller.Create(announcement);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestDeleteAnnouncement()
        {
            ApplicationDbContext context = null;
            // Arrange
            AnnouncementsController controller = new AnnouncementsController(context);
            // Act
            Task<IActionResult> result = controller.Delete(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestLoadDetailsOfAnnouncement()
        {
            ApplicationDbContext context = null;
            // Arrange
            AnnouncementsController controller = new AnnouncementsController(context);
            // Act
            Task<IActionResult> result = controller.Details(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestEditAnnouncement()
        {
            ApplicationDbContext context = null;
            // Arrange
            AnnouncementsController controller = new AnnouncementsController(context);
            // Act
            Task<IActionResult> result = controller.Edit(1);
            //ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);

        }
    }
}

