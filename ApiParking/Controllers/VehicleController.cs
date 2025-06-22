using ApiParking.Data;
using ApiParking.DTOs.Vehicle;
using ApiParking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public VehicleController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        // POST => C in CRUD: 
        [HttpPost]
        public ActionResult Create([FromBody] VehicleDTO vehicleDTO)
        {
            var branch = _dataContext.Branches.Find(vehicleDTO.BranchId);

            if (branch == null)
                return NotFound("Branch not found!");

            else if (branch.TotalSpots == branch.Vehicles.Count())
                return BadRequest("Branch with out spots!");

            var vehicle = new VehicleModel
            {
                Color = vehicleDTO.Color,
                EntryTime = DateTime.Now,
                BranchModelId = branch.Id,
                Model = vehicleDTO.Model,
                Name = vehicleDTO.Name,
                Year = vehicleDTO.Year
            };

            _dataContext.Vehicles.Add(vehicle);
            _dataContext.SaveChanges();
            return Ok("Vehicle registered sucessfully!");
        }

        // GET => R in CRUD 
        [HttpGet]
        public ActionResult<List<VehicleResponseDTO>> GetAll()
        {
            var vehicles = _dataContext.Vehicles.ToList();

            var vehiclesDTOResponse = new List<VehicleResponseDTO>();
            
            foreach (var vehicle in vehicles) 
            {

                var vehicleDTO = new VehicleResponseDTO
                {
                    Id = vehicle.Id,
                    Name = vehicle.Name,
                    Color = vehicle.Color,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    EntryTime = DateTime.Now,
                    BranchId = vehicle.BranchModelId

                };
                vehiclesDTOResponse.Add(vehicleDTO);
            }
            return Ok(vehiclesDTOResponse);
        }

        // GET (specific) => R² in CRUD
        [HttpGet("{id}")]
        public ActionResult<VehicleResponseDTO> Get(int id)
        {
            var vehicle = _dataContext.Vehicles.Find(id);

            if (vehicle == null)
                return NotFound("Vehicle not found!");

            var vehicleResponseDTO = new VehicleResponseDTO 
            { 
                Id = vehicle.Id,
                Name = vehicle.Name,
                Model = vehicle.Model,
                Year = vehicle.Year,
                Color = vehicle.Color,
                BranchId = vehicle.BranchModelId
            };

            return Ok(vehicleResponseDTO);
        }

        // PUT => U in CRUD
        [HttpPut]
        public ActionResult Update([FromBody] VehicleUptadeDTO vehicleUptadeDTO)
        {
            var vehicle = _dataContext.Vehicles.Find(vehicleUptadeDTO.Id);
            if (vehicle == null)
                return NotFound("Vehicle not found!");

            vehicle.Name = vehicleUptadeDTO.Name;
            vehicle.Model = vehicleUptadeDTO.Model;
            vehicle.Year = vehicleUptadeDTO.Year;
            vehicle.Color = vehicleUptadeDTO.Color;

            _dataContext.Update(vehicle);
            _dataContext.SaveChanges();
            return Ok("Vehicle updated successfully!");
        }

        // DELETE => D in CRUD
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var vehicle = _dataContext.Vehicles.Find(id);
            if (vehicle == null)
                return NotFound("Vehicle not found!");

            _dataContext.Vehicles.Remove(vehicle);
            _dataContext.SaveChanges();
            
            return Ok("Vehicle removed successfully!");
        }

    }
}
