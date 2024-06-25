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
    public class RegistroAvanceAcademicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroAvanceAcademicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroAvanceAcademico
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistrosAvanceAcademicos.ToListAsync());
        }

        // GET: RegistroAvanceAcademico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroAvanceAcademico = await _context.RegistrosAvanceAcademicos
                .FirstOrDefaultAsync(m => m.IdAvance == id);
            if (registroAvanceAcademico == null)
            {
                return NotFound();
            }

            return View(registroAvanceAcademico);
        }

        // GET: RegistroAvanceAcademico/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Ninos = new SelectList(await _context.Ninos.ToListAsync(), "IdNino", "NombreNino");
            return View();
        }

        // POST: RegistroAvanceAcademico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAvance,NinoId,AnioEscolarAvance,NivelAvance,NotaAvance,DescripcionAvance,FechaEntregaAvance")] RegistroAvanceAcademico registroAvanceAcademico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroAvanceAcademico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Ninos = new SelectList(await _context.Ninos.ToListAsync(), "IdNino", "NombreNino");
            return View(registroAvanceAcademico);
        }

        // GET: RegistroAvanceAcademico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroAvanceAcademico = await _context.RegistrosAvanceAcademicos.FindAsync(id);
            if (registroAvanceAcademico == null)
            {
                return NotFound();
            }
            ViewBag.Ninos = new SelectList(await _context.Ninos.ToListAsync(), "IdNino", "NombreNino");
            return View(registroAvanceAcademico);
        }

        // POST: RegistroAvanceAcademico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAvance,NinoId,AnioEscolarAvance,NivelAvance,NotaAvance,DescripcionAvance,FechaEntregaAvance")] RegistroAvanceAcademico registroAvanceAcademico)
        {
            if (id != registroAvanceAcademico.IdAvance)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroAvanceAcademico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroAvanceAcademicoExists(registroAvanceAcademico.IdAvance))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Ninos = new SelectList(await _context.Ninos.ToListAsync(), "IdNino", "NombreNino");
                return RedirectToAction(nameof(Index));
            }
            return View(registroAvanceAcademico);
        }

        // GET: RegistroAvanceAcademico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroAvanceAcademico = await _context.RegistrosAvanceAcademicos
                .FirstOrDefaultAsync(m => m.IdAvance == id);
            if (registroAvanceAcademico == null)
            {
                return NotFound();
            }

            return View(registroAvanceAcademico);
        }

        // POST: RegistroAvanceAcademico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroAvanceAcademico = await _context.RegistrosAvanceAcademicos.FindAsync(id);
            if (registroAvanceAcademico != null)
            {
                _context.RegistrosAvanceAcademicos.Remove(registroAvanceAcademico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroAvanceAcademicoExists(int id)
        {
            return _context.RegistrosAvanceAcademicos.Any(e => e.IdAvance == id);
        }
    }
}
