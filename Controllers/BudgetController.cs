using BudgetAPI.Context;
using BudgetAPI.Controllers.DTO;
using BudgetAPI.Replicates;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAPI.Controllers
{
    public class BudgetController : BaseController
    {
        public BudgetController(ApplicationContext _appContext) : base(_appContext) { }

        [HttpGet("[controller]/[action]")]
        public JsonResult GetAll()
        {
            var res = GetCommon();
            res.budgets = ApplicationContext.BudgetManager.Budgets.Select(it => new BudgetModel(it));
            return Send(true, res);
        }

        [HttpGet("[controller]/[action]")]
        public JsonResult Get(int id)
        {
            var res = GetCommon();
            res.budgets = new BudgetModel(ApplicationContext.BudgetManager.Get(id));
            return Send(true, res);
        }

        [HttpPost("[controller]/[action]")]
        public JsonResult Create([FromBody] BudgetModel model)
        {
            Budget budget = ApplicationContext.BudgetManager.Create(model);

            var res = GetCommon();
            res.budgets = new BudgetModel(budget);
            return Send(true, res);
        }

        [HttpPut("[controller]/[action]")]
        public JsonResult Update([FromBody] BudgetModel model)
        {
            Budget budget = ApplicationContext.BudgetManager.Update(model);

            var res = GetCommon();
            res.budgets = new BudgetModel(budget);
            return Send(true, res);
        }

        [HttpDelete("[controller]/[action]")]
        public JsonResult Delete(int id)
        {
            ApplicationContext.BudgetManager.Delete(id);
            var res = GetCommon();
            res.budgets = ApplicationContext.BudgetManager.Budgets.Select(it => new BudgetModel(it));
            return Send(true, res);
        }
    }
}
