using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TelemetricsController : ControllerBase
    {
        private readonly EfContext _context;
        private readonly ITelemetricsService _telemetricsService;

        public TelemetricsController(EfContext context, ITelemetricsService telemetricsService)
        {
            _context = context;
            _telemetricsService = telemetricsService;
            Task.Run(() => GetTelemetricsAsync()).Wait();
        }

        private async Task GetTelemetricsAsync()
        {
            if (_context.Telemetrics.Count() == 0 || _context.Telemetrics == null)
            {
                List<Telemetrics> telemetrics = await _telemetricsService.GetTelemetricsAsync();
                _context.Telemetrics.AddRange(telemetrics);
                _context.SaveChanges();
            }
        }

        // GET: api/Telemetrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telemetrics>>> GetTelemetrics()
        {
            return await _context.Telemetrics.ToListAsync();
        }

        // GET: api/Telemetrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telemetrics>> GetTelemetrics(int id)
        {
            var telemetrics = await _context.Telemetrics.FindAsync(id);

            if (telemetrics == null)
            {
                return NotFound();
            }

            return telemetrics;
        }

        // PUT: api/Telemetrics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelemetrics(int id, Telemetrics telemetrics)
        {
            if (id != telemetrics.Id)
            {
                return BadRequest();
            }

            _context.Entry(telemetrics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelemetricsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Telemetrics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Telemetrics>> PostTelemetrics(Telemetrics telemetrics)
        {
            _context.Telemetrics.Add(telemetrics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelemetrics", new { id = telemetrics.Id }, telemetrics);
        }

        // DELETE: api/Telemetrics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelemetrics(int id)
        {
            var telemetrics = await _context.Telemetrics.FindAsync(id);
            if (telemetrics == null)
            {
                return NotFound();
            }

            _context.Telemetrics.Remove(telemetrics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelemetricsExists(int id)
        {
            return _context.Telemetrics.Any(e => e.Id == id);
        }
    }
}
