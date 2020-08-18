using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfHotel.Model;

namespace WpfHotel
{
    class Service
    {
        internal bool IsOwner(string userName, string password)
        {
            string[] userPass = new string[2];
            int counter = 0;
            using (StreamReader sr = new StreamReader("../../OwnerAccess.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    userPass[counter] = line;
                    counter++;
                }
            }
            if (userName == userPass[0] && password == userPass[1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal List<tblEngagement> GetAllEngagements()
        {
            try
            {
                using (HotelEntities1 context = new HotelEntities1())
                {
                    List<tblEngagement> list = (from l in context.tblEngagements select l).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Exception" + ex.Message.ToString());
                return null;
            }
        }

        internal List<string> FillQualificationsList()
        {
            List<string> list = new List<string>();
            list.Add("I");
            list.Add("II");
            list.Add("III");
            list.Add("IV");
            list.Add("V");
            list.Add("VI");
            list.Add("VII");
            return list;
        }

        internal tblManager GetManager(string userName)
        {
            using (HotelEntities1 context = new HotelEntities1())
            {
                tblAccount account = (from a in context.tblAccounts where a.UserName == userName select a).First();
                tblManager manager = (from m in context.tblManagers where m.AccountID == account.AccountID select m).First();
                return manager;
            }
        }

        internal tblEmployee GetEmployee(string userName)
        {
            using (HotelEntities1 context = new HotelEntities1())
            {
                tblAccount account = (from a in context.tblAccounts where a.UserName == userName select a).First();
                tblEmployee employee = (from e in context.tblEmployees where e.AccountID == account.AccountID select e).First();
                return employee;
            }
        }

        internal void AddManager(tblManager manager, tblAccount account, string dateOfBirth)
        {
            using (HotelEntities1 context = new HotelEntities1())
            {
                DateTime date = DateTime.ParseExact(dateOfBirth, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                tblAccount newAccount = new tblAccount();
                newAccount.FullName = account.FullName;
                newAccount.DateOfBirth = date;
                newAccount.Email = account.Email;
                newAccount.UserName = account.UserName;
                newAccount.Pass = account.Pass;
                context.tblAccounts.Add(newAccount);
                context.SaveChanges();

                tblManager newManager = new tblManager();
                newManager.AccountID = newAccount.AccountID;
                newManager.HotelFloor = manager.HotelFloor;
                newManager.Experience = manager.Experience;
                newManager.QualificationsLevel = manager.QualificationsLevel;
                context.tblManagers.Add(newManager);
                context.SaveChanges();
            }
        }

        internal tblEmployee AddEmployee(tblEmployee employee)
        {
            throw new NotImplementedException();
        }

        internal bool IsEmployee(string userName, string password)
        {
            try
            {
                using (HotelEntities1 context = new HotelEntities1())
                {
                    tblAccount account = (from a in context.tblAccounts where a.UserName == userName && a.Pass == password select a).First();
                    tblEmployee employee = (from e in context.tblEmployees where e.AccountID == account.AccountID select e).First();
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }

        internal bool IsManager(string userName, string password)
        {
            try
            {
                using (HotelEntities1 context = new HotelEntities1())
                {
                    tblAccount account = (from a in context.tblAccounts where a.UserName == userName && a.Pass == password select a).First();
                    tblManager manager = (from m in context.tblManagers where m.AccountID == account.AccountID select m).First();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
