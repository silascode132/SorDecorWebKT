using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDecor.DATA.EF;

namespace WebDecor.DATA.DAO
{
    public class ContactDAO
    {
        private SorDbContext data = null;
        public ContactDAO()
        {
            data = new SorDbContext();
        }

        public long InsertFeedBack(Feedback fb)
        {
            data.Feedbacks.Add(fb);
            data.SaveChanges();
            long id = fb.ID;
            return id;
        }
    }
}