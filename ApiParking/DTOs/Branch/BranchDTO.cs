using ApiParking.Models;

namespace ApiParking.DTOs.Branch
{
    public class BranchDTO
    {
        public string Name { get; set; }
        public Country Country { get; set; }
        public int TotalSpot { get; set; }
    }
}
