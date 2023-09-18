using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class EmisionFotografiaVideo
    {
        EmisionFotografiaVideoDAO emisionFotografiaVideoDAO = new();

        public List<EmisionFotografiaVideoDTO> ObtenerLista(int? CargaId = null)
        {
            return emisionFotografiaVideoDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(EmisionFotografiaVideoDTO emisionFotografiaVideoDTO)
        {
            return emisionFotografiaVideoDAO.AgregarRegistro(emisionFotografiaVideoDTO);
        }

        public EmisionFotografiaVideoDTO BuscarFormato(int Codigo)
        {
            return emisionFotografiaVideoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EmisionFotografiaVideoDTO emisionFotografiaVideoDTO)
        {
            return emisionFotografiaVideoDAO.ActualizaFormato(emisionFotografiaVideoDTO);
        }

        public bool EliminarFormato(EmisionFotografiaVideoDTO emisionFotografiaVideoDTO)
        {
            return emisionFotografiaVideoDAO.EliminarFormato(emisionFotografiaVideoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return emisionFotografiaVideoDAO.InsertarDatos(datos);
        }

    }
}
