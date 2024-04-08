using BudgetAPI.Managers;
using ElectricalAPI.Managers;
using Microsoft.EntityFrameworkCore;

namespace BudgetAPI.Context
{
    public class ApplicationContext
    {

        public ApplicationContext(IConfiguration config)
        {
            Version = "0.1";
            Title = "BudgetAPI";
            Configuration = config;
            Initialize();
        }

        public void Initialize()
        {
            UserManager = new UserManager(this);
            CategoryManager = new CategoryManager(this);
            TransactionManager = new TransactionManager(this);
            BudgetManager = new BudgetManager(this);

            UserManager.Read();
            CategoryManager.Read();
            TransactionManager.Read();
            BudgetManager.Read();
        }

        public UserManager UserManager { get; set; }
        public CategoryManager CategoryManager { get; set; }
        public TransactionManager TransactionManager { get; set; }
        public BudgetManager BudgetManager { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public IConfiguration Configuration { get; set; }

        public DBContext CreateDbContext() => new DBContext(Configuration.GetConnectionString("DefaultConnection"));

    }
}
