using BudgetAPI.Context;
using BudgetAPI.Controllers.DTO;
using BudgetAPI.Models;
using BudgetAPI.Replicates;

namespace ElectricalAPI.Managers
{
    public class UserManager
    {
        protected ApplicationContext ApplicationContext { get; set; }
        protected DBContext DBContext { get; set; }
        public UserManager(ApplicationContext applicationContext) { ApplicationContext = applicationContext; DBContext = applicationContext.CreateDbContext(); }

        private List<User> _users { get; set; } = new List<User>();

        public User[] Users { get => _users.ToArray(); }
        public bool Read()
        {
            try
            {
                foreach (EFUser item in DBContext.Users)
                {
                    if (item.IsDeleted != true) _users.Add(new User(item));
                }
                return true;
            }
            catch { throw; }
        }

        public User Get(int id) => _users.FirstOrDefault(it => it.Id == id);

        public User Create(UserModel model)
        {
            try
            {
                EFUser user = new EFUser()
                {
                    Username = model.username,
                    Email = model.email,
                };

                DBContext.Add(user);
                DBContext.SaveChanges();

                User replicate = new User(user);
                _users.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public User Update(UserModel model)
        {
            try
            {
                EFUser _user = DBContext.Users.FirstOrDefault(it => it.Id == model.id);

                _user.Username = model.username;
                _user.Email = model.email;

                DBContext.Update(_user);

                _users.Remove(_users.FirstOrDefault(it => it.Id == model.id));
                User replicate = new User(_user);
                _users.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public bool Delete(int id)
        {
            try
            {

                EFUser _user = DBContext.Users.FirstOrDefault(it => it.Id == id);
                _user.IsDeleted = true;
                DBContext.Update(_user);

                _users.Remove(_users.FirstOrDefault(it => it.Id == id));
                return true;

            }
            catch { throw; }
        }
    }
}
