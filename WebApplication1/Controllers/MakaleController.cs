using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MakaleController : Controller
    {
        private readonly Context _context;

        public MakaleController(Context context)
        {
            _context = context;
        }

        // GET: Makale
        public async Task<IActionResult> Index()
        {
            var context = _context.Makaleler.Include(m => m.Kisi);
            return View(await context.ToListAsync());
        }

        // GET: Makale/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Makaleler == null)
            {
                return NotFound();
            }

            var makale = await _context.Makaleler
                .Include(m => m.Kisi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (makale == null)
            {
                return NotFound();
            }

            return View(makale);
        }

        // GET: Makale/Create
        public IActionResult Create()
        {
            ViewData["KisiId"] = new SelectList(_context.Kisiler, "Id", "Id");
            return View();
        }

        // POST: Makale/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Icerik,KisiId,CreateDate")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(makale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KisiId"] = new SelectList(_context.Kisiler, "Id", "Id", makale.KisiId);
            return View(makale);
        }

        // GET: Makale/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Makaleler == null)
            {
                return NotFound();
            }

            var makale = await _context.Makaleler.FindAsync(id);
            if (makale == null)
            {
                return NotFound();
            }
            ViewData["KisiId"] = new SelectList(_context.Kisiler, "Id", "Id", makale.KisiId);
            return View(makale);
        }

        // POST: Makale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Icerik,KisiId,CreateDate")] Makale makale)
        {
            if (id != makale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(makale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakaleExists(makale.Id))
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
            ViewData["KisiId"] = new SelectList(_context.Kisiler, "Id", "Id", makale.KisiId);
            return View(makale);
        }

        // GET: Makale/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Makaleler == null)
            {
                return NotFound();
            }

            var makale = await _context.Makaleler
                .Include(m => m.Kisi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (makale == null)
            {
                return NotFound();
            }

            return View(makale);
        }

        // POST: Makale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Makaleler == null)
            {
                return Problem("Entity set 'Context.Makaleler'  is null.");
            }
            var makale = await _context.Makaleler.FindAsync(id);
            if (makale != null)
            {
                _context.Makaleler.Remove(makale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MakaleExists(int id)
        {
          return _context.Makaleler.Any(e => e.Id == id);
        }
    }
}
