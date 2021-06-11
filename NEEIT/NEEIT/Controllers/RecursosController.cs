using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEEIT.Data;
using NEEIT.Models;

namespace NEEIT.Controllers
{
    public class RecursosController : Controller
    {
        private readonly NEEITBD _context;

        /// <summary>
        /// atributo que referencia a Base de Dados do projeto
        /// </summary>
        private readonly NEEITBD _db;

        /// <summary>
        /// Atributo que guarda nele os dados do Servidor
        /// </summary>
        private readonly IWebHostEnvironment _dadosServidor;


        public RecursosController(
           NEEITBD  context,
           IWebHostEnvironment dadosServidor)
        {
            _db = context;
            _dadosServidor = dadosServidor;
        }

        // GET: Recursos
        public async Task<IActionResult> Index()
        {
            var listaFotosEventos = _db.Recursos.Include(f => f.Evento); //LINQ

            // invocar a View, entregando-lhe os dados devolvidos pela BD
            // sendo transformados numa LISTA assíncrona

            return View(await listaFotosEventos.ToListAsync());
        }

        // GET: Recursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recursos = await _db.Recursos
                .Include(r => r.Evento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recursos == null)
            {
                return NotFound();
            }

            return View(recursos);
        }

        // GET: Recursos/Create
        public IActionResult Create()
        {
            // prepara os dados a serem enviados para a View
            // para a Dropdown
            ViewData["EventoFK"] = new SelectList(_db.Eventos, "Id", "Nome");
            return View();
        }

        // POST: Recursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Designacao,Valor,DataPublicacao,EventoFK")] Recursos recursos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recursos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoFK"] = new SelectList(_context.Eventos, "Id", "Nome", recursos.EventoFK);
            return View(recursos);

        }

        // GET: Recursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recursos = await _context.Recursos.FindAsync(id);
            if (recursos == null)
            {
                return NotFound();
            }
            ViewData["EventoFK"] = new SelectList(_context.Eventos, "Id", "Nome", recursos.EventoFK);
            return View(recursos);
        }

        // POST: Recursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Designacao,Valor,DataPublicacao,EventoFK")] Recursos recursos)
        {
            if (id != recursos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recursos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecursosExists(recursos.Id))
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
            ViewData["EventoFK"] = new SelectList(_context.Eventos, "Id", "Nome", recursos.EventoFK);
            return View(recursos);
        }

        // GET: Recursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recursos = await _context.Recursos
                .Include(r => r.Evento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recursos == null)
            {
                return NotFound();
            }

            return View(recursos);
        }

        // POST: Recursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recursos = await _context.Recursos.FindAsync(id);
            _context.Recursos.Remove(recursos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecursosExists(int id)
        {
            return _context.Recursos.Any(e => e.Id == id);
        }
    }
}
