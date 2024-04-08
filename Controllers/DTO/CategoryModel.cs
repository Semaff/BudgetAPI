using BudgetAPI.Replicates;

namespace BudgetAPI.Controllers.DTO
{
    public class CategoryModel
    {
        public CategoryModel() { }

        public CategoryModel(Category context)
        {
            id = context.Id;
            name = context.Name;
            type = context.Type;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
}
