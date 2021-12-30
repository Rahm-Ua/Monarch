using MonarchBLL;
using MonarchDAL.Models;
using NUnit.Framework;

namespace MonarchTest
{
    [TestFixture]
    public class BugTester
    {
        private BugService service;

        [SetUp]
        public void Setup()
        {
            service = new BugService();
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
            Assert.GreaterOrEqual(1, result.Value);
        }
    }
}