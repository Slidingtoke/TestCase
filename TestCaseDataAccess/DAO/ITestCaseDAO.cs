using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDataAccess.PresentationModel;

namespace TestCaseDataAccess.DAO
{
    public interface ITestCaseDAO
    {
        bool AddUser(User user);
        bool UpdateUser(User user);
        List<User> GetAllUsers();
    }
}
