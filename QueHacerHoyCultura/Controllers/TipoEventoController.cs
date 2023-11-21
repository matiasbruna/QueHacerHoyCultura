using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QueHacerHoyCultura;
using QueHacerHoyCultura.Entidades;

namespace QueHacerHoyCultura.Controllers
{
    public class TipoEventoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoEventoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoEvento
        public async Task<IActionResult> Index()
        {
              return _context.TipoEventos != null ? 
                          View(await _context.TipoEventos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TipoEventos'  is null.");
        }

        // GET: TipoEvento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoEventos == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEvento == null)
            {
                return NotFound();
            }

            return View(tipoEvento);
        }

        // GET: TipoEvento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEvento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TipoEvento tipoEvento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEvento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEvento);
        }

        // GET: TipoEvento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoEventos == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEventos.FindAsync(id);
            if (tipoEvento == null)
            {
                return NotFound();
            }
            return View(tipoEvento);
        }

        // POST: TipoEvento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TipoEvento tipoEvento)
        {
            if (id != tipoEvento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEvento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEventoExists(tipoEvento.Id))
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
            return View(tipoEvento);
        }

        // GET: TipoEvento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoEventos == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEvento == null)
            {
                return NotFound();
            }

            return View(tipoEvento);
        }

        // POST: TipoEvento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoEventos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TipoEventos'  is null.");
            }
            var tipoEvento = await _context.TipoEventos.FindAsync(id);
            if (tipoEvento != null)
            {
                _context.TipoEventos.Remove(tipoEvento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEventoExists(int id)
        {
          return (_context.TipoEventos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
