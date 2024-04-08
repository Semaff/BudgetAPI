using BudgetAPI.Models;

namespace BudgetAPI.Replicates
{
    public class User
    {
        private EFUser Context { get; set; }

        public User(EFUser context)
        {
            Context = context;
        }

        public int Id { get => Context.Id; set => Context.Id = value; }
        public string Username { get => Context.Username; set => Context.Username = value; }
        public string Email { get => Context.Email; set => Context.Email = value; }
    }
}
