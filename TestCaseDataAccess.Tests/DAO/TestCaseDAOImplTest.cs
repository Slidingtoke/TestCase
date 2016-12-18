using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCaseDataAccess.DAO;
using TestCaseDataAccess.PresentationModel;

namespace TestCaseDataAccess.Tests.DAO
{
    [TestClass]
    public class TestCaseDAOImplTest : UnitTestSetup
    {
        [TestMethod]
        public void TestMethod1()
        {

            ITestCaseDAO DAO = new TestCaseDAOImpl();
            var meh = AppDomain.CurrentDomain.GetData("DataDirectory");

            /*User user = new User();
            user.Email = "test@test.com";
            user.Name = "Test";
            user.TodoEntries.Add(new TodoEntry()
            {
                Description = "Test Description",
                Title = "Test Title",
                Type = "Test Type"
            });

            DAO.AddOrUpdateUser(user);*/

            var allUsers = DAO.GetAllUsers();
            Assert.IsNotNull(allUsers);
            Assert.IsTrue(allUsers.Count > 0);
        }
    }
}
