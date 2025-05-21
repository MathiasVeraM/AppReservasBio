using AppReservasBio.Models;

namespace AppReservasBio.ViewModels
{
    public class ReservaViewModel
    {
        public DateTime Fecha { get; set; }
        public int LaboratorioId { get; set; }
        public int ModuloHorarioId { get; set; }

        public List<Estudiante> Estudiantes { get; set; }
        public List<int> EquiposSeleccionados { get; set; }
        public List<int> ReactivosSeleccionados { get; set; }

        public List<Laboratorio> LaboratoriosDisponibles { get; set; }
        public List<ModuloHorario> ModulosDisponibles { get; set; }
        public List<Equipo> EquiposDisponibles { get; set; }
        public List<Reactivo> ReactivosDisponibles { get; set; }
    }
}
