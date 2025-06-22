namespace ApiParking.Models
{
    public class BranchModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public int TotalSpots { get; set; }
        public virtual List<VehicleModel> Vehicles  { get; set; } = new List<VehicleModel>();
    }
    public enum Country{
        Brazil = 1,
        Argentina = 2
    }
}
