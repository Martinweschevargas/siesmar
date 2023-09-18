
using Marina.Siesmar.AccesoDatos.Formatos.Comesnapi;
using Marina.Siesmar.Entidades.Formatos.Comesnapi;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comesnapi
{
    public class ServicioPeluqueriaComesnapi
    {
        ServicioPeluqueriaComesnapiDAO servicioPeluqueriaComesnapiDAO = new();

        public List<ServicioPeluqueriaComesnapiDTO> ObtenerLista(int? CargaId = null)
        {
            return servicioPeluqueriaComesnapiDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ServicioPeluqueriaComesnapiDTO servicioPeluqueriaComesnapiDTO)
        {
            return servicioPeluqueriaComesnapiDAO.AgregarRegistro(servicioPeluqueriaComesnapiDTO);
        }

        public ServicioPeluqueriaComesnapiDTO BuscarFormato(int Codigo)
        {
            return servicioPeluqueriaComesnapiDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioPeluqueriaComesnapiDTO servicioPeluqueriaComesnapiDTO)
        {
            return servicioPeluqueriaComesnapiDAO.ActualizaFormato(servicioPeluqueriaComesnapiDTO);
        }

        public bool EliminarFormato(ServicioPeluqueriaComesnapiDTO servicioPeluqueriaComesnapiDTO)
        {
            return servicioPeluqueriaComesnapiDAO.EliminarFormato(servicioPeluqueriaComesnapiDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return servicioPeluqueriaComesnapiDAO.InsertarDatos(datos);
        }

    }
}
