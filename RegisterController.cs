using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
//ing Microsoft.EntityFrameworkCore.t//
using WebApplication1.Model;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   //[Authorize]
    public class RegisterController : ControllerBase
    {
        private readonly HospitalManagementDbContext _context;

        public RegisterController(HospitalManagementDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<HospitalRegistration> Get() => _context.HospitalRegistrations.ToList();



        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public HospitalRegistration Get(int id)
        {
            var hospitalRegistration = _context.HospitalRegistrations.SingleOrDefault(t => t.PatientID == id);
            if (hospitalRegistration == null)
            {
                throw new KeyNotFoundException($"No hospital registration found with PatientID = {id}");
            }
            return hospitalRegistration;
        }

        [HttpPost]
        public  ActionResult<HospitalRegistration> Post([FromBody] HospitalRegistration registration)
        {
            if (registration == null)
            {
                return BadRequest("Invalid data.");
            }

            _context.HospitalRegistrations.Add(registration);
             _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = registration.PatientID }, registration);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HospitalRegistration updatedRegistration)
        {
            if (id != updatedRegistration.PatientID)
            {
                return BadRequest("Patient ID mismatch.");
            }

            var existingRegistration =  _context.HospitalRegistrations.Find(id);
            if (existingRegistration == null)
            {
                return NotFound();
            }

            // Update properties
            existingRegistration.FirstName = updatedRegistration.FirstName;
            existingRegistration.Age = updatedRegistration.Age;
            existingRegistration.LastName = updatedRegistration.LastName;

            _context.Entry(existingRegistration).State = EntityState.Modified;
             _context.SaveChanges();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var registration =  _context.HospitalRegistrations.Find(id);
            if (registration == null)
            {
                return NotFound();
            }

            _context.HospitalRegistrations.Remove(registration);
             _context.SaveChanges();

            return NoContent();
        }
    }
}

        
   
