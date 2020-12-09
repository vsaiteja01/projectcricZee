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
    public class TopBatsmenController : Controller
    {
        private readonly projectContext _context;

        public TopBatsmenController(projectContext context)
        {
            _context = context;
        }

        // GET: TopBatsmen
        public async Task<IActionResult> Index()
        {
            return View(await _context.TopBatsmens.ToListAsync());
        }

        // GET: TopBatsmen/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topBatsmen = await _context.TopBatsmens
                .FirstOrDefaultAsync(m => m.Player == id);
            if (topBatsmen == null)
            {
                return NotFound();
            }

            return View(topBatsmen);
        }

        // GET: TopBatsmen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TopBatsmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,Player,Innings,Runs")] TopBatsmen topBatsmen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topBatsmen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topBatsmen);
        }

        // GET: TopBatsmen/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topBatsmen = await _context.TopBatsmens.FindAsync(id);
            if (topBatsmen == null)
            {
                return NotFound();
            }
            return View(topBatsmen);
        }

        // POST: TopBatsmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlayerId,Player,Innings,Runs")] TopBatsmen topBatsmen)
        {
            if (id != topBatsmen.Player)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topBatsmen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopBatsmenExists(topBatsmen.Player))
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
            return View(topBatsmen);
        }

        // GET: TopBatsmen/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topBatsmen = await _context.TopBatsmens
                .FirstOrDefaultAsync(m => m.Player == id);
            if (topBatsmen == null)
            {
                return NotFound();
            }

            return View(topBatsmen);
        }

        // POST: TopBatsmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var topBatsmen = await _context.TopBatsmens.FindAsync(id);
            _context.TopBatsmens.Remove(topBatsmen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopBatsmenExists(string id)
        {
            return _context.TopBatsmens.Any(e => e.Player == id);
        }
    }
}
