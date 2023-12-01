using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POE_Part3_23.Data;
using POE_Part3_23.Models;

namespace POE_Part3_23.Controllers
{
    public class ModulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Modules
        public async Task<IActionResult> Index()
        {

            Modules module = new Modules();
            module.Credits = 4;
            module.SemWeeks = 16;
            module.ClassHours = 3;

            module.CalculateSelfStudyHoursPerWeek();

            return _context.Modules != null ? 
                          View(await _context.Modules.ToListAsync() ) :
                          Problem("Entity set 'ApplicationDbContext.Modules'  is null.");

        }

        // GET: Search 
        [Authorize]
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // GET: Search Result
        public async Task<IActionResult> ShowSearchResult(string SearchPhrase, string SearchPhrase2, string SearchPhrase3)
        {
            return _context.Modules != null ?
                          View("Index", await _context.Modules.Where(j => j.Code.Contains(SearchPhrase)).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Modules'  is null.");
        }
        // GET: Modules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var modules = await _context.Modules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modules == null)
            {
                return NotFound();
            }

            return View(modules);
        }

        // GET: Modules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,Credits,ClassHours,SelfStudyHoursPerWeek,SemWeeks,StartDate")] Modules modules)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modules);
        }

        // GET: Modules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var modules = await _context.Modules.FindAsync(id);
            if (modules == null)
            {
                return NotFound();
            }
            return View(modules);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,Credits,ClassHours,SelfStudyHoursPerWeek,SemWeeks,StartDate")] Modules modules)
        {
            if (id != modules.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModulesExists(modules.Id))
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
            return View(modules);
        }

        // GET: Modules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var modules = await _context.Modules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modules == null)
            {
                return NotFound();
            }

            return View(modules);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modules == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Modules'  is null.");
            }
            var modules = await _context.Modules.FindAsync(id);
            if (modules != null)
            {
                _context.Modules.Remove(modules);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModulesExists(int id)
        {
          return (_context.Modules?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]
        //reminder for study day 
        public IActionResult SavePlannedDays(List<Modules> modules)
        {
            // Save the planned days for each module (e.g., update the database)
            // Code to save the planned days goes here

            return RedirectToAction("Index");
        }

    }
}
