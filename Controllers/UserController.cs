using BudgetAPI.Context;
using BudgetAPI.Controllers.DTO;
using BudgetAPI.Replicates;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAPI.Controllers
{
    public class UserController : BaseController
    {
        public UserController(ApplicationContext _appContext) : base(_appContext) { }

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
            res.users = ApplicationContext.UserManager.Users.Select(it => new UserModel(it));
            return Send(true, res);
        }


        [HttpGet("[controller]/[action]")]
        public JsonResult Get(int id)
        {
            var res = GetCommon();
            res.users = new UserModel(ApplicationContext.UserManager.Users.FirstOrDefault(it => it.Id == id));
            return Send(true, res);
        }

        [HttpPost("[controller]/[action]")]
        public JsonResult Create([FromBody] UserModel model)
        {
            User user = ApplicationContext.UserManager.Create(model);

            var res = GetCommon();
            res.users = new UserModel(user);
            return Send(true, res);
        }

        [HttpPut("[controller]/[action]")]
        public JsonResult Update([FromBody] UserModel model)
        {

            User user = ApplicationContext.UserManager.Update(model);

            var res = GetCommon();
            res.users = new UserModel(user);
            return Send(true, res);
        }

        [HttpDelete("[controller]/[action]")]
        public JsonResult Delete(int id)
        {
            ApplicationContext.UserManager.Delete(id);
            var res = GetCommon();
            res.users = ApplicationContext.UserManager.Users.Select(it => new UserModel(it));
            return Send(true, res);
        }
    }
}
