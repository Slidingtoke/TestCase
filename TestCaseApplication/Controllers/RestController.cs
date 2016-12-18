using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCaseDataAccess.DAO;

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
    }
}