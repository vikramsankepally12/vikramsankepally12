using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorInfoController : ControllerBase
    {
        private readonly HospitalManagementDbContext _context;

        public DoctorInfoController(HospitalManagementDbContext context)
        {
            _context = context;
        }
        // GET: api/<DoctorInfoController>
        [HttpGet]
        public IEnumerable<Doctor> Get()
        {

            return _context.Doctors.ToList();
        }

        // GET api/<DoctorInfoController>/5
        [HttpGet("{id}")]
        public Doctor Get(int id)
        {
            var doctor = _context.Doctors.SingleOrDefault(t => t.DoctorId == id);
            if (doctor == null)
            {
                throw new KeyNotFoundException($"No hospital registration found with PatientID = {id}");
            }
            return doctor;
        }

        // POST api/<DoctorInfoController>
        [HttpPost]
        public ActionResult<Doctor> Post([FromBody] Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest("Invalid data.");
            }

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = doctor.DoctorId }, doctor);
        }

       
       
    }
}
