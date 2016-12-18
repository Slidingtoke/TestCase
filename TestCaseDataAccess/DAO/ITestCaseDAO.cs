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
        void AddOrUpdateUser(User user);
        List<User> GetAllUsers();
    }
}
