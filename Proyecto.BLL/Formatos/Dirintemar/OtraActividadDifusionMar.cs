using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirintemar
{
    public class OtraActividadDifusionMar
    {
        OtraActividadDifusionMarDAO otraActividadDifusionMarDAO = new();

        public List<OtraActividadDifusionMarDTO> ObtenerLista()
        {
            return otraActividadDifusionMarDAO.ObtenerLista();
        }

        public string AgregarRegistro(OtraActividadDifusionMarDTO otraActividadDifusionMar)
        {
            return otraActividadDifusionMarDAO.AgregarRegistro(otraActividadDifusionMar);
        }

        public OtraActividadDifusionMarDTO EditarFormato(int Codigo)
        {
            return otraActividadDifusionMarDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(OtraActividadDifusionMarDTO otraActividadDifusionMarDTO)
        {
            return otraActividadDifusionMarDAO.ActualizaFormato(otraActividadDifusionMarDTO);
        }

        public bool EliminarFormato(OtraActividadDifusionMarDTO otraActividadDifusionMarDTO)
        {
            return otraActividadDifusionMarDAO.EliminarFormato(otraActividadDifusionMarDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return otraActividadDifusionMarDAO.InsertarDatos(datos);
        }

    }
}
