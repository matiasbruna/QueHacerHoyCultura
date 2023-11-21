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
    public class LocalidadController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LocalidadController> _logger;

        public LocalidadController(ApplicationDbContext context, ILogger<LocalidadController> logger)
        {
            _context = context;
            _logger = logger;
        }



        // GET: Localidad
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Localidades.Include(l => l.Provincia);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Localidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Localidades == null)
            {
                return NotFound();
            }

            var localidad = await _context.Localidades
                .Include(l => l.Provincia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localidad == null)
            {
                return NotFound();
            }

            return View(localidad);
        }

        // GET: Localidad/Create
        public IActionResult Create()
        {
            ViewData["Provincias"] = new SelectList(_context.Provincias, "Id", "Nombre");
            return View();
        }

        // POST: Localidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,ProvinciaId")] Localidad localidad)
        {
            try
            {
                _logger.LogInformation("Antes de agregar a la base de datos");

                if (ModelState.IsValid)
                {
                    _context.Add(localidad);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Localidad  guardada exitosamente!");

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogInformation("ModelState no es válido. No se guarda en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al guardar: {ex.Message}");

                ModelState.AddModelError("", $"Error al guardar: {ex.Message}");
            }

            _logger.LogInformation("Después de intentar guardar en la base de datos");

            ViewData["ProvinciasId"] = new SelectList(_context.Provincias, "Id", "id", localidad.ProvinciaId);
            return View(localidad);
        }


        // GET: Localidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Localidades == null)
            {
                return NotFound();
            }

            var localidad = await _context.Localidades.FindAsync(id);
            if (localidad == null)
            {
                return NotFound();
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "Id", "Id", localidad.ProvinciaId);
            return View(localidad);
        }

        // POST: Localidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,ProvinciaId")] Localidad localidad)
        {
            if (id != localidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalidadExists(localidad.Id))
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
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "Id", "Id", localidad.ProvinciaId);
            return View(localidad);
        }

        // GET: Localidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Localidades == null)
            {
                return NotFound();
            }

            var localidad = await _context.Localidades
                .Include(l => l.Provincia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localidad == null)
            {
                return NotFound();
            }

            return View(localidad);
        }

        // POST: Localidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Localidades == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Localidades'  is null.");
            }
            var localidad = await _context.Localidades.FindAsync(id);
            if (localidad != null)
            {
                _context.Localidades.Remove(localidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalidadExists(int id)
        {
          return (_context.Localidades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
