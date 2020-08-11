using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitKitApp.Data;
using FitKitApp.Models;
using FitKitApp.ViewModels;

namespace FitKitApp.Controllers
{
    public class ObjektsController : Controller
    {
        private readonly FitKitAppContext _context;

        public ObjektsController(FitKitAppContext context)
        {
            _context = context;
        }

        // GET: Objekts
        public async Task<IActionResult> Index(string searchStringImeObjekt , string searchStringTipVezbanje)
        {
            IQueryable<Objekt> objekts = _context.Objekt.AsQueryable();
            IQueryable<string> queryString = _context.Objekt.OrderBy(m => m.TipVezbanje).Select(m => m.TipVezbanje).Distinct();
            if(!string.IsNullOrEmpty(searchStringImeObjekt))
            {
                objekts = objekts.Where(m => m.Ime.Contains(searchStringImeObjekt));
            }
            if (!string.IsNullOrEmpty(searchStringTipVezbanje))
            {
                objekts = objekts.Where(m => m.TipVezbanje == searchStringTipVezbanje);
            }
            objekts = objekts.Include(m => m.Coach1).Include(m => m.Coach2);


            var objektSearchVM = new ObjektSeachViewModel
            {
                Objekts = await objekts.ToListAsync(),
                TipoviVezbanje = new SelectList(await queryString.ToListAsync())
            };

            
            return View(objektSearchVM);
        }

        // GET: Objekts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objekt = await _context.Objekt
                .Include(o => o.Coach1)
                .Include(o => o.Coach2)
                .FirstOrDefaultAsync(m => m.Id == id);

            ViewData["imeObjekt"] = objekt.Ime;
            if (objekt == null)
            {
                return NotFound();
            }

            return View(objekt);
        }

        // GET: Objekts/Create
        public IActionResult Create()
        {
            ViewData["Coach1Id"] = new SelectList(_context.Coach, "Id", "FullName");
            ViewData["Coach2Id"] = new SelectList(_context.Coach, "Id", "FullName");
            return View();
        }

        // POST: Objekts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Kvadratura,Lokacija,MaxClients,TipVezbanje,OtvorZatvor,Coach1Id,Coach2Id")] Objekt objekt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objekt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Coach1Id"] = new SelectList(_context.Coach, "Id", "FullName", objekt.Coach1Id);
            ViewData["Coach2Id"] = new SelectList(_context.Coach, "Id", "FullName", objekt.Coach2Id);
            return View(objekt);
        }

        // GET: Objekts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objekt = await _context.Objekt.FindAsync(id);
            if (objekt == null)
            {
                return NotFound();
            }
            ViewData["Coach1Id"] = new SelectList(_context.Coach, "Id", "FullName", objekt.Coach1Id);
            ViewData["Coach2Id"] = new SelectList(_context.Coach, "Id", "FullName", objekt.Coach2Id);
            return View(objekt);
        }

        // POST: Objekts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Kvadratura,Lokacija,MaxClients,TipVezbanje,OtvorZatvor,Coach1Id,Coach2Id")] Objekt objekt)
        {
            if (id != objekt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objekt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjektExists(objekt.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Coach1Id"] = new SelectList(_context.Coach, "Id", "FullName", objekt.Coach1Id);
            ViewData["Coach2Id"] = new SelectList(_context.Coach, "Id", "FullName", objekt.Coach2Id);
            return View(objekt);
        }

        // GET: Objekts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objekt = await _context.Objekt
                .Include(o => o.Coach1)
                .Include(o => o.Coach2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objekt == null)
            {
                return NotFound();
            }

            return View(objekt);
        }

        // POST: Objekts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objekt = await _context.Objekt.FindAsync(id);
            _context.Objekt.Remove(objekt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjektExists(int id)
        {
            return _context.Objekt.Any(e => e.Id == id);
        }
    }
}
