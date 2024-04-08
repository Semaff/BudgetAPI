using BudgetAPI.Models;

namespace BudgetAPI.Replicates
{
    public class Transaction
    {
        private EFTransaction Context { get; set; }

        public Transaction(EFTransaction context)
        {
            Context = context;
        }

        public int Id { get => Context.Id; set => Context.Id = value; }
        public int UserID { get => Context.UserId; set => Context.UserId = value; }
        public int CategoryId { get => Context.CategoryId; set => Context.CategoryId = value; }
        public int BudgetId { get => Context.BudgetId; set => Context.BudgetId = value; }
        public int Amount { get => Context.Amount; set => Context.Amount = value; }
        public string Date { get => Context.Date; set => Context.Date = value; }
        public string Description { get => Context.Description; set => Context.Description = value; }
    }
}
