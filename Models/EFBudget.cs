namespace BudgetAPI.Models
{
    public class EFBudget : EFBaseModel
    {
        public int UserId { get; set; }
        public int Amount { get; set; }
    }
}
