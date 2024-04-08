using BudgetAPI.Replicates;

namespace BudgetAPI.Controllers.DTO
{
    public class TransactionModel
    {
        public TransactionModel() { }

        public TransactionModel(Transaction context)
        {
            id = context.Id;
            userId = context.UserID;
            categoryId = context.CategoryId;
            budgetId = context.BudgetId;
            amount = context.Amount;
            date = context.Date;
            description = context.Description;
        }

        public int id { get; set; }
        public int userId { get; set; }
        public int categoryId { get; set; }
        public int budgetId { get; set; }
        public int amount { get; set; }
        public string date { get; set; }
        public string description { get; set; }
    }
}
