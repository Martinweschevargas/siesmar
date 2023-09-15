
using Marina.Siesmar.AccesoDatos.Formatos.Comesnapi;
using Marina.Siesmar.Entidades.Formatos.Comesnapi;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comesnapi
{
    public class ServicioSastreriaComesnapi
    {
        ServicioSastreriaComesnapiDAO servicioSastreriaComesnapiDAO = new();

        public List<ServicioSastreriaComesnapiDTO> ObtenerLista(int? CargaId = null)
        {
            return servicioSastreriaComesnapiDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ServicioSastreriaComesnapiDTO servicioSastreriaComesnapiDTO)
        {
            return servicioSastreriaComesnapiDAO.AgregarRegistro(servicioSastreriaComesnapiDTO);
        }

        public ServicioSastreriaComesnapiDTO BuscarFormato(int Codigo)
        {
            return servicioSastreriaComesnapiDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioSastreriaComesnapiDTO servicioSastreriaComesnapiDTO)
        {
            return servicioSastreriaComesnapiDAO.ActualizaFormato(servicioSastreriaComesnapiDTO);
        }

        public bool EliminarFormato(ServicioSastreriaComesnapiDTO servicioSastreriaComesnapiDTO)
        {
            return servicioSastreriaComesnapiDAO.EliminarFormato(servicioSastreriaComesnapiDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return servicioSastreriaComesnapiDAO.InsertarDatos(datos);
        }

    }
}
