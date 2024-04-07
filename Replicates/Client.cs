using ElectricalAPI.Models;

namespace ElectricalAPI.Replicates
{
    public class Client
    {
        private EFClient Context { get; set; }
        public Client(EFClient context) { Context = context; }
        public int Id { get => Context.Id; }
        public string Name { get => Context.Name; set => Context.Name = value; }
        public string ContactInfo { get => Context.ContactInfo; set => Context.ContactInfo = value; }
    }
}
