using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitKitApp.Data;
using FitKitApp.Models;

namespace FitKitApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZaclenuvanjesApiController : ControllerBase
    {
        private readonly FitKitAppContext _context;

        public ZaclenuvanjesApiController(FitKitAppContext context)
        {
            _context = context;
        }

        // GET: api/ZaclenuvanjesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zaclenuvanje>>> GetZaclenuvanje()
        {
            return await _context.Zaclenuvanje.ToListAsync();
        }

        // GET: api/ZaclenuvanjesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zaclenuvanje>> GetZaclenuvanje(int id)
        {
            var zaclenuvanje = await _context.Zaclenuvanje.FindAsync(id);

            if (zaclenuvanje == null)
            {
                return NotFound();
            }

            return zaclenuvanje;
        }

        // PUT: api/ZaclenuvanjesApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZaclenuvanje(int id, Zaclenuvanje zaclenuvanje)
        {
            if (id != zaclenuvanje.Id)
            {
                return BadRequest();
            }

            _context.Entry(zaclenuvanje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZaclenuvanjeExists(id))
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

        // POST: api/ZaclenuvanjesApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Zaclenuvanje>> PostZaclenuvanje(Zaclenuvanje zaclenuvanje)
        {
            _context.Zaclenuvanje.Add(zaclenuvanje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZaclenuvanje", new { id = zaclenuvanje.Id }, zaclenuvanje);
        }

        // DELETE: api/ZaclenuvanjesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Zaclenuvanje>> DeleteZaclenuvanje(int id)
        {
            var zaclenuvanje = await _context.Zaclenuvanje.FindAsync(id);
            if (zaclenuvanje == null)
            {
                return NotFound();
            }

            _context.Zaclenuvanje.Remove(zaclenuvanje);
            await _context.SaveChangesAsync();

            return zaclenuvanje;
        }

        private bool ZaclenuvanjeExists(int id)
        {
            return _context.Zaclenuvanje.Any(e => e.Id == id);
        }
    }
}
