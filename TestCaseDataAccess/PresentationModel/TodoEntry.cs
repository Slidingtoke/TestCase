using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDataAccess.DBModel;

namespace TestCaseDataAccess.PresentationModel
{
    public class TodoEntry
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public TodoEntryDB ConvertToDB()
        {
            var todoEntryDB = new TodoEntryDB();
            todoEntryDB.ID = ID;
            todoEntryDB.Title = Title;
            todoEntryDB.Description = Description;
            todoEntryDB.Type = Type;
            return todoEntryDB;
        }

        public static TodoEntry ConvertFromDB(TodoEntryDB todoEntryDB)
        {
            var todoEntry = new TodoEntry();
            todoEntry.ID = todoEntryDB.ID;
            todoEntry.Title = todoEntryDB.Title;
            todoEntry.Description = todoEntryDB.Description;
            todoEntry.Type = todoEntryDB.Type;
            return todoEntry;
        }
    }
}
