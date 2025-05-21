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
            return View();
        }

        // POST: /Reservas/Crear
        [HttpPost]
        public IActionResult Crear(Reserva reserva,List<Estudiante> estudiantes,List<int> equipoIds,List<int> reactivosSeleccionados,Dictionary<int, int> cantidades)
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
                return View(reserva);
            }

            reserva.Estudiantes = estudiantes;
            reserva.Equipos = _context.Equipos.Where(e => equipoIds.Contains(e.Id)).ToList();

            // Construir la relación con cantidades
            reserva.ReservaReactivos = new List<ReservaReactivo>();
            foreach (var reactivoId in reactivosSeleccionados)
            {
                if (cantidades.TryGetValue(reactivoId, out int cantidad) && cantidad > 0)
                {
                    reserva.ReservaReactivos.Add(new ReservaReactivo
                    {
                        ReactivoId = reactivoId,
                        Cantidad = cantidad
                    });
                }
            }

            _context.Reservas.Add(reserva);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Listado()
        {
            var reservas = _context.Reservas
                .Include(r => r.Laboratorio)
                .Include(r => r.ModuloHorario)
                .Include(r => r.Estudiantes)
                .Include(r => r.Equipos)
                .Include(r => r.ReservaReactivos)
                    .ThenInclude(rr => rr.Reactivo)
                .OrderByDescending(r => r.Fecha)
                .ToList();

            return View(reservas);
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
