using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class ContentRepo : IContentRepo
    {
        ProjectDbContext db = new ProjectDbContext();

        public void Delete(int id)
        {
            Content c = new Content { ContentId = id };
            db.Entry(c).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public List<Content> GetAll()
        {
            return db.Contents.ToList();
        }

        public List<Client> GetClient()
        {
            return db.Clients.ToList();
        }

        public Content GetContentId(int id)
        {
            return db.Contents.First(x => x.ContentId == id);
        }

        public List<Project> GetProject()
        {
            return db.Projects.ToList();
        }

        public void Insert(Content c)
        {
            db.Contents.Add(c);
            db.SaveChanges();
        }

        public void Update(Content c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
