using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCaseDataAccess.DAO;
using TestCaseDataAccess.PresentationModel;

namespace TestCaseApplication.Controllers
{
    public class RestController : Controller
    {
        private ITestCaseDAO _testCaseDAO;
        public RestController(ITestCaseDAO testCaseDAO)
        {
            _testCaseDAO = testCaseDAO;
        }

        public ActionResult Users()
        {
            return Content(JsonConvert.SerializeObject(_testCaseDAO.GetAllUsers()), "application/json");
        }

        public ActionResult AddUser(User user)
        {
            if (user == null || user.ID != 0)
            {
                return new HttpStatusCodeResult(400);
            }
            _testCaseDAO.AddUser(user);
            return new HttpStatusCodeResult(200);
        }
        public ActionResult UpdateUser(User user)
        {
            if(user == null || user.ID == 0)
            {
                return new HttpStatusCodeResult(400);
            }
            _testCaseDAO.UpdateUser(user);
            return new HttpStatusCodeResult(200);
        }
    }
}