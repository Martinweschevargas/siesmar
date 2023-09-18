using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dibinfrater
{
    public class ServicioPublico
    {
        ServicioPublicoDAO servicioPublicoDAO = new();

        public List<ServicioPublicoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return servicioPublicoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ServicioPublicoDTO servicioPublicoDTO, string? fecha)
        {
            return servicioPublicoDAO.AgregarRegistro(servicioPublicoDTO, fecha);
        }

        public ServicioPublicoDTO EditarFormato(int Codigo)
        {
            return servicioPublicoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioPublicoDTO servicioPublicoDTO)
        {
            return servicioPublicoDAO.ActualizaFormato(servicioPublicoDTO);
        }

        public bool EliminarFormato(ServicioPublicoDTO servicioPublicoDTO)
        {
            return servicioPublicoDAO.EliminarFormato(servicioPublicoDTO);
        }

        public bool EliminarCarga(ServicioPublicoDTO servicioPublicoDTO)
        {
            return servicioPublicoDAO.EliminarCarga(servicioPublicoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return servicioPublicoDAO.InsertarDatos(datos, fecha);
        }

    }
}
