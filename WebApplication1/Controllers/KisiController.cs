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
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class KisiController : Controller
    {
        private readonly IKisiRepository _repo;

        public KisiController(IKisiRepository repo)
        {
            _repo = repo;
        }

        // GET: Kisi
        public IActionResult Index()
        {
            return View(_repo.GetAll().ToList());
        }

        // GET: Kisi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _repo.GetAll()==null)
            {
                return NotFound();
            }
            Kisi kisi = _repo.GetById(id);
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
                _repo.Create(kisi);
                return RedirectToAction(nameof(Index));
            }
            return View(kisi);
        }

        // GET: Kisi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _repo.GetAll()==null)
            {
                return NotFound();
            }
            Kisi kisi = _repo.GetById(id);
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
                    _repo.Update(kisi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_repo.GetById(id)==null)
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
            if (id == null || _repo.GetAll() == null)
            {
                return NotFound();
            }

            Kisi kisi = _repo.GetById(id);
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
            if ( _repo.GetAll() == null)
            {
                return Problem("Entity set 'Context.Kisiler'  is null.");
            }
            Kisi kisi = _repo.GetById(id);
            if (kisi != null)
            {
                _repo.Delete(kisi);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
