using Marina.Siesmar.AccesoDatos.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav
{
    public class ActividadDepartamentoHidrografia
    {
        ActividadDepartamentoHidrografiaDAO actividadDepartamentoHidrografiaDAO = new();

        public List<ActividadDepartamentoHidrografiaDTO> ObtenerLista(int? CargaId = null)
        {
            return actividadDepartamentoHidrografiaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ActividadDepartamentoHidrografiaDTO actividadDepartamentoHidrografia)
        {
            return actividadDepartamentoHidrografiaDAO.AgregarRegistro(actividadDepartamentoHidrografia);
        }

        public ActividadDepartamentoHidrografiaDTO BuscarFormato(int Codigo)
        {
            return actividadDepartamentoHidrografiaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ActividadDepartamentoHidrografiaDTO actividadDepartamentoHidrografiaDTO)
        {
            return actividadDepartamentoHidrografiaDAO.ActualizaFormato(actividadDepartamentoHidrografiaDTO);
        }

        public bool EliminarFormato(ActividadDepartamentoHidrografiaDTO actividadDepartamentoHidrografiaDTO)
        {
            return actividadDepartamentoHidrografiaDAO.EliminarFormato( actividadDepartamentoHidrografiaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return actividadDepartamentoHidrografiaDAO.InsertarDatos(datos);
        }

    }
}
