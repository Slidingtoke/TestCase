using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDataAccess.DBModel;
using TestCaseDataAccess.PresentationModel;

namespace TestCaseDataAccess.DAO
{
    public class TestCaseDAOImpl : ITestCaseDAO
    {
        public void AddUser(User userToBeAdded)
        {
            if (userToBeAdded == null)
            {
                return;
            }
            
            using (var context = new TestCaseDBContext())
            {
                UserDB userDB = userToBeAdded.ConvertToDB();
                context.UserDBSet.Add(userDB);
                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException dbException)
                {
                    //TODO: Use the projects logging method
                    Debug.WriteLine("Unable to save user entry, exception " + dbException.InnerException + ", message " + dbException.Message);
                }
            }
        }
        public void UpdateUser(User userToBeUpdated)
        {
            if (userToBeUpdated == null)
            {
                return;
            }
            UserDB existingUser;
            using (var context = new TestCaseDBContext())
            {
                existingUser = context.UserDBSet.Where(userInDB => userInDB.ID == userToBeUpdated.ID).Include(user => user.TodoEntries).FirstOrDefault<UserDB>();

                userToBeUpdated.CopyFieldsToDBEntry(existingUser);
                context.Entry(existingUser).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    context.SaveChanges();

                }
                catch (DbEntityValidationException dbException)
                {
                    //TODO: Use the projects logging method
                    Debug.WriteLine("Unable to save user entry, exception " + dbException.InnerException + ", message " + dbException.Message);
                }
            }
        }

        public List<User> GetAllUsers()
        {
            var allUsers = new List<User>();
            using (var context = new TestCaseDBContext())
            {
                var listOfUsersDB = context.UserDBSet.Where(User => true).Include(user => user.TodoEntries).ToList();
                foreach (var userDB in listOfUsersDB)
                {
                    allUsers.Add(User.ConvertFromDB(userDB));
                }
            }
            return allUsers;
        }
    }
}
