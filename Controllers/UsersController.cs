using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitKitApp.Data;
using FitKitApp.Models;
using Microsoft.AspNetCore.Identity;
using FitKitApp.ViewModels;

namespace FitKitApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly FitKitAppContext _context;

        public UsersController(FitKitAppContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index(string searchStringImeKorisnik, string seachStringPrezmieKorisnik)
        {
            IQueryable<User> users = _context.User.AsQueryable();

            if(!string.IsNullOrEmpty(searchStringImeKorisnik))
            {
                users = users.Where(s => s.Ime.Contains(searchStringImeKorisnik));
            }
            if(!string.IsNullOrEmpty(seachStringPrezmieKorisnik))
            {
                users = users.Where(k => k.Prezime.Contains(seachStringPrezmieKorisnik));
            }

            var korisnicSearchVM = new KorisniciSearchViewModel
            {
                Users = await users.ToListAsync()
            };
            return View(korisnicSearchVM);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,BirthDate,ProfilePic,Visina,Tezina,ObemGradi,ObemBiceps,ObemDesenBiceps,ObemStruk,ObemLevBut,ObemDesenBut")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,BirthDate,ProfilePic,Visina,Tezina,ObemGradi,ObemBiceps,ObemDesenBiceps,ObemStruk,ObemLevBut,ObemDesenBut")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
