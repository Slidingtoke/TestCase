using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDataAccess.DBModel;

namespace TestCaseDataAccess
{
    public class TestCaseDBContext : DbContext
    {

        public TestCaseDBContext() : base("name=testCaseConnectionString")
        {
        }
        public DbSet<UserDB> UserDBSet { get; set; }
    }
}
