using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEEIT.Data;
using NEEIT.Models;

namespace NEEIT.Controllers
{
    public class MembrosController : Controller
    {
        private readonly NEEITBD _context;

        public MembrosController(NEEITBD context)
        {
            _context = context;
        }

        // GET: Membros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Membros.ToListAsync());
        }

        // GET: Membros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membros = await _context.Membros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membros == null)
            {
                return NotFound();
            }

            return View(membros);
        }

        // GET: Membros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Membros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Apelido,Email,Autorizado,Cargo,Foto,DataInicioFuncoes,DataFimFuncoes")] Membros membros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membros);
        }

        // GET: Membros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membros = await _context.Membros.FindAsync(id);
            if (membros == null)
            {
                return NotFound();
            }
            return View(membros);
        }

        // POST: Membros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Apelido,Email,Autorizado,Cargo,Foto,DataInicioFuncoes,DataFimFuncoes")] Membros membros)
        {
            if (id != membros.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembrosExists(membros.Id))
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
            return View(membros);
        }

        // GET: Membros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membros = await _context.Membros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membros == null)
            {
                return NotFound();
            }

            return View(membros);
        }

        // POST: Membros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membros = await _context.Membros.FindAsync(id);
            _context.Membros.Remove(membros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembrosExists(int id)
        {
            return _context.Membros.Any(e => e.Id == id);
        }
    }
}
