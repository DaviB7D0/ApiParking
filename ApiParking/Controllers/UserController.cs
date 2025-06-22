using Microsoft.AspNetCore.Mvc;
using ApiParking.Models;
using ApiParking.Data;
using Microsoft.EntityFrameworkCore;
using ApiParking.DTOs.User;

namespace ApiParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

       

        // POST => C in CRUD: 
        [HttpPost]
        public  ActionResult Create([FromBody] CreateUserDTO userDTO)
        {
            var user = new UserModel
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                PasswordHash = userDTO.PasswordHash,
                Role = userDTO.Role
            };
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return Ok("User created sucessfully!");
        }

        // GET => R in CRUD 
        [HttpGet]
        public ActionResult<List<UserResponseDTO>> GetAll()
        {
            var users = _dataContext.Users.ToList();
            var usersDTOResponse = new List<UserResponseDTO>();
            
            foreach (var user in users) 
            {
                var userTDO = new UserResponseDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Role = user.Role
                };

                usersDTOResponse.Add(userTDO);
            }

            return Ok(usersDTOResponse);
        }

        // GET (specific) => R² in CRUD
        [HttpGet("{id}")]
        public ActionResult<UserResponseDTO> Get(int id) {
            var user = _dataContext.Users.Find(id);
            if(user == null)
                return NotFound("User not found!");
            var userResponseDTO = new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
            return Ok(userResponseDTO);            
        }

        // PUT => U in CRUD
        [HttpPut]
        public ActionResult Update([FromBody] UserResponseDTO userDTO) {
            var user = _dataContext.Users.Find(userDTO.Id);
            if (user == null)
                return NotFound("User not found!");
            user.Name = userDTO.Name;
            user.Email = userDTO.Email;
            user.Role = userDTO.Role;

            _dataContext.Update(user);
            _dataContext.SaveChanges();
            return Ok("User updated successfully!");
        }

        // DELETE => D in CRUD
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _dataContext.Users.Find(id);
            if (user == null)
                return NotFound("User not found!");


            _dataContext.Users.Remove(user);
            _dataContext.SaveChanges();
            return Ok("User deleted successfully!");
        }

    }
}
