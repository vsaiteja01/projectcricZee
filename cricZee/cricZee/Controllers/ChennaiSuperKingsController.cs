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
    public class ChennaiSuperKingsController : Controller
    {
        private readonly projectContext _context;

        public ChennaiSuperKingsController(projectContext context)
        {
            _context = context;
        }

        // GET: ChennaiSuperKings
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChennaiSuperKings.ToListAsync());
        }

        // GET: ChennaiSuperKings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chennaiSuperKing = await _context.ChennaiSuperKings
                .FirstOrDefaultAsync(m => m.Player == id);
            if (chennaiSuperKing == null)
            {
                return NotFound();
            }

            return View(chennaiSuperKing);
        }

        // GET: ChennaiSuperKings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChennaiSuperKings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,Player,PlayerRole,Price")] ChennaiSuperKing chennaiSuperKing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chennaiSuperKing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chennaiSuperKing);
        }

        // GET: ChennaiSuperKings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chennaiSuperKing = await _context.ChennaiSuperKings.FindAsync(id);
            if (chennaiSuperKing == null)
            {
                return NotFound();
            }
            return View(chennaiSuperKing);
        }

        // POST: ChennaiSuperKings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlayerId,Player,PlayerRole,Price")] ChennaiSuperKing chennaiSuperKing)
        {
            if (id != chennaiSuperKing.Player)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chennaiSuperKing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChennaiSuperKingExists(chennaiSuperKing.Player))
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
            return View(chennaiSuperKing);
        }

        // GET: ChennaiSuperKings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chennaiSuperKing = await _context.ChennaiSuperKings
                .FirstOrDefaultAsync(m => m.Player == id);
            if (chennaiSuperKing == null)
            {
                return NotFound();
            }

            return View(chennaiSuperKing);
        }

        // POST: ChennaiSuperKings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chennaiSuperKing = await _context.ChennaiSuperKings.FindAsync(id);
            _context.ChennaiSuperKings.Remove(chennaiSuperKing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChennaiSuperKingExists(string id)
        {
            return _context.ChennaiSuperKings.Any(e => e.Player == id);
        }
    }
}
