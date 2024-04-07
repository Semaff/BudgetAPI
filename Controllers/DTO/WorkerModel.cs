using ElectricalAPI.Replicates;

namespace ElectricalAPI.Controllers.DTO
{
    public class WorkerModel
    {
        public WorkerModel() { }
        public WorkerModel(Worker context)
        {
            id = context.Id;
            name = context.Name;
            position = context.Position;
            contactInfo = context.ContactInfo;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string contactInfo { get; set; }
    }
}
