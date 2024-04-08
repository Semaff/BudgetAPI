using BudgetAPI.Context;
using BudgetAPI.Controllers.DTO;
using BudgetAPI.Models;
using BudgetAPI.Replicates;
using Microsoft.EntityFrameworkCore;

namespace BudgetAPI.Managers
{
    public class TransactionManager
    {
        protected ApplicationContext ApplicationContext { get; set; }
        protected DbContext DBContext { get; set; }
        private List<Transaction> _transactions { get; set; } = new List<Transaction>();

        public TransactionManager(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
            DBContext = applicationContext.CreateDbContext();
        }

        public Transaction[] Transactions { get => _transactions.ToArray(); }

        public bool Read()
        {
            try
            {
                foreach (EFTransaction item in DBContext.Set<EFTransaction>())
                {
                    if (item.IsDeleted != true) _transactions.Add(new Transaction(item));
                }
                return true;
            }
            catch { throw; }
        }

        public Transaction Get(int id) => _transactions.FirstOrDefault(it => it.Id == id);

        public Transaction Create(TransactionModel model)
        {
            try
            {
                EFTransaction transaction = new EFTransaction()
                {
                    UserId = model.userId,
                    CategoryId = model.categoryId,
                    BudgetId = model.budgetId,
                    Amount = model.amount,
                    Date = model.date,
                    Description = model.description
                };

                DBContext.Add(transaction);
                DBContext.SaveChanges();

                Transaction replicate = new Transaction(transaction);
                _transactions.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public Transaction Update(TransactionModel model)
        {
            try
            {
                EFTransaction _transaction = DBContext.Set<EFTransaction>().FirstOrDefault(it => it.Id == model.id);

                _transaction.UserId = model.userId;
                _transaction.CategoryId = model.categoryId;
                _transaction.BudgetId = model.budgetId;
                _transaction.Amount = model.amount;
                _transaction.Date = model.date;
                _transaction.Description = model.description;

                DBContext.Update(_transaction);

                _transactions.Remove(_transactions.FirstOrDefault(it => it.Id == model.id));
                Transaction replicate = new Transaction(_transaction);
                _transactions.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public bool Delete(int id)
        {
            try
            {

                EFTransaction _transaction = DBContext.Set<EFTransaction>().FirstOrDefault(it => it.Id == id);
                _transaction.IsDeleted = true;
                DBContext.Update(_transaction);

                _transactions.Remove(_transactions.FirstOrDefault(it => it.Id == id));
                return true;

            }
            catch { throw; }
        }
    }
}
