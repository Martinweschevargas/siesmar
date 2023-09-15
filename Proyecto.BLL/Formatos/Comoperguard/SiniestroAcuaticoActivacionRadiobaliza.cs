using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class SiniestroAcuaticoActivacionRadiobaliza
    {
        SiniestroAcuaticoActivacionRadiobalizaDAO siniestroAcuaticoActivRadiobalizaDAO = new();

        public List<SiniestroAcuaticoActivacionRadiobalizaDTO> ObtenerLista()
        {
            return siniestroAcuaticoActivRadiobalizaDAO.ObtenerLista();
        }

        public string AgregarRegistro(SiniestroAcuaticoActivacionRadiobalizaDTO siniestroAcuaticoActivRadiobalizaDTO)
        {
            return siniestroAcuaticoActivRadiobalizaDAO.AgregarRegistro(siniestroAcuaticoActivRadiobalizaDTO);
        }

        public SiniestroAcuaticoActivacionRadiobalizaDTO BuscarFormato(int Codigo)
        {
            return siniestroAcuaticoActivRadiobalizaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SiniestroAcuaticoActivacionRadiobalizaDTO siniestroAcuaticoActivRadiobalizaDTO)
        {
            return siniestroAcuaticoActivRadiobalizaDAO.ActualizaFormato(siniestroAcuaticoActivRadiobalizaDTO);
        }

        public bool EliminarFormato(SiniestroAcuaticoActivacionRadiobalizaDTO siniestroAcuaticoActivRadiobalizaDTO)
        {
            return siniestroAcuaticoActivRadiobalizaDAO.EliminarFormato(siniestroAcuaticoActivRadiobalizaDTO);
        }

        public bool InsercionMasiva(IEnumerable<SiniestroAcuaticoActivacionRadiobalizaDTO> siniestroAcuaticoActivRadiobalizaDTO)
        {
            return siniestroAcuaticoActivRadiobalizaDAO.InsercionMasiva(siniestroAcuaticoActivRadiobalizaDTO);
        }

    }
}
