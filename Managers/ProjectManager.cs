using ElectricalAPI.Context;
using ElectricalAPI.Controllers.DTO;
using ElectricalAPI.Models;
using ElectricalAPI.Replicates;
using Microsoft.EntityFrameworkCore;

namespace ElectricalAPI.Managers
{
    public class ProjectManager
    {

        protected ApplicationContext ApplicationContext { get; set; }
        protected DBContext DBContext { get; set; }
        public ProjectManager (ApplicationContext applicationContext) { ApplicationContext = applicationContext;  DBContext = applicationContext.CreateDbContext(); }

        private List<Project> _projects { get; set; } = new List<Project> ();

        public Project[] Projects { get => _projects.ToArray (); }
        public bool Read()
        {
            try
            {
                foreach (EFProject item in DBContext.Projects)
                {
                    if(item.IsDeleted != true) _projects.Add(new Project(item));
                }
                return true;
            }
            catch { throw; }
        }

        public Project Get(int id) => _projects.FirstOrDefault(it => it.Id == id);

        public Project Create(ProjectModel model)
        {
            try
            {
                EFProject project = new EFProject()
                {
                    Name = "Проводка Дома",
                    ClientID = 3,
                    WorkerId = 3,
                    StartDate = new DateTime(),
                    EndDate = new DateTime(),
                    Status = "В работе",
                };

                DBContext.Add(project);
                DBContext.SaveChanges();

                Project replicate = new Project(project);
                _projects.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public Project Update(ProjectModel model)
        {
            try
            {

                EFProject _project = DBContext.Projects.FirstOrDefault(it => it.Id == 1);


                _project.Status = "Готово";

                DBContext.Update(_project);
                DBContext.SaveChanges();

                _projects.Remove(_projects.FirstOrDefault(it => it.Id == 1));
                Project replicate = new Project(_project);
                _projects.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public bool Delete(int id)
        {
            try
            {

                EFProject _project = DBContext.Projects.FirstOrDefault(it => it.Id == id);
                _project.IsDeleted = true;
                DBContext.Update(_project);
                DBContext.SaveChanges();
                _projects.Remove(_projects.FirstOrDefault(it => it.Id == id));
                return true;

            }
            catch { throw; }
        }
    }
}
