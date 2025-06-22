namespace ApiParking.DTOs.Vehicle
{
    public class VehicleDTO
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; } 
        public int BranchId { get; set; }
        
    }
}
