using BudgetAPI.Models;

namespace BudgetAPI.Replicates
{
    public class Budget
    {
        private EFBudget Context { get; set; }

        public Budget(EFBudget context)
        {
            Context = context;
        }

        public int Id { get => Context.Id; set => Context.Id = value; }
        public int UserID { get => Context.UserId; set => Context.UserId = value; }
        public int Amount { get => Context.Amount; set => Context.Amount = value; }
    }
}
