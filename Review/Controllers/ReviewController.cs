using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using RepositoryLayer.EmployeeEntity;


// Check lsadjflsakjdhf
namespace Review.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IEmployeeBL _employeeBL;

        // Constructor Injection
        public ReviewController(IEmployeeBL employeeBL)
        {
            _employeeBL = employeeBL;
        }

        [HttpGet]
        public IActionResult test()
        {
            throw new Exception("Exception cathed");
        }
        [HttpPost("add")]
        public IActionResult AddEmployee([FromBody] RequestModel request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name) ||
                string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Department))
            {
                return BadRequest("All fields (Name, Email, Department) are required.");
            }

            var employee = new Employee
            {
                Name = request.Name,
                Email = request.Email,
                Department = request.Department
            };

            var result = _employeeBL.AddEmployee(employee);

            if (result == null)
            {
                return StatusCode(500, "Failed to add employee. Please try again.");
            }

            return Ok(new { Message = "Employee added successfully", Data = result });
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] RequestModel request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name) ||
                string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Department))
            {
                return BadRequest("All fields (Name, Email, Department) are required.");
            }

            var updatedEmployee = _employeeBL.UpdateEmployee(id, new Employee
            {
                Name = request.Name,
                Email = request.Email,
                Department = request.Department
            });

            if (updatedEmployee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            return Ok(new { Message = "Employee updated successfully", Data = updatedEmployee });
        }
    }
}
