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
    public class TopFieldersController : Controller
    {
        private readonly projectContext _context;

        public TopFieldersController(projectContext context)
        {
            _context = context;
        }

        // GET: TopFielders
        public async Task<IActionResult> Index()
        {
            return View(await _context.TopFielders.ToListAsync());
        }

        // GET: TopFielders/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topFielder = await _context.TopFielders
                .FirstOrDefaultAsync(m => m.Player == id);
            if (topFielder == null)
            {
                return NotFound();
            }

            return View(topFielder);
        }

        // GET: TopFielders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TopFielders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,Player,Matches,Catches")] TopFielder topFielder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topFielder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topFielder);
        }

        // GET: TopFielders/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topFielder = await _context.TopFielders.FindAsync(id);
            if (topFielder == null)
            {
                return NotFound();
            }
            return View(topFielder);
        }

        // POST: TopFielders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlayerId,Player,Matches,Catches")] TopFielder topFielder)
        {
            if (id != topFielder.Player)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topFielder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopFielderExists(topFielder.Player))
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
            return View(topFielder);
        }

        // GET: TopFielders/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topFielder = await _context.TopFielders
                .FirstOrDefaultAsync(m => m.Player == id);
            if (topFielder == null)
            {
                return NotFound();
            }

            return View(topFielder);
        }

        // POST: TopFielders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var topFielder = await _context.TopFielders.FindAsync(id);
            _context.TopFielders.Remove(topFielder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopFielderExists(string id)
        {
            return _context.TopFielders.Any(e => e.Player == id);
        }
    }
}
