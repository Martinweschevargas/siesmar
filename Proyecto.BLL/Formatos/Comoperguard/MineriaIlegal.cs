using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class MineriaIlegal
    {
        MineriaIlegalDAO mineriaIlegalDAO = new();

        public List<MineriaIlegalDTO> ObtenerLista()
        {
            return mineriaIlegalDAO.ObtenerLista();
        }

        public string AgregarRegistro(MineriaIlegalDTO mineriaIlegalDTO)
        {
            return mineriaIlegalDAO.AgregarRegistro(mineriaIlegalDTO);
        }

        public MineriaIlegalDTO BuscarFormato(int Codigo)
        {
            return mineriaIlegalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(MineriaIlegalDTO mineriaIlegalDTO)
        {
            return mineriaIlegalDAO.ActualizaFormato(mineriaIlegalDTO);
        }

        public bool EliminarFormato(MineriaIlegalDTO mineriaIlegalDTO)
        {
            return mineriaIlegalDAO.EliminarFormato(mineriaIlegalDTO);
        }

        public bool InsercionMasiva(IEnumerable<MineriaIlegalDTO> mineriaIlegalDTO)
        {
            return mineriaIlegalDAO.InsercionMasiva(mineriaIlegalDTO);
        }

    }
}
