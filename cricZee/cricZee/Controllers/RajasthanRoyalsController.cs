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
    public class RajasthanRoyalsController : Controller
    {
        private readonly projectContext _context;

        public RajasthanRoyalsController(projectContext context)
        {
            _context = context;
        }

        // GET: RajasthanRoyals
        public async Task<IActionResult> Index()
        {
            return View(await _context.RajasthanRoyals.ToListAsync());
        }

        // GET: RajasthanRoyals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rajasthanRoyal = await _context.RajasthanRoyals
                .FirstOrDefaultAsync(m => m.Player == id);
            if (rajasthanRoyal == null)
            {
                return NotFound();
            }

            return View(rajasthanRoyal);
        }

        // GET: RajasthanRoyals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RajasthanRoyals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,Player,PlayerRole,Price")] RajasthanRoyal rajasthanRoyal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rajasthanRoyal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rajasthanRoyal);
        }

        // GET: RajasthanRoyals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rajasthanRoyal = await _context.RajasthanRoyals.FindAsync(id);
            if (rajasthanRoyal == null)
            {
                return NotFound();
            }
            return View(rajasthanRoyal);
        }

        // POST: RajasthanRoyals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlayerId,Player,PlayerRole,Price")] RajasthanRoyal rajasthanRoyal)
        {
            if (id != rajasthanRoyal.Player)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rajasthanRoyal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RajasthanRoyalExists(rajasthanRoyal.Player))
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
            return View(rajasthanRoyal);
        }

        // GET: RajasthanRoyals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rajasthanRoyal = await _context.RajasthanRoyals
                .FirstOrDefaultAsync(m => m.Player == id);
            if (rajasthanRoyal == null)
            {
                return NotFound();
            }

            return View(rajasthanRoyal);
        }

        // POST: RajasthanRoyals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rajasthanRoyal = await _context.RajasthanRoyals.FindAsync(id);
            _context.RajasthanRoyals.Remove(rajasthanRoyal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RajasthanRoyalExists(string id)
        {
            return _context.RajasthanRoyals.Any(e => e.Player == id);
        }
    }
}
