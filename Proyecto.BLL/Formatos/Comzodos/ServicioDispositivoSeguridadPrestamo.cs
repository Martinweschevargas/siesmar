using Marina.Siesmar.AccesoDatos.Formatos.Comzodos;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comzodos;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzodos
{
    public class ServicioDispositivoSeguridadPrestado
    {
        ServicioDispositivoSeguridadPrestadoDAO servicioDispositivoSeguridadPrestadoDAO = new();

        public List<ServicioDispositivoSeguridadPrestadoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return servicioDispositivoSeguridadPrestadoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ServicioDispositivoSeguridadPrestadoDTO servicioDispositivoSeguridadPrestado, string? fecha)
        {
            return servicioDispositivoSeguridadPrestadoDAO.AgregarRegistro(servicioDispositivoSeguridadPrestado, fecha);
        }

        public ServicioDispositivoSeguridadPrestadoDTO BuscarFormato(int Codigo)
        {
            return servicioDispositivoSeguridadPrestadoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioDispositivoSeguridadPrestadoDTO servicioDispositivoSeguridadPrestadoDTO)
        {
            return servicioDispositivoSeguridadPrestadoDAO.ActualizaFormato(servicioDispositivoSeguridadPrestadoDTO);
        }

        public bool EliminarFormato(ServicioDispositivoSeguridadPrestadoDTO servicioDispositivoSeguridadPrestadoDTO)
        {
            return servicioDispositivoSeguridadPrestadoDAO.EliminarFormato( servicioDispositivoSeguridadPrestadoDTO);
        }

        public bool EliminarCarga(ServicioDispositivoSeguridadPrestadoDTO servicioDispositivoSeguridadPrestadoDTO)
        {
            return servicioDispositivoSeguridadPrestadoDAO.EliminarCarga(servicioDispositivoSeguridadPrestadoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return servicioDispositivoSeguridadPrestadoDAO.InsertarDatos(datos, fecha);
        }

    }
}
