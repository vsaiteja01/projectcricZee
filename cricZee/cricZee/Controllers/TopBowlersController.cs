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
    public class TopBowlersController : Controller
    {
        private readonly projectContext _context;

        public TopBowlersController(projectContext context)
        {
            _context = context;
        }

        // GET: TopBowlers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TopBowlers.ToListAsync());
        }

        // GET: TopBowlers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topBowler = await _context.TopBowlers
                .FirstOrDefaultAsync(m => m.Player == id);
            if (topBowler == null)
            {
                return NotFound();
            }

            return View(topBowler);
        }

        // GET: TopBowlers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TopBowlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,Player,Matches,Wickets")] TopBowler topBowler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topBowler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topBowler);
        }

        // GET: TopBowlers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topBowler = await _context.TopBowlers.FindAsync(id);
            if (topBowler == null)
            {
                return NotFound();
            }
            return View(topBowler);
        }

        // POST: TopBowlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlayerId,Player,Matches,Wickets")] TopBowler topBowler)
        {
            if (id != topBowler.Player)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topBowler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopBowlerExists(topBowler.Player))
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
            return View(topBowler);
        }

        // GET: TopBowlers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topBowler = await _context.TopBowlers
                .FirstOrDefaultAsync(m => m.Player == id);
            if (topBowler == null)
            {
                return NotFound();
            }

            return View(topBowler);
        }

        // POST: TopBowlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var topBowler = await _context.TopBowlers.FindAsync(id);
            _context.TopBowlers.Remove(topBowler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopBowlerExists(string id)
        {
            return _context.TopBowlers.Any(e => e.Player == id);
        }
    }
}
