using BudgetAPI.Context;
using BudgetAPI.Controllers.DTO;
using BudgetAPI.Replicates;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BudgetAPI.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(ApplicationContext _appContext) : base(_appContext) { }

        [HttpGet("[controller]/[action]")]
        public JsonResult GetAll()
        {
            var res = GetCommon();
            res.categories = ApplicationContext.CategoryManager.Categories.Select(it => new CategoryModel(it));
            return Send(true, res);
        }

        [HttpGet("[controller]/[action]")]
        public JsonResult Get(int id)
        {
            var res = GetCommon();
            res.categories = new CategoryModel(ApplicationContext.CategoryManager.Get(id));
            return Send(true, res);
        }

        [HttpPost("[controller]/[action]")]
        public JsonResult Create([FromBody] CategoryModel model)
        {
            Category category = ApplicationContext.CategoryManager.Create(model);

            var res = GetCommon();
            res.categories = new CategoryModel(category);
            return Send(true, res);
        }

        [HttpPut("[controller]/[action]")]
        public JsonResult Update([FromBody] CategoryModel model)
        {
            Category category = ApplicationContext.CategoryManager.Update(model);

            var res = GetCommon();
            res.categories = new CategoryModel(category);
            return Send(true, res);
        }

        [HttpDelete("[controller]/[action]")]
        public JsonResult Delete(int id)
        {
            ApplicationContext.CategoryManager.Delete(id);
            var res = GetCommon();
            res.categories = ApplicationContext.CategoryManager.Categories.Select(it => new CategoryModel(it));
            return Send(true, res);
        }
    }
}
