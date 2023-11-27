using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using NUnit.Framework;
using Planning_platform.Controllers;
using Planning_platform.Entities;
using Moq;
using Microsoft.CodeAnalysis.Host.Mef;
using Planning_platform.Data;


namespace TestProject1
{
    [TestFixture]
    public class TestAnnouncement
    {

        //public void IndexReturnsAViewResultWithAListOfUsers()
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();
        //    var controller = new AnnouncementsController();
        //}
        //private List<Announcement> GetTestAnnouncements()
        //{
        //    DateTime date1 = new DateTime(2015, 7, 20);
        //    var announcements = new List<Announcement>
        //    {
        //        new Announcement { Id=1, Text="Tom", Date=date1, Moderator_id=1}

        //    };
        //    return announcements;
        //}
        //[SetUp]
        //public void Setup()
        //{
        //}

        //[Test]
        //public void Test1()
        //{
        //    Assert.AreEqual(1,1);
        //}

        [Test]
        public void Test2()
        {
            Assert.AreEqual(1, 1);
        }
    }
}