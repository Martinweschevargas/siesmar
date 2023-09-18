using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class ServicioFunerario
    {
        ServicioFunerarioDAO servicioFunerarioDAO = new();

        public List<ServicioFunerarioDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return servicioFunerarioDAO.ObtenerLista(CargaId, fechainicio, fechafin);

        }

        public List<ServicioFunerarioDTO> BienestarVisualizacionServicioFunerario(int CargaId)
        {
            return servicioFunerarioDAO.BienestarVisualizacionServicioFunerario(CargaId);
        }

        public string AgregarRegistro(ServicioFunerarioDTO servicioFunerarioDTO, string? fecha)
        {
            return servicioFunerarioDAO.AgregarRegistro(servicioFunerarioDTO, fecha);
        }

        public ServicioFunerarioDTO EditarFormato(int Codigo)
        { 
            return servicioFunerarioDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioFunerarioDTO servicioFunerarioDTO)
        {
            return servicioFunerarioDAO.ActualizaFormato(servicioFunerarioDTO);
        }

        public bool EliminarFormato(ServicioFunerarioDTO servicioFunerarioDTO)
        {
            return servicioFunerarioDAO.EliminarFormato(servicioFunerarioDTO);
        }

        public bool EliminarCarga(ServicioFunerarioDTO servicioFunerarioDTO)
        {
            return servicioFunerarioDAO.EliminarCarga(servicioFunerarioDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return servicioFunerarioDAO.InsertarDatos(datos, fecha);

        }
    }
}
