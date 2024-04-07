namespace ElectricalAPI.Models
{
    public class EFProject : EFBaseModel
    {
        public string Name { get; set; }
        public int ClientID { get; set; }
        public int WorkerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
