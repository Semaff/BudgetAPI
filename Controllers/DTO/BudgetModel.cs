using BudgetAPI.Replicates;

namespace BudgetAPI.Controllers.DTO
{
    public class BudgetModel
    {
        public BudgetModel() { }

        public BudgetModel(Budget context)
        {
            id = context.Id;
            userId = context.UserID;
            amount = context.Amount;
        }

        public int id { get; set; }
        public int userId { get; set; }
        public int amount { get; set; }
    }
}
