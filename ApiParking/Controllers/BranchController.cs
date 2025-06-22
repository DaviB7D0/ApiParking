using Microsoft.AspNetCore.Mvc;
using ApiParking.Models;
using ApiParking.Data;
using Microsoft.EntityFrameworkCore;
using ApiParking.DTOs.Branch;

namespace ApiParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public BranchController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // POST => C in CRUD: 
        [HttpPost]
        public ActionResult Create([FromBody] BranchDTO branchDTO)
        {
            var branch = new BranchModel
            {
                Country = branchDTO.Country,
                Name = branchDTO.Name,
                TotalSpots = branchDTO.TotalSpot,
                Vehicles = new List<VehicleModel>()
            };

            _dataContext.Branches.Add(branch);
            _dataContext.SaveChanges();
            return Ok("Branch created sucessfully!");
        }

        // GET => R in CRUD 
        [HttpGet]
        public ActionResult<List<BranchResponseDTO>> GetAll()
        {
            var branches = _dataContext.Branches.ToList();

            var branchesDTOResponse = new List<BranchResponseDTO>();

            foreach(var branch in branches)
            {
                var branchDTO = new BranchResponseDTO
                {
                    Id = branch.Id,
                    Name = branch.Name,
                    Country = branch.Country,
                    TotalSpot = branch.TotalSpots
                };

                branchesDTOResponse.Add(branchDTO);
            }

            return Ok(branchesDTOResponse);
        }

        // GET (specific) => R² in CRUD
        [HttpGet("{id}")]
        public ActionResult<BranchResponseDTO> Get(int id)
        {
            var branch = _dataContext.Branches.Find(id);
            
            if (branch == null)
                return NotFound("Branch not found!");

            var branchResponseDTO = new BranchResponseDTO
            {
                Id = branch.Id,
                Name = branch.Name,
                Country = branch.Country,
                TotalSpot = branch.TotalSpots
            };

            return Ok(branchResponseDTO);
        }

        // PUT => U in CRUD
        [HttpPut]
        public ActionResult Update([FromBody] BranchUpdateDTO branchDTO)
        {
            var branch = _dataContext.Branches.Find(branchDTO.Id);
            if (branch == null)
                return NotFound("Branch not found!");

            branch.Name = branchDTO.Name;
            branch.Country = branchDTO.Country;
            branch.TotalSpots = branchDTO.TotalSpot;

            _dataContext.Update(branch);
            _dataContext.SaveChanges();
            return Ok("Branch updated successfully!");
        }

        // DELETE => D in CRUD
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var branch = _dataContext.Branches.Find(id);
            if (branch == null)
                return NotFound("Branch not found!");

            _dataContext.Branches.Remove(branch);
            _dataContext.SaveChanges();

            return Ok("Branch deleted successfully!");
        }

    }
}
