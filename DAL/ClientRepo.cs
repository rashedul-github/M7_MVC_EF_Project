using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class ClientRepo : IClientRepo
    {
        ProjectDbContext db = new ProjectDbContext();

        public void Delete(int id)
        {
            Client c = new Client { ClientId = id };
            db.Entry(c).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public List<Client> GetAll()
        {
            return db.Clients.ToList();
        }

        public Client GetClientId(int id)
        {
            return db.Clients.First(x => x.ClientId == id);
        }

        public void Insert(Client c)
        {
            db.Clients.Add(c);
            db.SaveChanges();
        }

        public void Update(Client c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
