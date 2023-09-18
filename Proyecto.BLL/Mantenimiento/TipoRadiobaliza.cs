using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoRadiobaliza
    {
        readonly TipoRadiobalizaDAO TipoRadiobalizaDAO = new();

        public List<TipoRadiobalizaDTO> ObtenerTipoRadiobalizas()
        {
            return TipoRadiobalizaDAO.ObtenerTipoRadiobalizas();
        }

        public string AgregarTipoRadiobaliza(TipoRadiobalizaDTO tipoRadiobalizaDto)
        {
            return TipoRadiobalizaDAO.AgregarTipoRadiobaliza(tipoRadiobalizaDto);
        }

        public TipoRadiobalizaDTO BuscarTipoRadiobalizaID(int Codigo)
        {
            return TipoRadiobalizaDAO.BuscarTipoRadiobalizaID(Codigo);
        }

        public string ActualizarTipoRadiobaliza(TipoRadiobalizaDTO tipoRadiobalizaDto)
        {
            return TipoRadiobalizaDAO.ActualizarTipoRadiobaliza(tipoRadiobalizaDto);
        }

        public string EliminarTipoRadiobaliza(TipoRadiobalizaDTO tipoRadiobalizaDto)
        {
            return TipoRadiobalizaDAO.EliminarTipoRadiobaliza(tipoRadiobalizaDto);
        }

    }
}
