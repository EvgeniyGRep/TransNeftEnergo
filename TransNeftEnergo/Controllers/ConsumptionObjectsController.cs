using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransNeftEnergo.DTO;

namespace TransNeftEnergo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionObjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConsumptionObjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ConsumptionObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdName>>> GetConsumptionObjects()
        {
            return await _context.ConsumptionObjects
                .Select(x => new IdName { Id = x.Id, Name = x.Name })
                .ToListAsync();
        }
    }
}
