using ElectricalAPI.Context;
using ElectricalAPI.Controllers.DTO;
using ElectricalAPI.Replicates;
using Microsoft.AspNetCore.Mvc;

namespace ElectricalAPI.Controllers
{
    public class WorkerController : BaseController
    {
        public WorkerController(ApplicationContext _appContext) : base(_appContext) { }

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
            res.workers = ApplicationContext.WorkerManager.Workers.Select(it => new WorkerModel(it));
            return Send(true, res);
        }


        [HttpGet("[controller]/[action]")]
        public JsonResult Get(int id)
        {
            var res = GetCommon();
            res.workers = new WorkerModel(ApplicationContext.WorkerManager.Workers.FirstOrDefault(it => it.Id == id));
            return Send(true, res);
        }

        [HttpPost("[controller]/[action]")]
        public JsonResult Create([FromBody] WorkerModel model)
        {
            Worker worker = ApplicationContext.WorkerManager.Create(model);

            var res = GetCommon();
            res.workers = new WorkerModel(worker);
            return Send(true, res);
        }

        [HttpPut("[controller]/[action]")]
        public JsonResult Update([FromBody] WorkerModel model)
        {

            Worker worker = ApplicationContext.WorkerManager.Update(model);

            var res = GetCommon();
            res.workers = new WorkerModel(worker);
            return Send(true, res);
        }

        [HttpDelete("[controller]/[action]")]
        public JsonResult Delete(int id)
        {
            ApplicationContext.WorkerManager.Delete(id);
            var res = GetCommon();
            res.workers = ApplicationContext.WorkerManager.Workers.Select(it => new WorkerModel(it));
            return Send(true, res);
        }
    }
}
