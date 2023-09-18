
using Marina.Siesmar.AccesoDatos.Formatos.Direcomar;
using Marina.Siesmar.Entidades.Formatos.Direcomar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Direcomar
{
    public class RecaudacionSubunidadEjectura
    {
        RecaudacionSubunidadEjecturaDAO recaudacionSubunidadEjecturaDAO = new();

        public List<RecaudacionSubunidadEjecturaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return recaudacionSubunidadEjecturaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public List<RecaudacionSubunidadEjecturaDTO> DirecomarVisualizacionRecaudacionSubunidadEjectura(int? CargaId = null, string? fechaInicio =null, string? fechaFin =null)
        {
            return recaudacionSubunidadEjecturaDAO.DirecomarVisualizacionRecaudacionSubunidadEjectura(CargaId, fechaInicio, fechaFin);
        }

        public string AgregarRegistro(RecaudacionSubunidadEjecturaDTO recaudacionSubunidadEjecturaDTO, string? fecha)
        {
            return recaudacionSubunidadEjecturaDAO.AgregarRegistro(recaudacionSubunidadEjecturaDTO, fecha);
        }

        public RecaudacionSubunidadEjecturaDTO EditarFormato(int Codigo)
        {
            return recaudacionSubunidadEjecturaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RecaudacionSubunidadEjecturaDTO recaudacionSubunidadEjecturaDTO)
        {
            return recaudacionSubunidadEjecturaDAO.ActualizaFormato(recaudacionSubunidadEjecturaDTO);
        }

        public bool EliminarFormato(RecaudacionSubunidadEjecturaDTO recaudacionSubunidadEjecturaDTO)
        {
            return recaudacionSubunidadEjecturaDAO.EliminarFormato(recaudacionSubunidadEjecturaDTO);
        }

        public bool EliminarCarga(RecaudacionSubunidadEjecturaDTO recaudacionSubunidadEjecturaDTO)
        {
            return recaudacionSubunidadEjecturaDAO.EliminarCarga(recaudacionSubunidadEjecturaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return recaudacionSubunidadEjecturaDAO.InsertarDatos(datos, fecha);
        }

    }
}
