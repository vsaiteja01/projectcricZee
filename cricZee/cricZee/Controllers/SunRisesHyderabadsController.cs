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
    public class SunRisesHyderabadsController : Controller
    {
        private readonly projectContext _context;

        public SunRisesHyderabadsController(projectContext context)
        {
            _context = context;
        }

        // GET: SunRisesHyderabads
        public async Task<IActionResult> Index()
        {
            return View(await _context.SunRisesHyderabads.ToListAsync());
        }

        // GET: SunRisesHyderabads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sunRisesHyderabad = await _context.SunRisesHyderabads
                .FirstOrDefaultAsync(m => m.Player == id);
            if (sunRisesHyderabad == null)
            {
                return NotFound();
            }

            return View(sunRisesHyderabad);
        }

        // GET: SunRisesHyderabads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SunRisesHyderabads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,Player,PlayerRole,Price")] SunRisesHyderabad sunRisesHyderabad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sunRisesHyderabad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sunRisesHyderabad);
        }

        // GET: SunRisesHyderabads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sunRisesHyderabad = await _context.SunRisesHyderabads.FindAsync(id);
            if (sunRisesHyderabad == null)
            {
                return NotFound();
            }
            return View(sunRisesHyderabad);
        }

        // POST: SunRisesHyderabads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlayerId,Player,PlayerRole,Price")] SunRisesHyderabad sunRisesHyderabad)
        {
            if (id != sunRisesHyderabad.Player)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sunRisesHyderabad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SunRisesHyderabadExists(sunRisesHyderabad.Player))
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
            return View(sunRisesHyderabad);
        }

        // GET: SunRisesHyderabads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sunRisesHyderabad = await _context.SunRisesHyderabads
                .FirstOrDefaultAsync(m => m.Player == id);
            if (sunRisesHyderabad == null)
            {
                return NotFound();
            }

            return View(sunRisesHyderabad);
        }

        // POST: SunRisesHyderabads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sunRisesHyderabad = await _context.SunRisesHyderabads.FindAsync(id);
            _context.SunRisesHyderabads.Remove(sunRisesHyderabad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SunRisesHyderabadExists(string id)
        {
            return _context.SunRisesHyderabads.Any(e => e.Player == id);
        }
    }
}
