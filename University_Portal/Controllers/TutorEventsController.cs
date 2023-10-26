using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University_Portal.Data;
using University_Portal.Models;

namespace University_Portal.Controllers
{
    public class TutorEventsController : Controller
    {
        private readonly PortalDbContext _context;

        public TutorEventsController(PortalDbContext context)
        {
            _context = context;
        }

        // GET: TutorEvents
        public async Task<IActionResult> Index()
        {
            return _context.TutorEvents != null ?
                        View(await _context.TutorEvents.ToListAsync()) :
                        Problem("Entity set 'PortalDbContext.TutorEvents'  is null.");
        }

        // GET: TutorEvents/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null || _context.TutorEvents == null)
            {
                return NotFound();
            }

            var tutorEvents = await _context.TutorEvents
                .FirstOrDefaultAsync(m => m.id == id);
            if (tutorEvents == null)
            {
                return NotFound();
            }

            return View(tutorEvents);
        }

        // GET: TutorEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TutorEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,tutorId,name,description,dateCreated")] TutorEvents tutorEvents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tutorEvents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tutorEvents);
        }

        // GET: TutorEvents/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null || _context.TutorEvents == null)
            {
                return NotFound();
            }

            var tutorEvents = await _context.TutorEvents.FindAsync(id);
            if (tutorEvents == null)
            {
                return NotFound();
            }
            return View(tutorEvents);
        }

        // POST: TutorEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("id,tutorId,name,description,dateCreated")] TutorEvents tutorEvents)
        {
            if (id != tutorEvents.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tutorEvents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutorEventsExists(tutorEvents.id))
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
            return View(tutorEvents);
        }

        // GET: TutorEvents/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null || _context.TutorEvents == null)
            {
                return NotFound();
            }

            var tutorEvents = await _context.TutorEvents
                .FirstOrDefaultAsync(m => m.id == id);
            if (tutorEvents == null)
            {
                return NotFound();
            }

            return View(tutorEvents);
        }

        // POST: TutorEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            if (_context.TutorEvents == null)
            {
                return Problem("Entity set 'PortalDbContext.TutorEvents'  is null.");
            }
            var tutorEvents = await _context.TutorEvents.FindAsync(id);
            if (tutorEvents != null)
            {
                _context.TutorEvents.Remove(tutorEvents);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TutorEventsExists(uint id)
        {
            return (_context.TutorEvents?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
