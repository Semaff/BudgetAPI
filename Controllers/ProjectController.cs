using ElectricalAPI.Context;
using ElectricalAPI.Controllers.DTO;
using ElectricalAPI.Replicates;
using Microsoft.AspNetCore.Mvc;

namespace ElectricalAPI.Controllers
{
    public class ProjectController : BaseController
    {
        public ProjectController(ApplicationContext _appContext) : base(_appContext) { }

        [HttpGet("[controller]/[action]")]
        public JsonResult Init()
        {
            var res = GetCommon();
            return Send(true, res);
        }

        [HttpGet("[controller]/[action]")]
        public JsonResult GetAll()
        {
            var res = GetCommon();
            res.projects = ApplicationContext.ProjectManager.Projects.Select(it => new ProjectModel(it));
            return Send(true, res);
        }


        [HttpGet("[controller]/[action]")]
        public JsonResult Get(int id)
        {
            var res = GetCommon();
            res.projects = new ProjectModel(ApplicationContext.ProjectManager.Projects.FirstOrDefault(it => it.Id == id));
            return Send(true, res);
        }

        [HttpPost("[controller]/[action]")]
        public JsonResult Create([FromBody] ProjectModel model)
        {
            Project project = ApplicationContext.ProjectManager.Create(model);

            var res = GetCommon();
            res.projects = new ProjectModel(project);
            return Send(true, res);
        }

        [HttpPut("[controller]/[action]")]
        public JsonResult Update([FromBody] ProjectModel model)
        {
            Project project = ApplicationContext.ProjectManager.Update(model);

            var res = GetCommon();
            res.projects = new ProjectModel(project);
            return Send(true, res);
        }

        [HttpDelete("[controller]/[action]")]
        public JsonResult Delete(int id)
        {
            ApplicationContext.ProjectManager.Delete(id);
            var res = GetCommon();
            res.projects = ApplicationContext.ProjectManager.Projects.Select(it => new ProjectModel(it));
            return Send(true, res);
        }
    }
}
