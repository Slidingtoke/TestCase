using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCaseDataAccess.DAO;
using TestCaseDataAccess.Tests.Helper;

namespace TestCaseDataAccess.Tests.DAO
{
    [TestClass]
    public class TestCaseDAOImplTest : UnitTestSetup
    {
        [TestInitialize]
        public void InitializeTests()
        {
            using (TestCaseDBContext context = new TestCaseDBContext())
            {
                context.Database.Initialize(true);
                var allUsers = context.UserDBSet.Where(userDB => true).ToList();
                Assert.IsTrue(allUsers.Count == 0, "Unable to clear database before tests!");

            }

        }
        [TestMethod]
        public void AddUserTest()
        {
            ITestCaseDAO DAO = new TestCaseDAOImpl();

            var user = ObjectInitializer.CreateStandardUser();
            DAO.AddUser(user);
            
            var allUsers = DAO.GetAllUsers();
            Assert.IsNotNull(allUsers);
            Assert.IsTrue(allUsers.Count == 1, "Database did not contain a single user.");
            Assert.AreEqual(allUsers[0].Name, user.Name);
            Assert.AreEqual(allUsers[0].Email, user.Email);
            Assert.IsTrue(allUsers[0].TodoEntries.Count == 1);
            Assert.AreEqual(allUsers[0].TodoEntries[0].Title, user.TodoEntries[0].Title);
            Assert.AreEqual(allUsers[0].TodoEntries[0].Description, user.TodoEntries[0].Description);
            Assert.AreEqual(allUsers[0].TodoEntries[0].Type, user.TodoEntries[0].Type);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            ITestCaseDAO DAO = new TestCaseDAOImpl();

            var user = ObjectInitializer.CreateStandardUser();
            DAO.AddUser(user);
            var allUsers = DAO.GetAllUsers();

            Assert.IsNotNull(allUsers);
            Assert.IsTrue(allUsers.Count == 1, "Database did not contain a single user.");

            var userInserted = allUsers[0];

            userInserted.Email = "newtestmail@mail.com";
            userInserted.TodoEntries[0].Title = "new test title";
            DAO.UpdateUser(userInserted);

            allUsers = DAO.GetAllUsers();
            Assert.IsNotNull(allUsers);
            Assert.IsTrue(allUsers.Count == 1, "Database did not contain a single user.");
            Assert.AreEqual(allUsers[0].Name, userInserted.Name);
            Assert.AreEqual(allUsers[0].Email, userInserted.Email);
            Assert.IsTrue(allUsers[0].TodoEntries.Count == 1);
            Assert.AreEqual(allUsers[0].TodoEntries[0].Title, userInserted.TodoEntries[0].Title);
            Assert.AreEqual(allUsers[0].TodoEntries[0].Description, userInserted.TodoEntries[0].Description);
            Assert.AreEqual(allUsers[0].TodoEntries[0].Type, userInserted.TodoEntries[0].Type);
        }
    }
}
