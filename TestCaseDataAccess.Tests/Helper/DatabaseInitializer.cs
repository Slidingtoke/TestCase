using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDataAccess.Tests.Helper
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseAlways<TestCaseDBContext>
    {
        protected override void Seed(TestCaseDBContext context)
        {
            context.SaveChanges();
        }
    }
}
