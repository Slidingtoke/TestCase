using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDataAccess.PresentationModel;

namespace TestCaseDataAccess.Tests.Helper
{
    public class ObjectInitializer
    {
        public static User CreateStandardUser()
        {
            return new User()
            {
                Name = "Test",
                Email = "test@test.com",
                TodoEntries = new List<TodoEntry>()
                {
                    new TodoEntry()
                    {
                        Title = "Title",
                        Description = "Description",
                        Type = "type"
                    }
                }
            };
        }
    }
}
