using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using icbf_web.Data;
using icbf_web.Models;
using DinkToPdf;
using Microsoft.AspNetCore.Http.Extensions;
using DinkToPdf.Contracts;

namespace icbf_web.Controllers
{
    public class RegistroAsistenciasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConverter _converter;

        public RegistroAsistenciasController(ApplicationDbContext context, IConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        // GET: RegistroAsistencias
        // GET: RegistroAsistencias
        public async Task<IActionResult> Index()
        {
            var registros = await _context.RegistrosAsistencia
                             .Include(ra => ra.Nino) // Incluir la entidad Nino
                             .ToListAsync();
            return View(await _context.RegistrosAsistencia.ToListAsync());
        }

        public async Task<IActionResult> NinosEnfermos()
        {
            var asistenciaNinosEnfermos = await _context.RegistrosAsistencia
                .Where(j => j.EstadoNinoRegistro == "Enfermo") // Filtra por estado "Negado"
                .ToListAsync();

            return View("Index", asistenciaNinosEnfermos);
        }


        public IActionResult MostrarPDFenPagina()
        {
            string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/RegistroAsistencias/NinosEnfermos";

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings(){
                        Page = url_pagina
                    }
                }
            };

            var archivoPDF = _converter.Convert(pdf);

            return File(archivoPDF, "application/pdf");
        }

        public IActionResult DescargarPDF()
        {
            string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/RegistroAsistencias/NinosEnfermos";

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings(){
                        Page = url_pagina
                    }
                }
            };

            var archivoPDF = _converter.Convert(pdf);
            string nombrePDF = "reporte_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            return File(archivoPDF, "application/pdf", nombrePDF);
        }
        // GET: RegistroAsistencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var registros = await _context.RegistrosAsistencia
                             .Include(ra => ra.Nino) // Incluir la entidad Nino
                             .ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            var registroAsistencia = await _context.RegistrosAsistencia
                .FirstOrDefaultAsync(m => m.IdRegistroAsistencia == id);
            if (registroAsistencia == null)
            {
                return NotFound();
            }

            return View(registroAsistencia);
        }

        // GET: RegistroAsistencias/Create
        public async Task<IActionResult>Create()
        {
            ViewBag.Ninos = new SelectList(await _context.Ninos.ToListAsync(), "IdNino", "NombreNino");
            return View();
        }

        // POST: RegistroAsistencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistroAsistencia,FechaRegistro,EstadoNinoRegistro,NinoId")] RegistroAsistencia registroAsistencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroAsistencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Ninos = new SelectList(await _context.Ninos.ToListAsync(), "IdNino", "NombreNino");
            return View(registroAsistencia);
        }

        // GET: RegistroAsistencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroAsistencia = await _context.RegistrosAsistencia.FindAsync(id);
            if (registroAsistencia == null)
            {
                return NotFound();
            }
            ViewBag.Ninos = new SelectList(await _context.Ninos.ToListAsync(), "IdNino", "NombreNino");
            return View(registroAsistencia);
        }

        // POST: RegistroAsistencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistroAsistencia,FechaRegistro,EstadoNinoRegistro,NinoId")] RegistroAsistencia registroAsistencia)
        {
            if (id != registroAsistencia.IdRegistroAsistencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroAsistencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroAsistenciaExists(registroAsistencia.IdRegistroAsistencia))
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
            
            return View(registroAsistencia);
        }

        // GET: RegistroAsistencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroAsistencia = await _context.RegistrosAsistencia
                .FirstOrDefaultAsync(m => m.IdRegistroAsistencia == id);
            if (registroAsistencia == null)
            {
                return NotFound();
            }

            return View(registroAsistencia);
        }

        // POST: RegistroAsistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroAsistencia = await _context.RegistrosAsistencia.FindAsync(id);
            if (registroAsistencia != null)
            {
                _context.RegistrosAsistencia.Remove(registroAsistencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroAsistenciaExists(int id)
        {
            return _context.RegistrosAsistencia.Any(e => e.IdRegistroAsistencia == id);
        }
    }
}
