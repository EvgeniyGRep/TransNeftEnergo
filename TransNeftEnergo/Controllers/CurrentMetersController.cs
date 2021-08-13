using System;
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
    public class CurrentMetersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CurrentMetersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CurrentMeters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdNumber>>> GetAll()
        {
            return await _context.CurrentMeters
                .Select(x => new IdNumber { Id = x.Id, Number = x.Number })
                .ToListAsync();
        }

        // GET: api/CurrentMeters/Id
        [HttpGet("{consumptionObjectId}")]
        public async Task<ActionResult<IEnumerable<ExpiredEntityDTO>>> GetAllExpired(int consumptionObjectId)
        {
            return await _context.CurrentMeters
                .Where(x => x.InspectionDate.AddDays(x.InspectionPeriod) < DateTime.Now && x.PowerMeasuringPoint.ConsumptionObject.Id == consumptionObjectId)
                .Select(x => new ExpiredEntityDTO
                {
                    Id = x.Id,
                    Number = x.Number,
                    InspectionDate = x.InspectionDate,
                    ExpiredDate = x.InspectionDate.AddDays(x.InspectionPeriod),
                    Type = x.MeterType
                })
                .ToListAsync();
        }

    }
}
