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
    public class MakaleController : Controller
    {
        private readonly IMakaleRepository _repo;

        public int _id = 2;
        public MakaleController(IMakaleRepository repo)
        {
            _repo = repo;
        }

        // GET: Makale
        public IActionResult Index()
        {
            return View(_repo.GetAll().ToList());
        }

        // GET: Makale/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _repo.GetAll() == null)
            {
                return NotFound();
            }
            Makale makale = _repo.GetById(id);
            if (makale == null)
            {
                return NotFound();
            }

            return View(makale);
        }

        // GET: Makale/Create
        public IActionResult Create(int id)
        {
            ViewData["KisiId"] = _id;
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
                _repo.Create(makale);
                return RedirectToAction(nameof(Index));
            }
            return View(makale);
        }

        // GET: Makale/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _repo.GetAll() == null)
            {
                return NotFound();
            }

            Makale makale = _repo.GetById(id);
            if (makale == null)
            {
                return NotFound();
            }
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
                    _repo.Update(makale);
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
            return View(makale);
        }

        // GET: Makale/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _repo.GetAll() == null)
            {
                return NotFound();
            }

            Makale makale = _repo.GetById(id);
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
            if (_repo.GetAll() == null)
            {
                return Problem("Entity set 'Context.Makaleler'  is null.");
            }
            Makale makale = _repo.GetById(id);
            if (makale != null)
            {
                _repo.Delete(makale);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
