using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class ActividadIlicitaComoperguard
    {
        ActividadIlicitaDAO actividadIlicitaDAO = new();

        public List<ActividadIlicitaComoperguardDTO> ObtenerLista()
        {
            return actividadIlicitaDAO.ObtenerLista();
        }

        public string AgregarRegistro(ActividadIlicitaComoperguardDTO actividadIlicitaDTO)
        {
            return actividadIlicitaDAO.AgregarRegistro(actividadIlicitaDTO);
        }

        public ActividadIlicitaComoperguardDTO BuscarFormato(int Codigo)
        {
            return actividadIlicitaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ActividadIlicitaComoperguardDTO actividadIlicitaDTO)
        {
            return actividadIlicitaDAO.ActualizaFormato(actividadIlicitaDTO);
        }

        public bool EliminarFormato(ActividadIlicitaComoperguardDTO actividadIlicitaDTO)
        {
            return actividadIlicitaDAO.EliminarFormato(actividadIlicitaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return actividadIlicitaDAO.InsertarDatos(datos);
        }

    }
}
