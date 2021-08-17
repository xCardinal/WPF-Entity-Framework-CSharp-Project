using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Diagnostics;

namespace BusinessLayer
{
    public class Brains
    {
        public User SelectedUser { get; set; }

        public void SetSelectedUser(object selectedObject)
        {
            SelectedUser = (User)selectedObject;
        }

        public bool Login(string user, string password)
        {
            using (var db = new SMDbContext())
            {
                var listOfUsers =
                    db.Users.ToList();

                var query1 =
                    db.Users.FirstOrDefault(u => u.UserName == user);

                if(query1 != null)
                {
                    if (query1.Status != 0)
                    {
                        if (query1.Password == password)
                        {
                            //OK
                            return true;
                        }
                        else
                        {
                            //FAIL - password is wrong 
                            return false;
                        }
                    }
                    else
                    {
                        //FAIL - Account status is 0
                        return false;
                    }
                }

                return false;
            }
        }

        public void Create(
        string newContactName,
        string newUserName,
        string newPassword,
        int accountStatus,
            string accountType)
        {
            var newUser = new User() { ContactName = newContactName, UserName = newUserName, Password = newPassword, Status=accountStatus=1, Type = "user" };
            using (var db = new SMDbContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
       public bool Create(
       string newUserName,
       string newPassword)
        {
            var newUser = new User() { UserName = newUserName, Password = newPassword };
            using (var db = new SMDbContext())
            {
                var users = db.Users.ToList();
                var user = db.Users.FirstOrDefault(c => c.UserName == newUserName);
                if (user == null)
                {
                    db.Users.Add(newUser);
                    newUser.Status = 1;
                    newUser.Type = "user";
                    db.SaveChanges();
                    return true;
                }
            }
            Debug.WriteLine($"Username {newUserName} is taken!");
            return false;
        }
        public bool Delete(int deletingId)
        {
            using (var db = new SMDbContext())
            {
                var customer = db.Users.FirstOrDefault(c => c.UserId == deletingId);
                if (customer == null)
                {
                    Debug.WriteLine($"Customer {deletingId} not found");
                    return false;
                }
                db.Users.RemoveRange(customer);
                db.SaveChanges();
            }
            return true;
        }
        public bool Update(
            string contactName,
            string userName,
            string password,
            int accountStatus,
            string accountType)
        {
            using (var db = new SMDbContext())
            {
                var user = db.Users.FirstOrDefault(c => c.UserName == userName);
                if (user == null)
                {
                    Debug.WriteLine($"User {(User?) null} not found");
                    return false;
                }
                user.ContactName = contactName;
                user.UserName = userName;
                user.Password = password;
                user.Type = accountType;
                user.Status = accountStatus;
                // write changes to database
                try
                {
                    db.SaveChanges();
                    SelectedUser = user;
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error updating {userName}");
                    return false;
                }
            }
            return true;
        }

    }
}
