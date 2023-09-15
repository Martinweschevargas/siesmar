using Marina.Siesmar.AccesoDatos.Formatos.Diredumar;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diredumar
{
    public class CapacitacionPerfeccionamientoExtraM
    {
        CapacitacionPerfeccionamientoExtraMDAO capacitacionPerfeccionamientoExtraMDAO = new();

        public List<CapacitacionPerfeccionamientoExtraMDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return capacitacionPerfeccionamientoExtraMDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public List<CapacitacionPerfeccionamientoExtraMDTO> DiredumarVisualizacionCapacitacionPerfeccionamientoExtraPSubalterno(int? CargaId = null)
        {
            return capacitacionPerfeccionamientoExtraMDAO.DiredumarVisualizacionCapacitacionPerfeccionamientoExtraPSubalterno(CargaId);
        }

        public string AgregarRegistro(CapacitacionPerfeccionamientoExtraMDTO capacitacionPerfeccionamientoExtraMDTO, string? fecha)
        {
            return capacitacionPerfeccionamientoExtraMDAO.AgregarRegistro(capacitacionPerfeccionamientoExtraMDTO, fecha);
        }

        public CapacitacionPerfeccionamientoExtraMDTO EditarFormato(int Codigo)
        {
            return capacitacionPerfeccionamientoExtraMDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CapacitacionPerfeccionamientoExtraMDTO capacitacionPerfeccionamientoExtraMDTO)
        {
            return capacitacionPerfeccionamientoExtraMDAO.ActualizaFormato(capacitacionPerfeccionamientoExtraMDTO);
        }

        public bool EliminarFormato(CapacitacionPerfeccionamientoExtraMDTO capacitacionPerfeccionamientoExtraMDTO)
        {
            return capacitacionPerfeccionamientoExtraMDAO.EliminarFormato(capacitacionPerfeccionamientoExtraMDTO);
        }

        public bool EliminarCarga(CapacitacionPerfeccionamientoExtraMDTO capacitacionPerfeccionamientoExtraMDTO)
        {
            return capacitacionPerfeccionamientoExtraMDAO.EliminarCarga(capacitacionPerfeccionamientoExtraMDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return capacitacionPerfeccionamientoExtraMDAO.InsertarDatos(datos, fecha);
        }

    }
}
