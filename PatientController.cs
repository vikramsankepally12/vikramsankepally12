using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication1.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly HospitalManagementDbContext _context;

        public PatientController(HospitalManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public IEnumerable<PateintInfo> Get()
        {
           return _context.PateintInfos.ToList();       

        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public PateintInfo Get(int id)
        {
            var pateintInfo = _context.PateintInfos.SingleOrDefault(t => t.PatientID == id);
            if (pateintInfo == null)
            {
                throw new KeyNotFoundException($"No hospital registration found with PatientID = {id}");
            }
            return pateintInfo;
        }

        // POST api/<PatientController>
        [HttpPost]
        public ActionResult<PateintInfo> Post([FromBody] PateintInfo pateintInfo)
        {
            if (pateintInfo == null)
            {
                return BadRequest("Invalid data.");
            }

            _context.PateintInfos.Add(pateintInfo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = pateintInfo.PatientID }, pateintInfo);
        }

      
    }
}
