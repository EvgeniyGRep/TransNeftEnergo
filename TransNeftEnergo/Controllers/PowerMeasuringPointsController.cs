using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TransNeftEnergo.DTO;
using TransNeftEnergo.Models;

namespace TransNeftEnergo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerMeasuringPointsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PowerMeasuringPointsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PowerMeasuringPoints/id
        [HttpGet("{id}")]
        public async Task<ActionResult<PowerMeasuringPoint>> Get(int id)
        {
            return await _context.PowerMeasuringPoints
                .Include(x=>x.CurrentTransformer)
                .Include(x=>x.CurrentMeter)
                .Include(x=>x.VoltageTransformer)
                .SingleOrDefaultAsync(x => x.Id == id);

        }
        // POST: api/PowerMeasuringPoints
        [HttpPost]
        public async Task<ActionResult<PowerMeasuringPoint>> Add(PostPowerMeasuringPointParam powerMeasuringPoint)
        {
            var meter = _context.CurrentMeters.SingleOrDefault(x => x.Id == powerMeasuringPoint.CurrentMeterId);
            var currentTransformer = _context.CurrentTransformers.SingleOrDefault(x => x.Id == powerMeasuringPoint.CurrentTransformerId);
            var voltageTransformer = _context.VoltageTransformers.SingleOrDefault(x => x.Id == powerMeasuringPoint.VoltageTransformerId);
            var consumptionObject = _context.ConsumptionObjects.SingleOrDefault(x => x.Id == powerMeasuringPoint.ConsumptionObjectId);

            var newEntity = new PowerMeasuringPoint
            {
                Name = powerMeasuringPoint.Name,
                CurrentMeter = meter,
                CurrentTransformer = currentTransformer,
                VoltageTransformer = voltageTransformer, 
                ConsumptionObject = consumptionObject
            };
            
            _context.PowerMeasuringPoints.Add(newEntity);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = newEntity.Id }, newEntity);
        }

    }
}
