using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDecor.DATA.EF;
using PagedList;

namespace WebDecor.DATA.DAO
{
    public class UserDAO
    {
        private SorDbContext data = null;
        public UserDAO()
        {
            data = new SorDbContext();
        }
        public int Insert(UserAccount entity)
        {
            data.UserAccounts.Add(entity);
            data.SaveChanges();
            int i = data.UserAccounts.Count(x => x.UserName == entity.UserName);
            return i;
        }

        public int InsertFromFacebook(UserAccount entity)
        {
            var user = data.UserAccounts.SingleOrDefault(x => x.UserName == entity.UserName);
            if (user == null)
            {
                data.UserAccounts.Add(entity);
                data.SaveChanges();
                int i = data.UserAccounts.Count(x => x.UserName == entity.UserName);
                return i;
            }
            else
            {
                return 0;
            }
        }

        public UserAccount GetById(string username)
        {
            return data.UserAccounts.SingleOrDefault(x=>x.UserName == username);
        }

        public Admin GetAdminByID(string username)
        {
            return data.Admins.SingleOrDefault(x => x.UserName == username);
        }

        public bool CheckUserName(string username)
        {
            return data.UserAccounts.Count(x => x.UserName == username) > 0;
        }

        public bool CheckMail(string mail)
        {
            return data.UserAccounts.Count(x => x.Email == mail) > 0;
        }
    }
}