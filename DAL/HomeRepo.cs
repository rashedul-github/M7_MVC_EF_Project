using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class HomeRepo : IHomeRepo
    {
        ProjectDbContext db = new ProjectDbContext();

        public void Add(tables t)
        {
            Client cl = t.Client;
            Project p = t.Project;
            Content c = t.Content;
            c.Client.ClientName = t.Content.Client.ClientName;
            c.Project.ProjectName = t.Content.Project.ProjectName;
            c.StartDate = t.Content.StartDate;
            c.EndDate = t.Content.EndDate;
            c.WorkCarriedOut = t.Content.WorkCarriedOut;
            c.EstimatedCost = t.Content.EstimatedCost;
            db.Contents.Add(c);
            db.SaveChanges();

        }

        public List<Project> GetOrder()
        {
            return db.Projects.OrderBy(x=>x.ProjectId).ToList();
        }

        public List<Content> GetRelated(int id)
        {
            return db.Contents.Include(m => m.Project).Where(x => x.ProjectId == id).ToList();
        }

        public int pageCount(int perPage)
        {
            return (int)Math.Ceiling((double)db.Projects.Count() / perPage);
        }

        public string ProjectName(int id)
        {
            return db.Projects.First(x => x.ProjectId == id).ProjectName;
        }
    }
}
