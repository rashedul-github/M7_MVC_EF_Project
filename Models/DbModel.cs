using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client
    {
        public Client()
        {
            this.Content = new List<Content>();
            this.Project = new List<Project>();
        }
        [Display(Name = "Client Id")]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Client Name is required."),StringLength(40)]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        //Navigation
        public virtual ICollection<Content> Content { get; set; }
        public virtual ICollection<Project> Project { get; set; }
    }
    public class Content
    {
        [Display(Name = "Content Id")]
        public int ContentId { get; set; }
        [Display(Name = "Requisted By")]
        public int? ClientId { get; set; }
        [Required(ErrorMessage = "Poject Name is required."), Display(Name = "Project Name")]
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "Start Date is required."), DataType(DataType.Date), Display(Name = "Start Date")]
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:dd-MMM-yy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date is required."), DataType(DataType.Date), Display(Name = "End Date")]
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:dd-MMM-yy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Work carried out is required."),StringLength(50)]
        [Display(Name = "Work Carried Out")]
        public string WorkCarriedOut { get; set; }
        [Required(ErrorMessage ="Estimated cost is required."),Display(Name = "Estimated Cost")]
        [Column(TypeName ="money"),DisplayFormat(DataFormatString ="{0:0.00}",ApplyFormatInEditMode =true)]
        public decimal EstimatedCost { get; set; }

        //Navigation
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }


    }
    public class Project
    {
        public Project()
        {
            this.Content = new List<Content>();
        }
        [Display(Name = "Project Id")]
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "Project Name is required."), StringLength(40)]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        
        [Required(ErrorMessage = "Client Name is required."), Display(Name = "Requisted By")]
        public int ClientId { get; set; }
        //Navigation
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public virtual ICollection<Content> Content { get; set; }
    }
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProjectDbContext>());
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Project> Projects { get; set; }
     
    }
}
