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
    public class KisiController : Controller
    {
        private readonly Context _context;

        public KisiController(Context context)
        {
            _context = context;
        }

        // GET: Kisi
        public async Task<IActionResult> Index()
        {
              return View(await _context.Kisiler.ToListAsync());
        }

        // GET: Kisi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kisiler == null)
            {
                return NotFound();
            }

            var kisi = await _context.Kisiler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kisi == null)
            {
                return NotFound();
            }

            return View(kisi);
        }

        // GET: Kisi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kisi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Soyad,Mail,Aciklama,Resim")] Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kisi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kisi);
        }

        // GET: Kisi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kisiler == null)
            {
                return NotFound();
            }

            var kisi = await _context.Kisiler.FindAsync(id);
            if (kisi == null)
            {
                return NotFound();
            }
            return View(kisi);
        }

        // POST: Kisi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Soyad,Mail,Aciklama,Resim")] Kisi kisi)
        {
            if (id != kisi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kisi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KisiExists(kisi.Id))
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
            return View(kisi);
        }

        // GET: Kisi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kisiler == null)
            {
                return NotFound();
            }

            var kisi = await _context.Kisiler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kisi == null)
            {
                return NotFound();
            }

            return View(kisi);
        }

        // POST: Kisi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kisiler == null)
            {
                return Problem("Entity set 'Context.Kisiler'  is null.");
            }
            var kisi = await _context.Kisiler.FindAsync(id);
            if (kisi != null)
            {
                _context.Kisiler.Remove(kisi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KisiExists(int id)
        {
          return _context.Kisiler.Any(e => e.Id == id);
        }
    }
}
