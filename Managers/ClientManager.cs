using ElectricalAPI.Context;
using ElectricalAPI.Controllers.DTO;
using ElectricalAPI.Models;
using ElectricalAPI.Replicates;
using Microsoft.EntityFrameworkCore;

namespace ElectricalAPI.Managers
{
    public class ClientManager
    {
        protected ApplicationContext ApplicationContext { get; set; }
        protected DBContext DBContext { get; set; }
        public ClientManager(ApplicationContext applicationContext) { ApplicationContext = applicationContext; DBContext = applicationContext.CreateDbContext(); }

        private List<Client> _clients { get; set; } = new List<Client>();

        public Client[] Clients { get => _clients.ToArray(); }
        public bool Read()
        {
            try
            {
                foreach (EFClient item in DBContext.Clients)
                {
                    if (item.IsDeleted != true) _clients.Add(new Client(item));
                }
                return true;
            }
            catch { throw; }
        }

        public Client Get(int id) => _clients.FirstOrDefault(it => it.Id == id);

        public Client Create(ClientModel model)
        {
            try
            {
                EFClient client = new EFClient()
                {
                    Name = model.name,
                    ContactInfo = model.contactInfo,
                };

                DBContext.Add(client);
                DBContext.SaveChanges();

                Client replicate = new Client(client);
                _clients.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public Client Update(ClientModel model)
        {
            try
            {
                EFClient _client = DBContext.Clients.FirstOrDefault(it => it.Id == model.id);

                _client.Name = model.name;
                _client.ContactInfo = model.contactInfo;

                DBContext.Update(_client);

                _clients.Remove(_clients.FirstOrDefault(it => it.Id == model.id));
                Client replicate = new Client(_client);
                _clients.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public bool Delete(int id)
        {
            try
            {

                EFClient _client = DBContext.Clients.FirstOrDefault(it => it.Id == id);
                _client.IsDeleted = true;
                DBContext.Update(_client);

                _clients.Remove(_clients.FirstOrDefault(it => it.Id == id));
                return true;

            }
            catch { throw; }
        }
    }
}
