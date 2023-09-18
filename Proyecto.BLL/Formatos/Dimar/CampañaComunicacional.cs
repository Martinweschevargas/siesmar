using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class CampañaComunicacional
    {
        CampañaComunicacionalDAO campañaComunicacionalDAO = new();

        public List<CampañaComunicacionalDTO> ObtenerLista(int? CargaId = null)
        {
            return campañaComunicacionalDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(CampañaComunicacionalDTO campañaComunicacionalDTO)
        {
            return campañaComunicacionalDAO.AgregarRegistro(campañaComunicacionalDTO);
        }

        public CampañaComunicacionalDTO BuscarFormato(int Codigo)
        {
            return campañaComunicacionalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CampañaComunicacionalDTO campañaComunicacionalDTO)
        {
            return campañaComunicacionalDAO.ActualizaFormato(campañaComunicacionalDTO);
        }

        public bool EliminarFormato(CampañaComunicacionalDTO campañaComunicacionalDTO)
        {
            return campañaComunicacionalDAO.EliminarFormato(campañaComunicacionalDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return campañaComunicacionalDAO.InsertarDatos(datos);
        }

    }
}
