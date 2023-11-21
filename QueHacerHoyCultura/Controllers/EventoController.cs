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
    public class EventoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Evento
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Eventos.Include(e => e.Localidad).Include(e => e.TipoEvento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Evento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var eventos = await _context.Eventos
                .Include(e => e.Localidad)
                .Include(e => e.TipoEvento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventos == null)
            {
                return NotFound();
            }

            return View(eventos);
        }

        // GET: Evento/Create
        public IActionResult Create()
        {
            ViewData["Localidad"] = new SelectList(_context.Localidades, "Id", "Nombre");
            ViewData["TipoEvento"] = new SelectList(_context.TipoEventos, "Id", "Nombre");
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreEvento,Lugar,Direccion,FechaEvento,Imagen,NombreArchivo,TipoMIME,LocalidadId,TipoEventoId")] Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "Id", "Id", eventos.LocalidadId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEventos, "Id", "Id", eventos.TipoEventoId);
            return View(eventos);
        }

        // GET: Evento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var eventos = await _context.Eventos.FindAsync(id);
            if (eventos == null)
            {
                return NotFound();
            }
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "Id", "Id", eventos.LocalidadId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEventos, "Id", "Id", eventos.TipoEventoId);
            return View(eventos);
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreEvento,Lugar,Direccion,FechaEvento,Imagen,NombreArchivo,TipoMIME,LocalidadId,TipoEventoId")] Eventos eventos)
        {
            if (id != eventos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventosExists(eventos.Id))
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
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "Id", "Id", eventos.LocalidadId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEventos, "Id", "Id", eventos.TipoEventoId);
            return View(eventos);
        }

        // GET: Evento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var eventos = await _context.Eventos
                .Include(e => e.Localidad)
                .Include(e => e.TipoEvento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventos == null)
            {
                return NotFound();
            }

            return View(eventos);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Eventos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Eventos'  is null.");
            }
            var eventos = await _context.Eventos.FindAsync(id);
            if (eventos != null)
            {
                _context.Eventos.Remove(eventos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventosExists(int id)
        {
          return (_context.Eventos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
