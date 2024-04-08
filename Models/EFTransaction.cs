namespace BudgetAPI.Models
{
    public class EFTransaction : EFBaseModel
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int BudgetId { get; set; }
        public int Amount { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
