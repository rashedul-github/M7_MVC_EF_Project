using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IHomeRepo
    {
        string ProjectName(int id);
        List<Project> GetOrder();
        int pageCount(int perPage);
        void Add(tables t);
        List<Content> GetRelated(int id);
    }
    public interface IClientRepo
    {
        List<Client> GetAll();
        void Insert(Client c);
        void Update(Client c);
        Client GetClientId(int id);
        void Delete(int id);
    }
    public interface IProjectRepo
    {
        List<Project> GetAll();
        void Insert(Project p);
        void Update(Project p);
        Project GetProjectId(int id);
        void Delete(int id);
        List<Client> GetClient();
    }
    public interface IContentRepo
    {
        List<Content> GetAll();
        void Insert(Content c);
        List<Client> GetClient();
        List<Project> GetProject();
        void Update(Content c);
        void Delete(int id);
        Content GetContentId(int id);

    }
}
