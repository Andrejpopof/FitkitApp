﻿using System;
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
    public class CoachesApiController : ControllerBase
    {
        private readonly FitKitAppContext _context;

        public CoachesApiController(FitKitAppContext context)
        {
            _context = context;
        }

        // GET: api/CoachesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coach>>> GetCoach()
        {
            return await _context.Coach.ToListAsync();
        }

        // GET: api/CoachesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coach>> GetCoach(int id)
        {
            var coach = await _context.Coach.FindAsync(id);

            if (coach == null)
            {
                return NotFound();
            }

            return coach;
        }

        // PUT: api/CoachesApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoach(int id, Coach coach)
        {
            if (id != coach.Id)
            {
                return BadRequest();
            }

            _context.Entry(coach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachExists(id))
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

        // POST: api/CoachesApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Coach>> PostCoach(Coach coach)
        {
            _context.Coach.Add(coach);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoach", new { id = coach.Id }, coach);
        }

        // DELETE: api/CoachesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Coach>> DeleteCoach(int id)
        {
            var coach = await _context.Coach.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }

            _context.Coach.Remove(coach);
            await _context.SaveChangesAsync();

            return coach;
        }

        private bool CoachExists(int id)
        {
            return _context.Coach.Any(e => e.Id == id);
        }
    }
}
