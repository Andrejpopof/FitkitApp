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
    public class ObjektsApiController : ControllerBase
    {
        private readonly FitKitAppContext _context;

        public ObjektsApiController(FitKitAppContext context)
        {
            _context = context;
        }

        // GET: api/ObjektsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objekt>>> GetObjekt()
        {
            return await _context.Objekt.ToListAsync();
        }

        // GET: api/ObjektsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objekt>> GetObjekt(int id)
        {
            var objekt = await _context.Objekt.FindAsync(id);

            if (objekt == null)
            {
                return NotFound();
            }

            return objekt;
        }

        // PUT: api/ObjektsApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjekt(int id, Objekt objekt)
        {
            if (id != objekt.Id)
            {
                return BadRequest();
            }

            _context.Entry(objekt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjektExists(id))
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

        // POST: api/ObjektsApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Objekt>> PostObjekt(Objekt objekt)
        {
            _context.Objekt.Add(objekt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjekt", new { id = objekt.Id }, objekt);
        }

        // DELETE: api/ObjektsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Objekt>> DeleteObjekt(int id)
        {
            var objekt = await _context.Objekt.FindAsync(id);
            if (objekt == null)
            {
                return NotFound();
            }

            _context.Objekt.Remove(objekt);
            await _context.SaveChangesAsync();

            return objekt;
        }

        private bool ObjektExists(int id)
        {
            return _context.Objekt.Any(e => e.Id == id);
        }
    }
}
