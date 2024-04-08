using BudgetAPI.Replicates;

namespace BudgetAPI.Controllers.DTO
{
    public class UserModel
    {
        public UserModel() { }

        public UserModel(User context)
        {
            id = context.Id;
            username = context.Username;
            email = context.Email;
        }

        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
    }
}
