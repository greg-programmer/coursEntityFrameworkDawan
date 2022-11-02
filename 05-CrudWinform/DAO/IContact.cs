using _05_CrudWinform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_CrudWinform.DAO
{
    public interface IContact
    {
        List<Contact> GetAll();
        void Insert(Contact c);
        void Update(Contact c);
        void Delete(int id);
        List<Contact> FindByKey(string key);
        Contact GetById(int id);
    }
}
