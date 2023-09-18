using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirintemar
{
    public class PublicacionInteresInstitucional
    {
        PublicacionInteresInstitucionalDAO publicacionInteresInstitucionalDAO = new();

        public List<PublicacionInteresInstitucionalDTO> ObtenerLista()
        {
            return publicacionInteresInstitucionalDAO.ObtenerLista();
        }

        public string AgregarRegistro(PublicacionInteresInstitucionalDTO publicacionInteresInstitucional)
        {
            return publicacionInteresInstitucionalDAO.AgregarRegistro(publicacionInteresInstitucional);
        }

        public PublicacionInteresInstitucionalDTO EditarFormato(int Codigo)
        {
            return publicacionInteresInstitucionalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PublicacionInteresInstitucionalDTO publicacionInteresInstitucionalDTO)
        {
            return publicacionInteresInstitucionalDAO.ActualizaFormato(publicacionInteresInstitucionalDTO);
        }

        public bool EliminarFormato(PublicacionInteresInstitucionalDTO publicacionInteresInstitucionalDTO)
        {
            return publicacionInteresInstitucionalDAO.EliminarFormato(publicacionInteresInstitucionalDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return publicacionInteresInstitucionalDAO.InsertarDatos(datos);
        }

    }
}
