using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using icbf_web.Data;
using icbf_web.Models;
using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.Http.Extensions;

namespace icbf_web.Controllers
{
    public class JardinController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConverter _converter;

        public JardinController(ApplicationDbContext context, IConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        // GET: Jardin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jardines.ToListAsync());
        }
        public async Task<IActionResult> NoAprobados()
        {
            var jardinesNoAprobados = await _context.Jardines
                .Where(j => j.EstadoJardin == "Negado") // Filtra por estado "Negado"
                .ToListAsync();

            return View("Index", jardinesNoAprobados);
        }

        public IActionResult MostrarPDFenPagina()
        {
            string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/Jardin/NoAprobados";

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
            url_pagina = $"{url_pagina}/Jardin/NoAprobados";

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
        // GET: Jardin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jardin = await _context.Jardines
                .FirstOrDefaultAsync(m => m.IdJardin == id);
            if (jardin == null)
            {
                return NotFound();
            }

            return View(jardin);
        }

        // GET: Jardin/Create
        public IActionResult Create()
        {
            EstadoJardin();
            return View();
        }

        // POST: Jardin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJardin,NombreJardin,DireccionJardin,EstadoJardin")] Jardin jardin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jardin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            EstadoJardin();
            return View(jardin);
        }

        // GET: Jardin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jardin = await _context.Jardines.FindAsync(id);
            if (jardin == null)
            {
                return NotFound();
            }
            EstadoJardin();
            return View(jardin);
        }

        // POST: Jardin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJardin,NombreJardin,DireccionJardin,EstadoJardin")] Jardin jardin)
        {
            if (id != jardin.IdJardin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jardin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JardinExists(jardin.IdJardin))
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
            EstadoJardin();
            return View(jardin);
        }

        // GET: Jardin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jardin = await _context.Jardines
                .FirstOrDefaultAsync(m => m.IdJardin == id);
            if (jardin == null)
            {
                return NotFound();
            }

            return View(jardin);
        }

        // POST: Jardin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jardin = await _context.Jardines.FindAsync(id);
            if (jardin != null)
            {
                _context.Jardines.Remove(jardin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JardinExists(int id)
        {
            return _context.Jardines.Any(e => e.IdJardin == id);
        }
        private void EstadoJardin()
        {
            ViewBag.EstadoJardin = new List<SelectListItem>
            {
                new SelectListItem { Text = "Seleccione un estado", Value = ""},
                new SelectListItem { Text = "Aprobado", Value = "Aprobado" },
                new SelectListItem { Text = "En tramite", Value = "En tramite" },
                new SelectListItem { Text = "Negado", Value = "Negado" }
            };
        }
    }
}
