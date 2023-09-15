using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class ArriboNave
    {
        ArriboNaveDAO arriboNaveDAO = new();

        public List<ArriboNaveDTO> ObtenerLista()
        {
            return arriboNaveDAO.ObtenerLista();
        }

        public string AgregarRegistro(ArriboNaveDTO arriboNaveDTO)
        {
            return arriboNaveDAO.AgregarRegistro(arriboNaveDTO);
        }

        public ArriboNaveDTO BuscarFormato(int Codigo)
        {
            return arriboNaveDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ArriboNaveDTO arriboNaveDTO)
        {
            return arriboNaveDAO.ActualizaFormato(arriboNaveDTO);
        }

        public bool EliminarFormato(ArriboNaveDTO arriboNaveDTO)
        {
            return arriboNaveDAO.EliminarFormato(arriboNaveDTO);
        }

        public bool InsercionMasiva(IEnumerable<ArriboNaveDTO> arriboNaveDTO)
        {
            return arriboNaveDAO.InsercionMasiva(arriboNaveDTO);
        }

    }
}
