using ElectricalAPI.Context;
using ElectricalAPI.Controllers.DTO;
using ElectricalAPI.Replicates;
using Microsoft.AspNetCore.Mvc;

namespace ElectricalAPI.Controllers
{
    public class ClientController : BaseController
    {
        public ClientController(ApplicationContext _appContext) : base(_appContext) { }

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
            res.clients = ApplicationContext.ClientManager.Clients.Select(it => new ClientModel(it));
            return Send(true, res);
        }


        [HttpGet("[controller]/[action]")]
        public JsonResult Get(int id)
        {
            var res = GetCommon();
            res.clients = new ClientModel(ApplicationContext.ClientManager.Clients.FirstOrDefault(it => it.Id == id));
            return Send(true, res);
        }

        [HttpPost("[controller]/[action]")]
        public JsonResult Create([FromBody] ClientModel model)
        {
            Client client = ApplicationContext.ClientManager.Create(model);

            var res = GetCommon();
            res.clients = new ClientModel(client);
            return Send(true, res);
        }

        [HttpPut("[controller]/[action]")]
        public JsonResult Update([FromBody] ClientModel model)
        {

            Client client = ApplicationContext.ClientManager.Update(model);

            var res = GetCommon();
            res.clients = new ClientModel(client);
            return Send(true, res);
        }

        [HttpDelete("[controller]/[action]")]
        public JsonResult Delete(int id)
        {
            ApplicationContext.ClientManager.Delete(id);
            var res = GetCommon();
            res.clients = ApplicationContext.ClientManager.Clients.Select(it => new ClientModel(it));
            return Send(true, res);
        }
    }
}
