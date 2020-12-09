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
    public class KingsXipunjabsController : Controller
    {
        private readonly projectContext _context;

        public KingsXipunjabsController(projectContext context)
        {
            _context = context;
        }

        // GET: KingsXipunjabs
        public async Task<IActionResult> Index()
        {
            return View(await _context.KingsXipunjabs.ToListAsync());
        }

        // GET: KingsXipunjabs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kingsXipunjab = await _context.KingsXipunjabs
                .FirstOrDefaultAsync(m => m.Player == id);
            if (kingsXipunjab == null)
            {
                return NotFound();
            }

            return View(kingsXipunjab);
        }

        // GET: KingsXipunjabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KingsXipunjabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,Player,PlayerRole,Price")] KingsXipunjab kingsXipunjab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kingsXipunjab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kingsXipunjab);
        }

        // GET: KingsXipunjabs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kingsXipunjab = await _context.KingsXipunjabs.FindAsync(id);
            if (kingsXipunjab == null)
            {
                return NotFound();
            }
            return View(kingsXipunjab);
        }

        // POST: KingsXipunjabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlayerId,Player,PlayerRole,Price")] KingsXipunjab kingsXipunjab)
        {
            if (id != kingsXipunjab.Player)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kingsXipunjab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KingsXipunjabExists(kingsXipunjab.Player))
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
            return View(kingsXipunjab);
        }

        // GET: KingsXipunjabs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kingsXipunjab = await _context.KingsXipunjabs
                .FirstOrDefaultAsync(m => m.Player == id);
            if (kingsXipunjab == null)
            {
                return NotFound();
            }

            return View(kingsXipunjab);
        }

        // POST: KingsXipunjabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var kingsXipunjab = await _context.KingsXipunjabs.FindAsync(id);
            _context.KingsXipunjabs.Remove(kingsXipunjab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KingsXipunjabExists(string id)
        {
            return _context.KingsXipunjabs.Any(e => e.Player == id);
        }
    }
}
