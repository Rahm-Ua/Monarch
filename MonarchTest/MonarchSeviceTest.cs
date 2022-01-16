using MonarchBLL;
using MonarchDOL;
using MonarchDOL.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace MonarchTest
{
    [TestFixture]
    public class MonarchServiceTest
    {
        private BugService service;

        [SetUp]
        public void Setup()
        {
         //  service = new BugService();
        }

        [Test]
        public void TestAddBug()
        {
            var bug = new BugModel()
            {
                Id = 1000,
                LineNumber = 5001,
                Title = "nasty bug",
                Severity = 0,
                CategoryId = 1000,
                Description = "the worst",
                Status = 0,
                ResolutionId = 1002
            };
            int? result = service.AddBug(bug);
            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.Value, 1);
        }

        [Test]
        public void TestGetBug()
        {

            BugModel bug = service.GetBug(1001);
            Assert.IsNotNull(bug);
            Assert.IsTrue(bug.Title.Length > 0);
            Assert.IsTrue(bug.Severity > 0);

        }

        [Test]
        public void TestUpdateBug()
        {
            var bug1 = new BugModel()
            {
                LineNumber = 5001,
                Title = "nasty bug",
                Severity = 0,
                CategoryId = 1000,
                Description = "the worst",
                Status = 0,
                ResolutionId = 1002
            };
            int? Id = service.AddBug(bug1);
            Assert.IsNotNull(Id);
            bug1.Id = Id.Value;
            bug1.Title = "damn bug";
            Assert.DoesNotThrow(() => service.UpdateBug(bug1));
            BugModel bug2 = service.GetBug(Id.Value);
            Assert.AreEqual(bug1.Title, bug2.Title);
        }
        [Test]
        public void TestGetBugs()
        {

            List<BugModel> bugs = service.GetBugs();
            Assert.IsNotNull(bugs);
            Assert.IsTrue(bugs.Count > 0);
        }
        [Test]
        public void TestDeleteBug()
        {
            var bug = new BugModel()
            {
                LineNumber = 5001,
                Title = "nasty bug",
                Severity = 0,
                CategoryId = 1000,
                Description = "the worst",
                Status = 0,
                ResolutionId = 1002
            };
            int? Id = service.AddBug(bug);
            Assert.IsNotNull(Id);

            int? rc = service.DeleteBug(Id.Value);
            Assert.IsNotNull(rc);
            Assert.GreaterOrEqual(rc, 1);
        }
    }
}