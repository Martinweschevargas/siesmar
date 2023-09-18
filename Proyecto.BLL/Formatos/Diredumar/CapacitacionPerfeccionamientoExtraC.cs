using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Diredumar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diredumar
{
    public class CapacitacionPerfeccionamientoExtraC
    {
        CapacitacionPerfeccionamientoExtraCDAO capacitacionPerfeccionamientoExtraCDAO = new();

        public List<CapacitacionPerfeccionamientoExtraCDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return capacitacionPerfeccionamientoExtraCDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public List<CapacitacionPerfeccionamientoExtraCDTO> DiredumarVisualizacionCapacitacionPerfeccionamientoExtraPCivil(int? CargaId = null)
        {
            return capacitacionPerfeccionamientoExtraCDAO.DiredumarVisualizacionCapacitacionPerfeccionamientoExtraPCivil(CargaId);
        }

        public string AgregarRegistro(CapacitacionPerfeccionamientoExtraCDTO capacitacionPerfeccionamientoExtraCDTO, string? fecha = null)
        {
            return capacitacionPerfeccionamientoExtraCDAO.AgregarRegistro(capacitacionPerfeccionamientoExtraCDTO, fecha);
        }

        public CapacitacionPerfeccionamientoExtraCDTO EditarFormado(int Codigo)
        {
            return capacitacionPerfeccionamientoExtraCDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CapacitacionPerfeccionamientoExtraCDTO capacitacionPerfeccionamientoExtraCDTO)
        {
            return capacitacionPerfeccionamientoExtraCDAO.ActualizaFormato(capacitacionPerfeccionamientoExtraCDTO);
        }

        public bool EliminarFormato(CapacitacionPerfeccionamientoExtraCDTO capacitacionPerfeccionamientoExtraCDTO)
        {
            return capacitacionPerfeccionamientoExtraCDAO.EliminarFormato(capacitacionPerfeccionamientoExtraCDTO);
        }

        public bool EliminarCarga(CapacitacionPerfeccionamientoExtraCDTO capacitacionPerfeccionamientoExtraCDTO)
        {
            return capacitacionPerfeccionamientoExtraCDAO.EliminarCarga(capacitacionPerfeccionamientoExtraCDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return capacitacionPerfeccionamientoExtraCDAO.InsertarDatos(datos,fecha);
        }

    }
}
