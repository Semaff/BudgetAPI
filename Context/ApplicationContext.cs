using ElectricalAPI.Managers;
using Microsoft.EntityFrameworkCore;

namespace ElectricalAPI.Context
{
    public class ApplicationContext
    {

        public ApplicationContext(IConfiguration config)
        {
            Version = "0.1";
            Title = "ElectricalAPI";
            Configuration = config;
            Initialize();
        }

        public void Initialize()
        {

            /*Инициализация менеджеров*/
            ProjectManager = new ProjectManager(this);
            ClientManager = new ClientManager(this);
            WorkerManager = new WorkerManager(this);

            ProjectManager.Read();
            ClientManager.Read();
            WorkerManager.Read();

        }

        public ProjectManager ProjectManager { get; set; }
        public ClientManager ClientManager { get; set; }
        public WorkerManager WorkerManager { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public IConfiguration Configuration { get; set; }

        public DBContext CreateDbContext() => new DBContext(Configuration.GetConnectionString("DefaultConnection"));

    }
}
