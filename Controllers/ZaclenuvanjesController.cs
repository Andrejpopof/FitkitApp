using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitKitApp.Data;
using FitKitApp.Models;
using System.Collections.Immutable;
using FitKitApp.ViewModels;
using SQLitePCL;

namespace FitKitApp.Controllers
{
    public class ZaclenuvanjesController : Controller
    {
        private readonly FitKitAppContext _context;

        public ZaclenuvanjesController(FitKitAppContext context)
        {
            _context = context;
        }

        // GET: Zaclenuvanjes
        public async Task<IActionResult> Index(string searchStringImeKorisnik, string searchStringImeObjekt , string searchStringStatus)
        {
            IQueryable<Zaclenuvanje> zaclenuvanja = _context.Zaclenuvanje.AsQueryable();
            IQueryable<string> queryString = _context.Zaclenuvanje.OrderBy(m => m.OdobrenNeodobren).Select(m => m.OdobrenNeodobren).Distinct();

            if (!string.IsNullOrEmpty(searchStringImeKorisnik))
            {
                zaclenuvanja = zaclenuvanja.Where(m => m.User.Ime.Contains(searchStringImeKorisnik));
            }
            if(!string.IsNullOrEmpty(searchStringImeObjekt))
            {
                zaclenuvanja = zaclenuvanja.Where(m => m.Objekt.Ime.Contains(searchStringImeObjekt));
            }    
            if(!string.IsNullOrEmpty(searchStringStatus))
            {
                zaclenuvanja = zaclenuvanja.Where(m => m.OdobrenNeodobren == searchStringStatus);
            }
            zaclenuvanja = zaclenuvanja.Include(z => z.Objekt).Include(z => z.User);
            var terminSearchVM = new TerminSearchViewModel
            {
                Termini = await zaclenuvanja.ToListAsync(),
                Status = new SelectList( await queryString.ToListAsync())
            };
            return View(terminSearchVM);
        }

        // GET: Zaclenuvanjes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaclenuvanje = await _context.Zaclenuvanje
                .Include(z => z.Objekt)
                .Include(z => z.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zaclenuvanje == null)
            {
                return NotFound();
            }

            return View(zaclenuvanje);
        }

        public IActionResult CreateTerminKorisnik(int? id)
        {
            var zaclenuvanje = _context.User.Where(s => s.Id == id).FirstOrDefault();
            ViewData["imeKorisnik"] = zaclenuvanje.FullName;
            ViewData["ObjektId"] = new SelectList(_context.Objekt, "Id", "Ime");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullName");
            return View();
        }
      
        // GET: Zaclenuvanjes/Create
        public IActionResult Create()
        {
            ViewData["ObjektId"] = new SelectList(_context.Objekt, "Id", "Ime");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullName");
            return View();
        }

        // POST: Zaclenuvanjes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ObjektId,UserId,Termin,OdobrenNeodobren")] Zaclenuvanje zaclenuvanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zaclenuvanje);
                await _context.SaveChangesAsync();
                return RedirectToAction("KorisnikUvid", new { id = zaclenuvanje.UserId});
            }
            ViewData["ObjektId"] = new SelectList(_context.Objekt, "Id", "Ime", zaclenuvanje.ObjektId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullName", zaclenuvanje.UserId);
            return View(zaclenuvanje);
        }

        // GET: Zaclenuvanjes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaclenuvanje = await _context.Zaclenuvanje.FindAsync(id);
            if (zaclenuvanje == null)
            {
                return NotFound();
            }
            ViewData["ObjektId"] = new SelectList(_context.Objekt, "Id", "Ime", zaclenuvanje.ObjektId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullName", zaclenuvanje.UserId);
            return View(zaclenuvanje);
        }

        // POST: Zaclenuvanjes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ObjektId,UserId,Termin,OdobrenNeodobren")] Zaclenuvanje zaclenuvanje)
        {
            if (id != zaclenuvanje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zaclenuvanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZaclenuvanjeExists(zaclenuvanje.Id))
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
            ViewData["ObjektId"] = new SelectList(_context.Objekt, "Id", "Ime", zaclenuvanje.ObjektId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullName", zaclenuvanje.UserId);
            return View(zaclenuvanje);
        }
        public async Task<IActionResult> EditOdobriOdbijTermin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaclenuvanje = _context.Zaclenuvanje.Where(s => s.Id == id).Include(s=>s.User).Include(s=>s.Objekt).FirstOrDefault();
            if (zaclenuvanje == null)
            {
                return NotFound();
            }
            ViewData["ObjektId"] = new SelectList(_context.Objekt, "Id", "Ime", zaclenuvanje.ObjektId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullName", zaclenuvanje.UserId);
            return View(zaclenuvanje);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOdobriOdbijTermin(int id, [Bind("Id,ObjektId,UserId,Termin,OdobrenNeodobren")] Zaclenuvanje zaclenuvanje)
        {
            if (id != zaclenuvanje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var TrenerId = Int32.Parse(TempData["idTrenerTemp"].ToString());
                try
                {
                   
                    _context.Update(zaclenuvanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZaclenuvanjeExists(zaclenuvanje.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("TrenerUvid", new { id = TrenerId});
            }
            ViewData["ObjektId"] = new SelectList(_context.Objekt, "Id", "Ime", zaclenuvanje.ObjektId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullName", zaclenuvanje.UserId);
            return View(zaclenuvanje);
        }

        // GET: Zaclenuvanjes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaclenuvanje = await _context.Zaclenuvanje
                .Include(z => z.Objekt)
                .Include(z => z.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zaclenuvanje == null)
            {
                return NotFound();
            }

            return View(zaclenuvanje);
        }

        // POST: Zaclenuvanjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zaclenuvanje = await _context.Zaclenuvanje.FindAsync(id);
            _context.Zaclenuvanje.Remove(zaclenuvanje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> KorisnikUvid(int? id, string searchStringImeObjekt)
        {
            if(id==null )
            {
                return NotFound();
            }

            IQueryable<Zaclenuvanje> zaclenuvanjes = _context.Zaclenuvanje.AsQueryable();

            if (!string.IsNullOrEmpty(searchStringImeObjekt))
            {
                zaclenuvanjes = zaclenuvanjes.Where(i => i.Objekt.Ime.Contains(searchStringImeObjekt));
            }

            var korisnici = _context.User.Where(s => s.Id == id).FirstOrDefault();
            ViewData["imeKorisnik"] = korisnici.FullName;
            ViewData["idKorisnik"] = id;

            zaclenuvanjes = zaclenuvanjes.Where(s => s.UserId == id).Include(s => s.Objekt);

            var korisnikImeObjekt = new KorisnikImeObjektSeachViewModel
            {
                Zaclenuvanjes = await zaclenuvanjes.ToListAsync()
            };
            return View(korisnikImeObjekt);
        }

        public async Task<IActionResult> TrenerUvid(int? id, string searchStringObjekt)
        {
            if (id == null)
                return NotFound();

            IQueryable<Zaclenuvanje> zaclenuvanjes = _context.Zaclenuvanje.Where(s => s.Objekt.Coach1Id == id || s.Objekt.Coach2Id == id).AsQueryable();
            if(!string.IsNullOrEmpty(searchStringObjekt))
            {
                zaclenuvanjes = zaclenuvanjes.Where(s => s.Objekt.Ime.Contains(searchStringObjekt));
            }


            zaclenuvanjes = zaclenuvanjes.Include(s => s.User).Include(s => s.Objekt);

            var trener = _context.Coach.Where(m => m.Id == id).FirstOrDefault();
            ViewData["imeTrener"] = trener.FullName;
            ViewData["idTrener"] = trener.Id;
            TempData["idTrenerTemp"] = trener.Id;
            TempData.Keep();
            var trenerUvidVM = new TrenerUvidObjektViewModel
            {
                Termini =await zaclenuvanjes.ToListAsync()
               
            };

           // var enrollments = _context.Zaclenuvanje.Where(s => s.Objekt.Coach1Id == id || s.Objekt.Coach2Id == id).Include(s => s.User).Include(s=>s.Objekt);
            return View(trenerUvidVM);
        }

        private bool ZaclenuvanjeExists(int id)
        {
            return _context.Zaclenuvanje.Any(e => e.Id == id);
        }
    }
}
