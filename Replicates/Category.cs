using BudgetAPI.Models;

namespace BudgetAPI.Replicates
{
    public class Category
    {
        private EFCategory Context { get; set; }

        public Category(EFCategory context)
        {
            Context = context;
        }

        public int Id { get => Context.Id; set => Context.Id = value; }
        public string Name { get => Context.Name; set => Context.Name = value; }
        public string Type { get => Context.Type; set => Context.Type = value; }
    }
}