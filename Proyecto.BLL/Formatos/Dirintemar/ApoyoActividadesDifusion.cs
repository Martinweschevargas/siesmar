using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirintemar
{
    public class ApoyoActividadesDifusion
    {
        ApoyoActividadesDifusionDAO apoyoActividadesDifusionDAO = new();

        public List<ApoyoActividadesDifusionDTO> ObtenerLista()
        {
            return apoyoActividadesDifusionDAO.ObtenerLista();
        }

        public string AgregarRegistro(ApoyoActividadesDifusionDTO apoyoActividadesDifusion)
        {
            return apoyoActividadesDifusionDAO.AgregarRegistro(apoyoActividadesDifusion);
        }

        public ApoyoActividadesDifusionDTO EditarFormato(int Codigo)
        {
            return apoyoActividadesDifusionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ApoyoActividadesDifusionDTO apoyoActividadesDifusionDTO)
        {
            return apoyoActividadesDifusionDAO.ActualizaFormato(apoyoActividadesDifusionDTO);
        }

        public bool EliminarFormato(ApoyoActividadesDifusionDTO apoyoActividadesDifusionDTO)
        {
            return apoyoActividadesDifusionDAO.EliminarFormato(apoyoActividadesDifusionDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return apoyoActividadesDifusionDAO.InsertarDatos(datos);
        }

    }
}
