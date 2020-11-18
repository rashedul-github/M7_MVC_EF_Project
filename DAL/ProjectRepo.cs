using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class ProjectRepo : IProjectRepo
    {
        ProjectDbContext db = new ProjectDbContext();

        public void Delete(int id)
        {
            Project p = new Project { ProjectId = id };
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public List<Project> GetAll()
        {
            return db.Projects.ToList();
        }

        public List<Client> GetClient()
        {
            return db.Clients.ToList();
        }

        public Project GetProjectId(int id)
        {
            return db.Projects.First(x => x.ProjectId == id);
        }

        public void Insert(Project p)
        {
            db.Projects.Add(p);
            db.SaveChanges();
        }

        public void Update(Project p)
        {
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
