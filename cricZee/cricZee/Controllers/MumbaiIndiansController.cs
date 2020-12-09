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
    public class MumbaiIndiansController : Controller
    {
        private readonly projectContext _context;

        public MumbaiIndiansController(projectContext context)
        {
            _context = context;
        }

        // GET: MumbaiIndians
        public async Task<IActionResult> Index()
        {
            return View(await _context.MumbaiIndians.ToListAsync());
        }

        // GET: MumbaiIndians/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mumbaiIndian = await _context.MumbaiIndians
                .FirstOrDefaultAsync(m => m.Player == id);
            if (mumbaiIndian == null)
            {
                return NotFound();
            }

            return View(mumbaiIndian);
        }

        // GET: MumbaiIndians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MumbaiIndians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,Player,PlayerRole,Price")] MumbaiIndian mumbaiIndian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mumbaiIndian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mumbaiIndian);
        }

        // GET: MumbaiIndians/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mumbaiIndian = await _context.MumbaiIndians.FindAsync(id);
            if (mumbaiIndian == null)
            {
                return NotFound();
            }
            return View(mumbaiIndian);
        }

        // POST: MumbaiIndians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlayerId,Player,PlayerRole,Price")] MumbaiIndian mumbaiIndian)
        {
            if (id != mumbaiIndian.Player)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mumbaiIndian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MumbaiIndianExists(mumbaiIndian.Player))
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
            return View(mumbaiIndian);
        }

        // GET: MumbaiIndians/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mumbaiIndian = await _context.MumbaiIndians
                .FirstOrDefaultAsync(m => m.Player == id);
            if (mumbaiIndian == null)
            {
                return NotFound();
            }

            return View(mumbaiIndian);
        }

        // POST: MumbaiIndians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mumbaiIndian = await _context.MumbaiIndians.FindAsync(id);
            _context.MumbaiIndians.Remove(mumbaiIndian);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MumbaiIndianExists(string id)
        {
            return _context.MumbaiIndians.Any(e => e.Player == id);
        }
    }
}
