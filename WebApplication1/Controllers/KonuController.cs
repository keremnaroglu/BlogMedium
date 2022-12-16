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
    public class KonuController : Controller
    {
        private readonly Context _context;

        public KonuController(Context context)
        {
            _context = context;
        }

        // GET: Konu
        public async Task<IActionResult> Index()
        {
              return View(await _context.Konular.ToListAsync());
        }

        // GET: Konu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Konular == null)
            {
                return NotFound();
            }

            var konu = await _context.Konular
                .FirstOrDefaultAsync(m => m.Id == id);
            if (konu == null)
            {
                return NotFound();
            }

            return View(konu);
        }

        // GET: Konu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Konu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KonuAdi")] Konu konu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(konu);
        }

        // GET: Konu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Konular == null)
            {
                return NotFound();
            }

            var konu = await _context.Konular.FindAsync(id);
            if (konu == null)
            {
                return NotFound();
            }
            return View(konu);
        }

        // POST: Konu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KonuAdi")] Konu konu)
        {
            if (id != konu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KonuExists(konu.Id))
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
            return View(konu);
        }

        // GET: Konu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Konular == null)
            {
                return NotFound();
            }

            var konu = await _context.Konular
                .FirstOrDefaultAsync(m => m.Id == id);
            if (konu == null)
            {
                return NotFound();
            }

            return View(konu);
        }

        // POST: Konu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Konular == null)
            {
                return Problem("Entity set 'Context.Konular'  is null.");
            }
            var konu = await _context.Konular.FindAsync(id);
            if (konu != null)
            {
                _context.Konular.Remove(konu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KonuExists(int id)
        {
          return _context.Konular.Any(e => e.Id == id);
        }
    }
}
