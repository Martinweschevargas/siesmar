using Marina.Siesmar.AccesoDatos.Formatos.Comoperama;
using Marina.Siesmar.Entidades.Formatos.Comoperama;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperama
{
    public class ApoyoSocialIntitucionArmada
    {
        ApoyoSocialIntitucionArmadaDAO apoyoSocialIntitucionArmadaDAO = new();

        public List<ApoyoSocialIntitucionArmadaDTO> ObtenerLista(int? CargaId = null)
        {
            return apoyoSocialIntitucionArmadaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ApoyoSocialIntitucionArmadaDTO apoyoSocialIntitucionArmadaDTO)
        {
            return apoyoSocialIntitucionArmadaDAO.AgregarRegistro(apoyoSocialIntitucionArmadaDTO);
        }

        public ApoyoSocialIntitucionArmadaDTO BuscarFormato(int Codigo)
        {
            return apoyoSocialIntitucionArmadaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ApoyoSocialIntitucionArmadaDTO apoyoSocialIntitucionArmadaDTO)
        {
            return apoyoSocialIntitucionArmadaDAO.ActualizaFormato(apoyoSocialIntitucionArmadaDTO);
        }

        public bool EliminarFormato(ApoyoSocialIntitucionArmadaDTO apoyoSocialIntitucionArmadaDTO)
        {
            return apoyoSocialIntitucionArmadaDAO.EliminarFormato(apoyoSocialIntitucionArmadaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return apoyoSocialIntitucionArmadaDAO.InsertarDatos(datos);
        }

    }
}
