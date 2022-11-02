using _05_CrudWinform.DAO;
using _05_CrudWinform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_CrudWinform.Services
{
    public class ContactService
    {
        private ContactDAO dao = new ContactDAO();

        public void Insert(Contact c)
        {
            dao.Insert(c);
        }

        public void Update(Contact c)
        {
            dao.Update(c);
        }

        public void Delete(int id)
        {
            dao.Delete(id);
        }

        public List<Contact> GetAll()
        {
            return dao.GetAll();
        }

        public List<Contact> FindByKey(string key)
        {
            return dao.FindByKey(key);
        }

        public Contact GetById(int id)
        {
            return dao.GetById(id);
        }
    }
}
