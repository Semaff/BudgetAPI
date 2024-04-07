using ElectricalAPI.Replicates;

namespace ElectricalAPI.Controllers.DTO
{
    public class ClientModel
    {
        public ClientModel() { }
        public ClientModel(Client context)
        {
            id = context.Id;
            name = context.Name;
            contactInfo = context.ContactInfo;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string contactInfo { get; set; }
    }
}
