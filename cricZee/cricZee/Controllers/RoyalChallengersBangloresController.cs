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
    public class RoyalChallengersBangloresController : Controller
    {
        private readonly projectContext _context;

        public RoyalChallengersBangloresController(projectContext context)
        {
            _context = context;
        }

        // GET: RoyalChallengersBanglores
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoyalChallengersBanglores.ToListAsync());
        }

        // GET: RoyalChallengersBanglores/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var royalChallengersBanglore = await _context.RoyalChallengersBanglores
                .FirstOrDefaultAsync(m => m.Player == id);
            if (royalChallengersBanglore == null)
            {
                return NotFound();
            }

            return View(royalChallengersBanglore);
        }

        // GET: RoyalChallengersBanglores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoyalChallengersBanglores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,Player,PlayerRole,Price")] RoyalChallengersBanglore royalChallengersBanglore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(royalChallengersBanglore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(royalChallengersBanglore);
        }

        // GET: RoyalChallengersBanglores/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var royalChallengersBanglore = await _context.RoyalChallengersBanglores.FindAsync(id);
            if (royalChallengersBanglore == null)
            {
                return NotFound();
            }
            return View(royalChallengersBanglore);
        }

        // POST: RoyalChallengersBanglores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlayerId,Player,PlayerRole,Price")] RoyalChallengersBanglore royalChallengersBanglore)
        {
            if (id != royalChallengersBanglore.Player)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(royalChallengersBanglore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoyalChallengersBangloreExists(royalChallengersBanglore.Player))
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
            return View(royalChallengersBanglore);
        }

        // GET: RoyalChallengersBanglores/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var royalChallengersBanglore = await _context.RoyalChallengersBanglores
                .FirstOrDefaultAsync(m => m.Player == id);
            if (royalChallengersBanglore == null)
            {
                return NotFound();
            }

            return View(royalChallengersBanglore);
        }

        // POST: RoyalChallengersBanglores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var royalChallengersBanglore = await _context.RoyalChallengersBanglores.FindAsync(id);
            _context.RoyalChallengersBanglores.Remove(royalChallengersBanglore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoyalChallengersBangloreExists(string id)
        {
            return _context.RoyalChallengersBanglores.Any(e => e.Player == id);
        }
    }
}
