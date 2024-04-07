using ElectricalAPI.Models;

namespace ElectricalAPI.Replicates
{
    public class Project
    {

        public EFProject Context { get; set; }
        public Project(EFProject context) { Context = context; }

        public int Id { get => Context.Id; }
        public string Name { get => Context.Name; set => Context.Name = value; }
        public int ClientId { get => Context.ClientID; set => Context.ClientID = value; }
        public int WorkerId { get => Context.WorkerId; set => Context.WorkerId = value; }
        public DateTime StartDate { get => Context.StartDate; set => Context.StartDate = value; }
        public DateTime EndDate { get => Context.EndDate; set => Context.EndDate = value; }
        public string Status { get => Context.Status; set => Context.Status = value; }
    }
}
