using ElectricalAPI.Context;
using ElectricalAPI.Replicates;

namespace ElectricalAPI.Controllers.DTO
{
    public class ProjectModel
    {
        public ProjectModel() { }
        public ProjectModel(Project context)
        {
            id = context.Id;
            name = context.Name;
            clientId = context.ClientId;
            workerId = context.WorkerId;
            startDate = context.StartDate;
            endDate = context.EndDate;
            status = context.Status;
        }

        public int id { get; set; }
        public string name { get; set; }
        public int clientId { get; set; }
        public int workerId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string status { get; set; }
    }
}
