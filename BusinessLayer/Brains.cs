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

        public void Create(
        string newContactName,
        string newUserName,
        string newPassword,
        int accountStatus)
        {
            var newCust = new User() { ContactName = newContactName, UserName = newUserName, Password = newPassword, Status=accountStatus=1 };
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

    }
}
