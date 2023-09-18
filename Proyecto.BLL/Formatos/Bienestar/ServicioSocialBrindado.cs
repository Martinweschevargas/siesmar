using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class ServicioSocialBrindado
    {
        ServicioSocialBrindadoDAO servicioSocialBrindadoDAO = new();

        public List<ServicioSocialBrindadoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return servicioSocialBrindadoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public List<ServicioSocialBrindadoDTO> BienestarVisualizacionServicioSocialBrindadoPersonal(int? CargaId=null, string? fechaInicio=null, string? fechaFin=null)
        {
            return servicioSocialBrindadoDAO.BienestarVisualizacionServicioSocialBrindadoPersonal(CargaId, fechaInicio, fechaFin);
        }

        public string AgregarRegistro(ServicioSocialBrindadoDTO servicioSocialBrindadoDTO, string fecha)
        {
            return servicioSocialBrindadoDAO.AgregarRegistro(servicioSocialBrindadoDTO, fecha);
        }

        public ServicioSocialBrindadoDTO EditarFormato(int Codigo)
        {
            return servicioSocialBrindadoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioSocialBrindadoDTO servicioSocialBrindadoDTO)
        {
            return servicioSocialBrindadoDAO.ActualizaFormato(servicioSocialBrindadoDTO);
        }

        public bool EliminarFormato(ServicioSocialBrindadoDTO servicioSocialBrindadoDTO)
        {
            return servicioSocialBrindadoDAO.EliminarFormato(servicioSocialBrindadoDTO);
        }

        public bool EliminarCarga(ServicioSocialBrindadoDTO servicioSocialBrindadoDTO)
        {
            return servicioSocialBrindadoDAO.EliminarCarga(servicioSocialBrindadoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return servicioSocialBrindadoDAO.InsertarDatos(datos, fecha);
        }


    }
}
