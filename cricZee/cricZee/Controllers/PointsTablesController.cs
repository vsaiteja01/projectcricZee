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
    public class PointsTablesController : Controller
    {
        private readonly projectContext _context;

        public PointsTablesController(projectContext context)
        {
            _context = context;
        }

        // GET: PointsTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.PointsTables.ToListAsync());
        }

        // GET: PointsTables/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointsTable = await _context.PointsTables
                .FirstOrDefaultAsync(m => m.Teams == id);
            if (pointsTable == null)
            {
                return NotFound();
            }

            return View(pointsTable);
        }

        // GET: PointsTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PointsTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamId,Teams,Matches,Won,Lost,Tied,Points,Nrr,Nrrposition")] PointsTable pointsTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pointsTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pointsTable);
        }

        // GET: PointsTables/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointsTable = await _context.PointsTables.FindAsync(id);
            if (pointsTable == null)
            {
                return NotFound();
            }
            return View(pointsTable);
        }

        // POST: PointsTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TeamId,Teams,Matches,Won,Lost,Tied,Points,Nrr,Nrrposition")] PointsTable pointsTable)
        {
            if (id != pointsTable.Teams)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pointsTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PointsTableExists(pointsTable.Teams))
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
            return View(pointsTable);
        }

        // GET: PointsTables/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointsTable = await _context.PointsTables
                .FirstOrDefaultAsync(m => m.Teams == id);
            if (pointsTable == null)
            {
                return NotFound();
            }

            return View(pointsTable);
        }

        // POST: PointsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pointsTable = await _context.PointsTables.FindAsync(id);
            _context.PointsTables.Remove(pointsTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PointsTableExists(string id)
        {
            return _context.PointsTables.Any(e => e.Teams == id);
        }
    }
}
