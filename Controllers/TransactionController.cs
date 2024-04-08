using BudgetAPI.Context;
using BudgetAPI.Controllers.DTO;
using BudgetAPI.Replicates;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAPI.Controllers
{
    public class TransactionController : BaseController
    {
        public TransactionController(ApplicationContext _appContext) : base(_appContext) { }

        [HttpGet("[controller]/[action]")]
        public JsonResult GetAll()
        {
            var res = GetCommon();
            res.transactions = ApplicationContext.TransactionManager.Transactions.Select(it => new TransactionModel(it));
            return Send(true, res);
        }

        [HttpGet("[controller]/[action]")]
        public JsonResult Get(int id)
        {
            var res = GetCommon();
            res.transactions = new TransactionModel(ApplicationContext.TransactionManager.Get(id));
            return Send(true, res);
        }

        [HttpPost("[controller]/[action]")]
        public JsonResult Create([FromBody] TransactionModel model)
        {
            Transaction transaction = ApplicationContext.TransactionManager.Create(model);

            var res = GetCommon();
            res.transactions = new TransactionModel(transaction);
            return Send(true, res);
        }

        [HttpPut("[controller]/[action]")]
        public JsonResult Update([FromBody] TransactionModel model)
        {
            Transaction transaction = ApplicationContext.TransactionManager.Update(model);

            var res = GetCommon();
            res.transactions = new TransactionModel(transaction);
            return Send(true, res);
        }

        [HttpDelete("[controller]/[action]")]
        public JsonResult Delete(int id)
        {
            ApplicationContext.TransactionManager.Delete(id);
            var res = GetCommon();
            res.transactions = ApplicationContext.TransactionManager.Transactions.Select(it => new TransactionModel(it));
            return Send(true, res);
        }
    }
}
