using ElectricalAPI.Context;
using ElectricalAPI.Controllers.DTO;
using ElectricalAPI.Models;
using ElectricalAPI.Replicates;
using Microsoft.EntityFrameworkCore;

namespace ElectricalAPI.Managers
{
    public class WorkerManager
    {
        protected ApplicationContext ApplicationContext { get; set; }
        protected DBContext DBContext { get; set; }
        public WorkerManager(ApplicationContext applicationContext) { ApplicationContext = applicationContext; DBContext = applicationContext.CreateDbContext(); }

        private List<Worker> _workers { get; set; } = new List<Worker>();

        public Worker[] Workers { get => _workers.ToArray(); }
        public bool Read()
        {
            try
            {
                foreach (EFWorker item in DBContext.Workers)
                {
                    if (item.IsDeleted != true) _workers.Add(new Worker(item));
                }
                return true;
            }
            catch { throw; }
        }

        public Worker Get(int id) => _workers.FirstOrDefault(it => it.Id == id);

        public Worker Create(WorkerModel model)
        {
            try
            {
                EFWorker worker = new EFWorker()
                {
                    Name = model.name,
                    Position = model.position,
                    ContactInfo = model.contactInfo,
                };

                DBContext.Add(worker);
                DBContext.SaveChanges();

                Worker replicate = new Worker(worker);
                _workers.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public Worker Update(WorkerModel model)
        {
            try
            {
                EFWorker _worker = DBContext.Workers.FirstOrDefault(it => it.Id == model.id);

                _worker.Name = model.name;
                _worker.Position = model.position;
                _worker.ContactInfo = model.contactInfo;

                DBContext.Update(_worker);

                _workers.Remove(_workers.FirstOrDefault(it => it.Id == model.id));
                Worker replicate = new Worker(_worker);
                _workers.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public bool Delete(int id)
        {
            try
            {

                EFWorker _worker = DBContext.Workers.FirstOrDefault(it => it.Id == id);
                _worker.IsDeleted = true;
                DBContext.Update(_worker);

                _workers.Remove(_workers.FirstOrDefault(it => it.Id == id));
                return true;

            }
            catch { throw; }
        }
    }
}
