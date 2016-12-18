using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDataAccess.DBModel;

namespace TestCaseDataAccess.PresentationModel
{
    public class User
    {
        public User()
        {
            TodoEntries = new List<TodoEntry>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<TodoEntry> TodoEntries { get; set; }

        public UserDB ConvertToDB()
        {
            var userDB = new UserDB();
            userDB.ID = ID;
            userDB.Name = Name;
            userDB.Email = Email;
            userDB.TodoEntries = ConvertTodoEntriesToDB(TodoEntries);
            return userDB;
        }

        public static User ConvertFromDB(UserDB userDb)
        {
            var user = new User();
            user.ID = userDb.ID;
            user.Name = userDb.Name;
            user.Email = userDb.Email;
            user.TodoEntries = ConvertTodoEntriesFromDB(userDb.TodoEntries);
            return user;
        }

        public void CopyFieldsToDBEntry(UserDB userDB)
        {
            userDB.Name = Name;
            userDB.Email = Email;
            userDB.TodoEntries = ConvertTodoEntriesToDB(TodoEntries);
        }

        private static List<TodoEntry> ConvertTodoEntriesFromDB(List<TodoEntryDB> todoEntriesDB)
        {
            var todoEntries = new List<TodoEntry>();
            if(todoEntriesDB == null)
            {
                return todoEntries;
            }
            foreach(var todoEntryDB in todoEntriesDB)
            {
                todoEntries.Add(TodoEntry.ConvertFromDB(todoEntryDB));
            }
            return todoEntries;
        }
        private static List<TodoEntryDB> ConvertTodoEntriesToDB(List<TodoEntry> todoEntries)
        {
            var todoEntriesDB = new List<TodoEntryDB>();
            if (todoEntries == null)
            {
                return todoEntriesDB;
            }
            foreach (var todoEntry in todoEntries)
            {
                todoEntriesDB.Add(todoEntry.ConvertToDB());
            }
            return todoEntriesDB;
        }
    }
}
