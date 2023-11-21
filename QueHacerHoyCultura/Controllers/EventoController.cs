using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QueHacerHoyCultura;
using QueHacerHoyCultura.Entidades;
using QueHacerHoyCultura.ViewModels;

namespace QueHacerHoyCultura.Controllers
{
    public class EventoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventoController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Create(EventoViewModels model)
        {
            string uniqueFileName = UploadedFile(model);
            if (ModelState.IsValid)
            {
                Eventos evento = new Eventos()
                {
                    ImagenEvento = uniqueFileName,
                    NombreEvento = model.NombreEvento,
                    Lugar = model.Lugar,
                    Direccion = model.Direccion,
                    FechaEvento = model.FechaEvento,
                    LocalidadId = model.LocalidadId,
                    TipoEventoId = model.TipoEventoId

                };
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "Id", "Id", model.LocalidadId);
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEventos, "Id", "Id", model.TipoEventoId);
            return View(model);
        }

        private string UploadedFile(EventoViewModels model)
        {
            string uniqueFileName = null;

            if (model.Imagen != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Imagen.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Imagen.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreEvento,Lugar,Direccion,FechaEvento,ImagenEvento,LocalidadId,TipoEventoId")] Eventos eventos)
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
