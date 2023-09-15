using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class UsoRedSocialInstitucion
    {
        UsoRedSocialInstitucionDAO usoRedSocialInstitucionDAO = new();

        public List<UsoRedSocialInstitucionDTO> ObtenerLista(int? CargaId = null)
        {
            return usoRedSocialInstitucionDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(UsoRedSocialInstitucionDTO usoRedSocialInstitucionDTO)
        {
            return usoRedSocialInstitucionDAO.AgregarRegistro(usoRedSocialInstitucionDTO);
        }

        public UsoRedSocialInstitucionDTO BuscarFormato(int Codigo)
        {
            return usoRedSocialInstitucionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(UsoRedSocialInstitucionDTO usoRedSocialInstitucionDTO)
        {
            return usoRedSocialInstitucionDAO.ActualizaFormato(usoRedSocialInstitucionDTO);
        }

        public bool EliminarFormato(UsoRedSocialInstitucionDTO usoRedSocialInstitucionDTO)
        {
            return usoRedSocialInstitucionDAO.EliminarFormato(usoRedSocialInstitucionDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return usoRedSocialInstitucionDAO.InsertarDatos(datos);
        }

    }
}
