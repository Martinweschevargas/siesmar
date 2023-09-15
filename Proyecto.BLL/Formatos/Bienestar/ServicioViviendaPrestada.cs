using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class ServicioViviendaPrestada
    {
        ServicioViviendaPrestadaDAO servicioViviendaPrestadaDAO = new();

        public List<ServicioViviendaPrestadaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return servicioViviendaPrestadaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        //public List<ServicioViviendaPrestadaDTO> BienestarVisualizacionServicioViviendaPrestada(int? CargaId=null, string? fechaInicio=null, string? fechaFin=null)
        //{
        //    return servicioViviendaPrestadaDAO.BienestarVisualizacionServicioViviendaPrestada(CargaId, fechaInicio,fechaFin);
        //}

        public string AgregarRegistro(ServicioViviendaPrestadaDTO servicioViviendaPrestadaDTO, string? fecha)
        {
            return servicioViviendaPrestadaDAO.AgregarRegistro(servicioViviendaPrestadaDTO, fecha);
        }

        public ServicioViviendaPrestadaDTO EditarFormato(int Codigo)
        {
            return servicioViviendaPrestadaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioViviendaPrestadaDTO servicioViviendaPrestadaDTO)
        {
            return servicioViviendaPrestadaDAO.ActualizaFormato(servicioViviendaPrestadaDTO);
        }

        public bool EliminarFormato(ServicioViviendaPrestadaDTO servicioViviendaPrestadaDTO)
        {
            return servicioViviendaPrestadaDAO.EliminarFormato(servicioViviendaPrestadaDTO);
        }

        public bool EliminarCarga(ServicioViviendaPrestadaDTO servicioViviendaPrestadaDTO)
        {
            return servicioViviendaPrestadaDAO.EliminarCarga(servicioViviendaPrestadaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return servicioViviendaPrestadaDAO.InsertarDatos(datos, fecha);
        }

    }
}
