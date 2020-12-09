using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cricZee.Models;

namespace cricZee.Controllers
{
    public class KolkataKnightRidersController : Controller
    {
        private readonly projectContext _context;

        public KolkataKnightRidersController(projectContext context)
        {
            _context = context;
        }

        // GET: KolkataKnightRiders
        public async Task<IActionResult> Index()
        {
            return View(await _context.KolkataKnightRiders.ToListAsync());
        }

        // GET: KolkataKnightRiders/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kolkataKnightRider = await _context.KolkataKnightRiders
                .FirstOrDefaultAsync(m => m.Player == id);
            if (kolkataKnightRider == null)
            {
                return NotFound();
            }

            return View(kolkataKnightRider);
        }

        // GET: KolkataKnightRiders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KolkataKnightRiders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,Player,PlayerRole,Price")] KolkataKnightRider kolkataKnightRider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kolkataKnightRider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kolkataKnightRider);
        }

        // GET: KolkataKnightRiders/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kolkataKnightRider = await _context.KolkataKnightRiders.FindAsync(id);
            if (kolkataKnightRider == null)
            {
                return NotFound();
            }
            return View(kolkataKnightRider);
        }

        // POST: KolkataKnightRiders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlayerId,Player,PlayerRole,Price")] KolkataKnightRider kolkataKnightRider)
        {
            if (id != kolkataKnightRider.Player)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kolkataKnightRider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KolkataKnightRiderExists(kolkataKnightRider.Player))
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
            return View(kolkataKnightRider);
        }

        // GET: KolkataKnightRiders/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kolkataKnightRider = await _context.KolkataKnightRiders
                .FirstOrDefaultAsync(m => m.Player == id);
            if (kolkataKnightRider == null)
            {
                return NotFound();
            }

            return View(kolkataKnightRider);
        }

        // POST: KolkataKnightRiders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var kolkataKnightRider = await _context.KolkataKnightRiders.FindAsync(id);
            _context.KolkataKnightRiders.Remove(kolkataKnightRider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KolkataKnightRiderExists(string id)
        {
            return _context.KolkataKnightRiders.Any(e => e.Player == id);
        }
    }
}
