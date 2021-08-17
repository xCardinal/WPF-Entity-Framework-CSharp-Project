using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
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

                foreach(var u in listOfUsers)
                {
                    if(u.UserName == user)
                    {
                        if(u.Status != 0)
                        {
                            if (u.Password == password)
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
                    else
                    {
                        //FAIL - User Doesn't exist
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
            var newCust = new User() { ContactName = newContactName, UserName = newUserName, Password = newPassword, Status=accountStatus=1, Type = "user" };
            using (var db = new SMDbContext())
            {
                db.Users.Add(newCust);
                db.SaveChanges();
            }
        }
        public bool Delete(int deletingID)
        {
            using (var db = new SMDbContext())
            {
                var customer = db.Users.Where(c => c.UserID == deletingID).FirstOrDefault();
                if (customer == null)
                {
                    Debug.WriteLine($"Customer {deletingID} not found");
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
                var user = db.Users.Where(c => c.UserName == userName).FirstOrDefault();
                if (user == null)
                {
                    Debug.WriteLine($"User {user} not found");
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
