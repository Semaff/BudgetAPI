using BudgetAPI.Context;
using BudgetAPI.Controllers.DTO;
using BudgetAPI.Models;
using BudgetAPI.Replicates;
using Microsoft.EntityFrameworkCore;

namespace BudgetAPI.Managers
{
    public class CategoryManager
    {
        protected ApplicationContext ApplicationContext { get; set; }
        protected DbContext DBContext { get; set; }
        private List<Category> _categories { get; set; } = new List<Category>();

        public CategoryManager(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
            DBContext = applicationContext.CreateDbContext();
        }

        public Category[] Categories { get => _categories.ToArray(); }

        public bool Read()
        {
            try
            {
                foreach (EFCategory item in DBContext.Set<EFCategory>())
                {
                    if (item.IsDeleted != true) _categories.Add(new Category(item));
                }
                return true;
            }
            catch { throw; }
        }

        public Category Get(int id) => _categories.FirstOrDefault(it => it.Id == id);

        public Category Create(CategoryModel model)
        {
            try
            {
                EFCategory category = new EFCategory()
                {
                    Name = model.name,
                    Type = model.type
                };

                DBContext.Add(category);
                DBContext.SaveChanges();

                Category replicate = new Category(category);
                _categories.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public Category Update(CategoryModel model)
        {
            try
            {
                EFCategory _category = DBContext.Set<EFCategory>().FirstOrDefault(it => it.Id == model.id);

                _category.Name = model.name;
                _category.Type = model.type;

                DBContext.Update(_category);

                _categories.Remove(_categories.FirstOrDefault(it => it.Id == model.id));
                Category replicate = new Category(_category);
                _categories.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public bool Delete(int id)
        {
            try
            {

                EFCategory _category = DBContext.Set<EFCategory>().FirstOrDefault(it => it.Id == id);
                _category.IsDeleted = true;
                DBContext.Update(_category);

                _categories.Remove(_categories.FirstOrDefault(it => it.Id == id));
                return true;

            }
            catch { throw; }
        }
    }
}
