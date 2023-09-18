using Marina.Siesmar.AccesoDatos.Formatos.Dicapi;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dicapi
{
    public class DireccionInspeccionAuditoriaSupervision
    {
        DireccionInspeccionAuditoriaSupervisionDAO direccionInspeccionAuditoriaSupervisionDAO = new();

        public List<DireccionInspeccionAuditoriaSupervisionDTO> ObtenerLista(int? CargaId = null)
        {
            return direccionInspeccionAuditoriaSupervisionDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(DireccionInspeccionAuditoriaSupervisionDTO direccionInspeccionAuditoriaSupervision)
        {
            return direccionInspeccionAuditoriaSupervisionDAO.AgregarRegistro(direccionInspeccionAuditoriaSupervision);
        }

        public DireccionInspeccionAuditoriaSupervisionDTO BuscarFormato(int Codigo)
        {
            return direccionInspeccionAuditoriaSupervisionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(DireccionInspeccionAuditoriaSupervisionDTO direccionInspeccionAuditoriaSupervisionDTO)
        {
            return direccionInspeccionAuditoriaSupervisionDAO.ActualizaFormato(direccionInspeccionAuditoriaSupervisionDTO);
        }

        public bool EliminarFormato(DireccionInspeccionAuditoriaSupervisionDTO direccionInspeccionAuditoriaSupervisionDTO)
        {
            return direccionInspeccionAuditoriaSupervisionDAO.EliminarFormato( direccionInspeccionAuditoriaSupervisionDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return direccionInspeccionAuditoriaSupervisionDAO.InsertarDatos(datos);
        }

        //public bool InsercionMasiva(IEnumerable<DireccionInspeccionAuditoriaSupervisionDTO> direccionInspeccionAuditoriaSupervisionDTO)
        //{
        //    return direccionInspeccionAuditoriaSupervisionDAO.InsercionMasiva(direccionInspeccionAuditoriaSupervisionDTO);
        //}

    }
}
