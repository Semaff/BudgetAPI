using BudgetAPI.Context;
using BudgetAPI.Controllers.DTO;
using BudgetAPI.Models;
using BudgetAPI.Replicates;
using Microsoft.EntityFrameworkCore;

namespace BudgetAPI.Managers
{
    public class BudgetManager
    {
        protected ApplicationContext ApplicationContext { get; set; }
        protected DbContext DBContext { get; set; }
        private List<Budget> _budgets { get; set; } = new List<Budget>();

        public BudgetManager(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
            DBContext = applicationContext.CreateDbContext();
        }

        public Budget[] Budgets { get => _budgets.ToArray(); }

        public bool Read()
        {
            try
            {
                foreach (EFBudget item in DBContext.Set<EFBudget>())
                {
                    if (item.IsDeleted != true) _budgets.Add(new Budget(item));
                }
                return true;
            }
            catch { throw; }
        }

        public Budget Get(int id) => _budgets.FirstOrDefault(it => it.Id == id);

        public Budget Create(BudgetModel model)
        {
            try
            {
                EFBudget budget = new EFBudget()
                {
                    UserId = model.userId,
                    Amount = model.amount
                };

                DBContext.Add(budget);
                DBContext.SaveChanges();

                Budget replicate = new Budget(budget);
                _budgets.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public Budget Update(BudgetModel model)
        {
            try
            {
                EFBudget _budget = DBContext.Set<EFBudget>().FirstOrDefault(it => it.Id == model.id);

                _budget.UserId = model.userId;
                _budget.Amount = model.amount;

                DBContext.Update(_budget);

                _budgets.Remove(_budgets.FirstOrDefault(it => it.Id == model.id));
                Budget replicate = new Budget(_budget);
                _budgets.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public bool Delete(int id)
        {
            try
            {

                EFBudget _budget = DBContext.Set<EFBudget>().FirstOrDefault(it => it.Id == id);
                _budget.IsDeleted = true;
                DBContext.Update(_budget);

                _budgets.Remove(_budgets.FirstOrDefault(it => it.Id == id));
                return true;

            }
            catch { throw; }
        }
    }
}
