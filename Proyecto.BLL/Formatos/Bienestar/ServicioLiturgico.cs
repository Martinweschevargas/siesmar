using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class ServicioLiturgico
    {
        ServicioLiturgicoDAO servicioLiturgicoDAO = new();

        public List<ServicioLiturgicoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return servicioLiturgicoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public List<ServicioLiturgicoDTO> BienestarVisualizacionServicioLiturgico(int CargaId)
        {
            return servicioLiturgicoDAO.BienestarVisualizacionServicioLiturgico(CargaId);
        }

        public string AgregarRegistro(ServicioLiturgicoDTO servicioLiturgicoDTO, string fecha)
        {
            return servicioLiturgicoDAO.AgregarRegistro(servicioLiturgicoDTO, fecha);
        }

        public ServicioLiturgicoDTO EditarFormato(int Codigo)
        {
            return servicioLiturgicoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioLiturgicoDTO servicioLiturgicoDTO)
        {
            return servicioLiturgicoDAO.ActualizaFormato(servicioLiturgicoDTO);
        }

        public bool EliminarFormato(ServicioLiturgicoDTO servicioLiturgicoDTO)
        {
            return servicioLiturgicoDAO.EliminarFormato(servicioLiturgicoDTO);
        }

        public bool EliminarCarga(ServicioLiturgicoDTO servicioLiturgicoDTO)
        {
            return servicioLiturgicoDAO.EliminarCarga(servicioLiturgicoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return servicioLiturgicoDAO.InsertarDatos(datos, fecha);
        }

    }
}
