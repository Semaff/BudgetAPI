using ElectricalAPI.Models;

namespace ElectricalAPI.Replicates
{
    public class Worker
    {

        public EFWorker Context { get; set; }
        public Worker(EFWorker context) { Context = context; }

        public int Id { get => Context.Id; }
        public string Name { get => Context.Name; set => Context.Name = value; }
        public string Position { get => Context.Position; set => Context.Position = value; }
        public string ContactInfo { get => Context.ContactInfo; set => Context.ContactInfo = value; }
    }
}
