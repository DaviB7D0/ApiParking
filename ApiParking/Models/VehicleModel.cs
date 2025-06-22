namespace ApiParking.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }
        public string? Year { get; set; }
        public string? Color { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; } 
        public int BranchModelId { get; set; }
        public virtual BranchModel BranchModel { get; set; }

    }
}
