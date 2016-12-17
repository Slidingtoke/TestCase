using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDataAccess.Tests
{
    public class UnitTestSetup
    {
        public UnitTestSetup()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("\\Release", "").Replace("\\Debug", "").Replace("\\bin", ""), "App_Data"));
        }
    }
}
