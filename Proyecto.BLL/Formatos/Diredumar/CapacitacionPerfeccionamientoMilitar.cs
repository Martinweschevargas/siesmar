using Marina.Siesmar.AccesoDatos.Formatos.Diredumar;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diredumar
{
    public class CapacitacionPerfeccionamientoMilitar
    {
        CapacitacionPerfeccionamientoMilitarDAO capacitacionPerfeccionamientoMilitarDAO = new();

        public List<CapacitacionPerfeccionamientoMilitarDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return capacitacionPerfeccionamientoMilitarDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public List<CapacitacionPerfeccionamientoMilitarDTO> DiredumarVisualizacionCapacitacionPerfeccionamientoMilitarPSuperior(int? CargaId = null)
        {
            return capacitacionPerfeccionamientoMilitarDAO.DiredumarVisualizacionCapacitacionPerfeccionamientoMilitarPSuperior(CargaId);
        }

        public string AgregarRegistro(CapacitacionPerfeccionamientoMilitarDTO capacitacionPerfeccionamientoMilitarDTO, string? fecha)
        {
            return capacitacionPerfeccionamientoMilitarDAO.AgregarRegistro(capacitacionPerfeccionamientoMilitarDTO, fecha);
        }

        public CapacitacionPerfeccionamientoMilitarDTO EditarFormado(int Codigo)
        {
            return capacitacionPerfeccionamientoMilitarDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CapacitacionPerfeccionamientoMilitarDTO capacitacionPerfeccionamientoMilitarDTO)
        {
            return capacitacionPerfeccionamientoMilitarDAO.ActualizaFormato(capacitacionPerfeccionamientoMilitarDTO);
        }

        public bool EliminarFormato(CapacitacionPerfeccionamientoMilitarDTO capacitacionPerfeccionamientoMilitarDTO)
        {
            return capacitacionPerfeccionamientoMilitarDAO.EliminarFormato(capacitacionPerfeccionamientoMilitarDTO);
        }

        public bool EliminarCarga(CapacitacionPerfeccionamientoMilitarDTO capacitacionPerfeccionamientoMilitarDTO)
        {
            return capacitacionPerfeccionamientoMilitarDAO.EliminarCarga(capacitacionPerfeccionamientoMilitarDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return capacitacionPerfeccionamientoMilitarDAO.InsertarDatos(datos, fecha);
        }

    }
}
