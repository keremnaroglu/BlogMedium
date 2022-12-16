using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.IRepositories;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class KonuController : Controller
    {
        private readonly IKonuRepository _repo;

        public KonuController(IKonuRepository repo)
        {
            _repo = repo;
        }

        // GET: Konu
        public IActionResult Index()
        {
            return View(_repo.GetAll().ToList());
        }

        // GET: Konu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _repo.GetAll() == null)
            {
                return NotFound();
            }
            Konu konu = _repo.GetById(id);
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
                _repo.Create(konu);
                return RedirectToAction(nameof(Index));
            }
            return View(konu);
        }

        // GET: Konu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _repo.GetAll() == null)
            {
                return NotFound();
            }
            Konu konu = _repo.GetById(id);
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
                    _repo.Update(konu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_repo.GetById(id) == null)
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
            if (id == null || _repo.GetAll() == null)
            {
                return NotFound();
            }

            Konu konu = _repo.GetById(id);
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
            if (_repo.GetAll() == null)
            {
                return Problem("Entity set 'Context.Konular'  is null.");
            }
            Konu konu = _repo.GetById(id);
            if (konu != null)
            {
                _repo.Delete(konu);
            }     
            return RedirectToAction(nameof(Index));
        }
    }
}
