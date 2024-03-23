using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCEquiposXaldakr.Models;

namespace MVCEquiposXaldakr.Controllers
{
    public class estadosEquipoController : Controller
    {
        private readonly equiposDbContext _context;

        public estadosEquipoController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: estadosEquipo
        public async Task<IActionResult> Index()
        {
            return View(await _context.estados_equipo.ToListAsync());
        }

        // GET: estadosEquipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadosEquipo = await _context.estados_equipo
                .FirstOrDefaultAsync(m => m.id_estados_equipo == id);
            if (estadosEquipo == null)
            {
                return NotFound();
            }

            return View(estadosEquipo);
        }

        // GET: estadosEquipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: estadosEquipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_estados_equipo,descripcion,estado")] estadosEquipo estadosEquipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadosEquipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosEquipo);
        }

        // GET: estadosEquipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadosEquipo = await _context.estados_equipo.FindAsync(id);
            if (estadosEquipo == null)
            {
                return NotFound();
            }
            return View(estadosEquipo);
        }

        // POST: estadosEquipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_estados_equipo,descripcion,estado")] estadosEquipo estadosEquipo)
        {
            if (id != estadosEquipo.id_estados_equipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadosEquipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!estadosEquipoExists(estadosEquipo.id_estados_equipo))
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
            return View(estadosEquipo);
        }

        // GET: estadosEquipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadosEquipo = await _context.estados_equipo
                .FirstOrDefaultAsync(m => m.id_estados_equipo == id);
            if (estadosEquipo == null)
            {
                return NotFound();
            }

            return View(estadosEquipo);
        }

        // POST: estadosEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadosEquipo = await _context.estados_equipo.FindAsync(id);
            if (estadosEquipo != null)
            {
                _context.estados_equipo.Remove(estadosEquipo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool estadosEquipoExists(int id)
        {
            return _context.estados_equipo.Any(e => e.id_estados_equipo == id);
        }
    }
}
