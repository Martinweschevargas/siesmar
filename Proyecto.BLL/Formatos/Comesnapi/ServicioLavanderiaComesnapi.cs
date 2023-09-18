
using Marina.Siesmar.AccesoDatos.Formatos.Comesnapi;
using Marina.Siesmar.Entidades.Formatos.Comesnapi;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comesnapi
{
    public class ServicioLavanderiaComesnapi
    {
        ServicioLavanderiaComesnapiDAO servicioLavanderiaComesnapiDAO = new();

        public List<ServicioLavanderiaComesnapiDTO> ObtenerLista(int? CargaId = null)
        {
            return servicioLavanderiaComesnapiDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ServicioLavanderiaComesnapiDTO servicioLavanderiaComesnapiDTO)
        {
            return servicioLavanderiaComesnapiDAO.AgregarRegistro(servicioLavanderiaComesnapiDTO);
        }

        public ServicioLavanderiaComesnapiDTO BuscarFormato(int Codigo)
        {
            return servicioLavanderiaComesnapiDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioLavanderiaComesnapiDTO servicioLavanderiaComesnapiDTO)
        {
            return servicioLavanderiaComesnapiDAO.ActualizaFormato(servicioLavanderiaComesnapiDTO);
        }

        public bool EliminarFormato(ServicioLavanderiaComesnapiDTO servicioLavanderiaComesnapiDTO)
        {
            return servicioLavanderiaComesnapiDAO.EliminarFormato(servicioLavanderiaComesnapiDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return servicioLavanderiaComesnapiDAO.InsertarDatos(datos);
        }

    }
}
