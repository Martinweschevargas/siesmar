using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class AlquilerAreaCentroEsparcimiento
    {
        AlquilerAreaCentroEsparcimientoDAO alquilerAreaCentroEsparcimientoDAO = new();

        public List<AlquilerAreaCentroEsparcimientoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alquilerAreaCentroEsparcimientoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public List<AlquilerAreaCentroEsparcimientoDTO> BienestarVisualizacionAlquilerAreaCentroEsparcimiento(int CargaId)
        {
            return alquilerAreaCentroEsparcimientoDAO.BienestarVisualizacionAlquilerAreaCentroEsparcimiento(CargaId);
        }

        public string AgregarRegistro(AlquilerAreaCentroEsparcimientoDTO alquilerAreaCentroEsparcimientoDTO, string? fecha)
        {
            return alquilerAreaCentroEsparcimientoDAO.AgregarRegistro(alquilerAreaCentroEsparcimientoDTO, fecha);
        }

        public AlquilerAreaCentroEsparcimientoDTO EditarFormado(int Codigo)
        {
            return alquilerAreaCentroEsparcimientoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlquilerAreaCentroEsparcimientoDTO alquilerAreaCentroEsparcimientoDTO)
        {
            return alquilerAreaCentroEsparcimientoDAO.ActualizaFormato(alquilerAreaCentroEsparcimientoDTO);
        }

        public bool EliminarFormato(AlquilerAreaCentroEsparcimientoDTO alquilerAreaCentroEsparcimientoDTO)
        {
            return alquilerAreaCentroEsparcimientoDAO.EliminarFormato(alquilerAreaCentroEsparcimientoDTO);
        }

        public bool EliminarCarga(AlquilerAreaCentroEsparcimientoDTO alquilerAreaCentroEsparcimientoDTO)
        {
            return alquilerAreaCentroEsparcimientoDAO.EliminarCarga(alquilerAreaCentroEsparcimientoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alquilerAreaCentroEsparcimientoDAO.InsertarDatos(datos, fecha);
        }

    }
}
