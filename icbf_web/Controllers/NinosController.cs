using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using icbf_web.Data;
using icbf_web.Models;

namespace icbf_web.Controllers
{
    public class NinosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NinosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ninos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ninos.Include(n => n.Jardin).Include(n => n.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ninos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nino = await _context.Ninos
                .Include(n => n.Jardin)
                .Include(n => n.Usuario)
                .FirstOrDefaultAsync(m => m.IdNino == id);
            if (nino == null)
            {
                return NotFound();
            }

            return View(nino);
        }

        // GET: Ninos/Create
        public IActionResult Create()
        {
            ViewData["IdJardin"] = new SelectList(_context.Jardines, "IdJardin", "IdJardin");
            ViewData["IdAcudiente"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Ninos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNino,NombreNino,FechaNacimientoNino,TipoSangreNino,CiudadNacimientoNino,IdAcudiente,TelefonoNino,DireccionNino,EpsNino,IdJardin")] Nino nino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdJardin"] = new SelectList(_context.Jardines, "IdJardin", "IdJardin", nino.IdJardin);
            ViewData["IdAcudiente"] = new SelectList(_context.Users, "Id", "Id", nino.IdAcudiente);
            return View(nino);
        }

        // GET: Ninos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nino = await _context.Ninos.FindAsync(id);
            if (nino == null)
            {
                return NotFound();
            }
            ViewData["IdJardin"] = new SelectList(_context.Jardines, "IdJardin", "DireccionJardin", nino.IdJardin);
            ViewData["IdAcudiente"] = new SelectList(_context.Users, "Id", "Id", nino.IdAcudiente);
            return View(nino);
        }

        // POST: Ninos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdNino,NombreNino,FechaNacimientoNino,TipoSangreNino,CiudadNacimientoNino,IdAcudiente,TelefonoNino,DireccionNino,EpsNino,IdJardin")] Nino nino)
        {
            if (id != nino.IdNino)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NinoExists(nino.IdNino))
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
            ViewData["IdJardin"] = new SelectList(_context.Jardines, "IdJardin", "DireccionJardin", nino.IdJardin);
            ViewData["IdAcudiente"] = new SelectList(_context.Users, "Id", "Id", nino.IdAcudiente);
            return View(nino);
        }

        // GET: Ninos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nino = await _context.Ninos
                .Include(n => n.Jardin)
                .Include(n => n.Usuario)
                .FirstOrDefaultAsync(m => m.IdNino == id);
            if (nino == null)
            {
                return NotFound();
            }

            return View(nino);
        }

        // POST: Ninos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var nino = await _context.Ninos.FindAsync(id);
            if (nino != null)
            {
                _context.Ninos.Remove(nino);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NinoExists(long id)
        {
            return _context.Ninos.Any(e => e.IdNino == id);
        }
    }
}
