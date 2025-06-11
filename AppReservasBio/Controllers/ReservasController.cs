using AppReservasBio.Data;
using AppReservasBio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppReservasBio.Controllers
{
    public class ReservasController : Controller
    {
        private readonly AppDbContext _context;

        public ReservasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Reservas/Crear
        public IActionResult Crear()
        {
            ViewBag.Laboratorios = _context.Laboratorios.ToList();
            ViewBag.Modulos = _context.ModulosHorario.ToList();
            ViewBag.Reactivos = _context.Reactivos.ToList();
            ViewBag.Equipos = _context.Equipos.ToList();
            ViewBag.Docentes = _context.Docentes.ToList();
            ViewBag.Unidades = _context.Unidades.ToList();
            return View();
        }

        // POST: /Reservas/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(
            Reserva reserva,
            IFormFile EvidenciaCorreoRuta,
            List<Estudiante> estudiantes,
            List<int> equipoIds,
            List<int> reactivosSeleccionados,
            Dictionary<int, int> cantidades,
            Dictionary<int, string> unidades)
        {
            var reservasExistentes = _context.Reservas
                .Count(r => r.Fecha == reserva.Fecha &&
                            r.LaboratorioId == reserva.LaboratorioId &&
                            r.ModuloHorarioId == reserva.ModuloHorarioId);

            if (reservasExistentes >= 3)
            {
                ModelState.AddModelError("", "Ya existen 3 reservas para ese laboratorio, módulo y fecha.");
                ViewBag.Laboratorios = _context.Laboratorios.ToList();
                ViewBag.Modulos = _context.ModulosHorario.ToList();
                ViewBag.Reactivos = _context.Reactivos.ToList();
                ViewBag.Equipos = _context.Equipos.ToList();
                ViewBag.Docentes = _context.Docentes.ToList();
                ViewBag.Unidades = _context.Unidades.ToList();
                return View(reserva);
            }

            // Validar y guardar la evidencia
            if (EvidenciaCorreoRuta != null && EvidenciaCorreoRuta.Length > 0)
            {
                var nombreArchivo = Path.GetFileName(EvidenciaCorreoRuta.FileName);
                var rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "evidencia");
                Directory.CreateDirectory(rutaCarpeta);

                var rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);
                using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                {
                    await EvidenciaCorreoRuta.CopyToAsync(stream);
                }

                // Guardar ruta relativa para usarla en la web
                reserva.EvidenciaCorreoRuta = "/evidencia/" + nombreArchivo;
            }
            else
            {
                ModelState.AddModelError("EvidenciaCorreoRuta", "Debe subir una imagen como evidencia.");
                ViewBag.Laboratorios = _context.Laboratorios.ToList();
                ViewBag.Modulos = _context.ModulosHorario.ToList();
                ViewBag.Reactivos = _context.Reactivos.ToList();
                ViewBag.Equipos = _context.Equipos.ToList();
                ViewBag.Docentes = _context.Docentes.ToList();
                ViewBag.Unidades = _context.Unidades.ToList();
                return View(reserva);
            }

            // Estudiantes
            reserva.Estudiantes = estudiantes;

            // Equipos
            reserva.Equipos = _context.Equipos
                .Where(e => equipoIds.Contains(e.Id))
                .ToList();

            // Reactivos con cantidad y unidad
            reserva.ReservaReactivos = new List<ReservaReactivo>();
            foreach (var reactivoId in reactivosSeleccionados)
            {
                if (cantidades.TryGetValue(reactivoId, out int cantidad) && cantidad > 0 &&
                    unidades.TryGetValue(reactivoId, out string unidad) && !string.IsNullOrWhiteSpace(unidad))
                {
                    reserva.ReservaReactivos.Add(new ReservaReactivo
                    {
                        ReactivoId = reactivoId,
                        Cantidad = cantidad,
                        Unidad = unidad
                    });
                }
            }

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Listado()
        {
            var reservas = _context.Reservas
                .Include(r => r.Laboratorio)
                .Include(r => r.ModuloHorario)
                .Include(r => r.Docente) // <--- Agregar esto
                .Include(r => r.Estudiantes)
                .Include(r => r.Equipos)
                .Include(r => r.ReservaReactivos)
                    .ThenInclude(rr => rr.Reactivo)
                .OrderByDescending(r => r.Fecha)
                .ToList();

            return View(reservas);
        }

        public IActionResult Detalle(int id)
        {
            var reserva = _context.Reservas
                .Include(r => r.Laboratorio)
                .Include(r => r.ModuloHorario)
                .Include(r => r.Docente)
                .Include(r => r.Estudiantes)
                .Include(r => r.Equipos)
                .Include(r => r.ReservaReactivos)
                    .ThenInclude(rr => rr.Reactivo)
                .FirstOrDefault(r => r.Id == id);

            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        [HttpPost]
        public IActionResult Aprobar(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva != null)
            {
                reserva.Aprobado = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Listado");
        }

        [HttpPost]
        public IActionResult Rechazar(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva != null)
            {
                reserva.Aprobado = false;
                _context.SaveChanges();
            }
            return RedirectToAction("Listado");
        }

        public IActionResult Calendario()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerReservas()
        {
            var reservas = _context.Reservas
        .Include(r => r.Laboratorio)
        .Include(r => r.ModuloHorario)
        .Select(r => new
        {
            title = $"Reserva - {r.Laboratorio.Nombre}",
            start = r.Fecha.Date.Add(r.ModuloHorario.HoraInicio),
            end = r.Fecha.Date.Add(r.ModuloHorario.HoraFin),
            laboratorio = r.Laboratorio.Nombre
        }).ToList();

            return Json(reservas);
        }
    }
}
