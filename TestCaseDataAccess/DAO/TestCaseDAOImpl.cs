using System;
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
    public class TestCaseDAOImpl : TestCaseDAO
    {
        public void AddOrUpdateUser(User userToBeAdded)
        {
            if(userToBeAdded == null)
            {
                return;
            }
            UserDB existingUser;
            using (var context = new TestCaseDBContext())
            {
                existingUser = context.UserDBSet.Where(userInDB => userInDB.ID == userToBeAdded.ID).FirstOrDefault<UserDB>();
            }


            using (var context = new TestCaseDBContext())
            {
                if (existingUser == null)
                {
                    UserDB userDB = userToBeAdded.ConvertToDB();
                    context.UserDBSet.Add(userDB);
                }
                else
                {
                    UserDB userDB = userToBeAdded.ConvertToDB();
                    context.Entry(userDB).State = System.Data.Entity.EntityState.Modified;
                }
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
                var listOfUsersDB = context.UserDBSet.Where(User => true).ToList();
                foreach (var userDB in listOfUsersDB)
                {
                    allUsers.Add(User.ConvertFromDB(userDB));
                }
            }
            return allUsers;
        }
    }
}
