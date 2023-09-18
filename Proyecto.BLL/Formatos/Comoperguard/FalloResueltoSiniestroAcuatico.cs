using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class FalloResueltoSiniestroAcuatico
    {
        FalloResueltoSiniestroAcuaticoDAO falloResueltoSiniestroAcuaticoDAO = new();

        public List<FalloResueltoSiniestroAcuaticoDTO> ObtenerLista()
        {
            return falloResueltoSiniestroAcuaticoDAO.ObtenerLista();
        }

        public string AgregarRegistro(FalloResueltoSiniestroAcuaticoDTO falloResueltoSiniestroAcuaticoDTO)
        {
            return falloResueltoSiniestroAcuaticoDAO.AgregarRegistro(falloResueltoSiniestroAcuaticoDTO);
        }

        public FalloResueltoSiniestroAcuaticoDTO BuscarFormato(int Codigo)
        {
            return falloResueltoSiniestroAcuaticoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(FalloResueltoSiniestroAcuaticoDTO falloResueltoSiniestroAcuaticoDTO)
        {
            return falloResueltoSiniestroAcuaticoDAO.ActualizaFormato(falloResueltoSiniestroAcuaticoDTO);
        }

        public bool EliminarFormato(FalloResueltoSiniestroAcuaticoDTO falloResueltoSiniestroAcuaticoDTO)
        {
            return falloResueltoSiniestroAcuaticoDAO.EliminarFormato(falloResueltoSiniestroAcuaticoDTO);
        }

        public bool InsercionMasiva(IEnumerable<FalloResueltoSiniestroAcuaticoDTO> falloResueltoSiniestroAcuaticoDTO)
        {
            return falloResueltoSiniestroAcuaticoDAO.InsercionMasiva(falloResueltoSiniestroAcuaticoDTO);
        }

    }
}
