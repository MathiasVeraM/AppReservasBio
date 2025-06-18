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

            if (!reserva.EsMantenimiento)
            {
                if (string.IsNullOrWhiteSpace(reserva.Materia) ||
                    string.IsNullOrWhiteSpace(reserva.NombreProyecto) ||
                    string.IsNullOrWhiteSpace(reserva.Actividad) ||
                    reserva.ModuloHorarioId == null ||
                    reserva.DocenteId == null ||
                    string.IsNullOrWhiteSpace(reserva.EvidenciaCorreoRuta))
                {
                    ModelState.AddModelError("", "Todos los campos del formulario son obligatorios.");
                    ViewBag.Laboratorios = _context.Laboratorios.ToList();
                    ViewBag.Modulos = _context.ModulosHorario.ToList();
                    ViewBag.Reactivos = _context.Reactivos.ToList();
                    ViewBag.Equipos = _context.Equipos.ToList();
                    ViewBag.Docentes = _context.Docentes.ToList();
                    ViewBag.Unidades = _context.Unidades.ToList();
                    return View(reserva);
                }
            }

            var hayMantenimiento = await _context.Reservas.AnyAsync(r =>
            r.EsMantenimiento &&
            r.Fecha == reserva.Fecha &&
            r.LaboratorioId == reserva.LaboratorioId &&
            reserva.ModuloHorarioId != null &&
            r.HoraInicioMantenimiento < _context.ModulosHorario
                .Where(m => m.Id == reserva.ModuloHorarioId)
                .Select(m => m.HoraFin)
                .FirstOrDefault() &&
            r.HoraFinMantenimiento > _context.ModulosHorario
                .Where(m => m.Id == reserva.ModuloHorarioId)
                .Select(m => m.HoraInicio)
                .FirstOrDefault());

            if (hayMantenimiento)
            {
                ModelState.AddModelError("", "No se puede crear la reserva: existe un mantenimiento programado para ese horario.");
                ViewBag.Laboratorios = _context.Laboratorios.ToList();
                ViewBag.Modulos = _context.ModulosHorario.ToList();
                ViewBag.Reactivos = _context.Reactivos.ToList();
                ViewBag.Equipos = _context.Equipos.ToList();
                ViewBag.Docentes = _context.Docentes.ToList();
                ViewBag.Unidades = _context.Unidades.ToList();
                return View(reserva);
            }

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return RedirectToAction("Calendario", "Reservas");
        }

        public IActionResult Listado()
        {
            var reservas = _context.Reservas
                .Include(r => r.Laboratorio)
                .Include(r => r.ModuloHorario)
                .Include(r => r.Docente)
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return RedirectToAction("Listado");
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

        [HttpGet]
        public IActionResult CrearMantenimiento()
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("admin"))
                return RedirectToAction("Login", "Cuenta");

            ViewBag.Laboratorios = _context.Laboratorios.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearMantenimiento(Reserva reserva)
        {
            if (!User.Identity.IsAuthenticated || !User.IsInRole("admin"))
                return RedirectToAction("Login", "Cuenta");

            if (reserva.HoraInicioMantenimiento == null || reserva.HoraFinMantenimiento == null)
            {
                ModelState.AddModelError("", "Debe especificar el horario.");
                ViewBag.Laboratorios = _context.Laboratorios.ToList();
                return View(reserva);
            }

            // Validación de conflictos
            var conflicto = _context.Reservas.Any(r =>
                r.Fecha == reserva.Fecha &&
                r.LaboratorioId == reserva.LaboratorioId &&
                (
                    (r.EsMantenimiento && reserva.HoraInicioMantenimiento < r.HoraFinMantenimiento && reserva.HoraFinMantenimiento > r.HoraInicioMantenimiento)
                    || (!r.EsMantenimiento && r.ModuloHorario.HoraInicio < reserva.HoraFinMantenimiento && r.ModuloHorario.HoraFin > reserva.HoraInicioMantenimiento)
                ));

            if (conflicto)
            {
                ModelState.AddModelError("", "Ya existe una reserva en ese horario.");
                ViewBag.Laboratorios = _context.Laboratorios.ToList();
                return View(reserva);
            }

            reserva.EsMantenimiento = true;
            reserva.UsuarioId = User.FindFirst("UserId")?.Value;

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return RedirectToAction("Calendario");
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
                    title = r.EsMantenimiento
                        ? $"Mantenimiento - {r.Laboratorio.Nombre}"
                        : $"Reserva - {r.Laboratorio.Nombre}",
                    start = r.EsMantenimiento
                        ? r.Fecha.Date.Add(r.HoraInicioMantenimiento.Value)
                        : r.Fecha.Date.Add(r.ModuloHorario.HoraInicio),
                    end = r.EsMantenimiento
                        ? r.Fecha.Date.Add(r.HoraFinMantenimiento.Value)
                        : r.Fecha.Date.Add(r.ModuloHorario.HoraFin),
                    laboratorio = r.Laboratorio.Nombre,
                    color = r.EsMantenimiento ? "#dc3545" : "#198754", // rojo vs verde
                }).ToList();

            return Json(reservas);
        }
    }
}
