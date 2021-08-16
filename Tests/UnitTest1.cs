using NUnit.Framework;
using BusinessLayer;
using Data;
using Database;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        Brains _user;
        [SetUp]
        public void Setup()
        {
            _user = new Brains();

            using (var db = new SMDbContext())
            {
                var selectedCustomers =
                from c in db.Users
                where c.UserName == "spYagami"
                select c;

                db.Users.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewCustomerIsAdded_TheNumberOfCustemersIncreasesBy1()
        {
            using (var db = new SMDbContext())
            {
                var numberOfUsers = db.Users.Count();

                _user.Create("Sergio Pessegueiro", "spYagami", "HelloGuys",1);

                var numberOfUsersAfter = db.Users.Count();

                Assert.That(numberOfUsers + 1, Is.EqualTo(numberOfUsersAfter));
            }
        }
        [Test]
        public void WhenACustomerIsRemoved_TheNumberOfCustomersDecreasesBy1()
        {
            using (var db = new SMDbContext())
            {
                var newUser =
                    new User()
                    {
                        UserName = "spYagami",
                        Password = "HelloWorld",
                        ContactName = "Sergio",
                        Status = 1
                    };

                db.Users.Add(newUser);
                db.SaveChanges();

                var selectUser =
                    db.Users
                    .Where(u => u.UserName == "spYagami")
                    .Select(u => u.UserID)
                    .FirstOrDefault();

                var numberOfCustomersBefore = db.Users.ToList().Count();
                _user.Delete(selectUser);
                var numberOfCustomersAfter = db.Users.ToList().Count();
                Assert.That(numberOfCustomersBefore - 1, Is.EqualTo(numberOfCustomersAfter));
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new SMDbContext())
            {
                var selectedUser =
                    from c in db.Users
                    where c.UserName == "spYagami"
                    select c;

                db.Users.RemoveRange(selectedUser);
                db.SaveChanges();
            }
        }
    }
}