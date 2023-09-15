using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoPuertoPeru
    {
        readonly TipoPuertoPeruDAO tipoPuertoPeruDAO = new();

        public List<TipoPuertoPeruDTO> ObtenerCapintanias()
        {
            return tipoPuertoPeruDAO.ObtenerTipoPuertoPerus();
        }

        public string AgregarTipoPuertoPeru(TipoPuertoPeruDTO tipoPuertoPeruDto)
        {
            return tipoPuertoPeruDAO.AgregarTipoPuertoPeru(tipoPuertoPeruDto);
        }

        public TipoPuertoPeruDTO BuscarTipoPuertoPeruID(int Codigo)
        {
            return tipoPuertoPeruDAO.BuscarTipoPuertoPeruID(Codigo);
        }

        public string ActualizarTipoPuertoPeru(TipoPuertoPeruDTO tipoPuertoPeruDto)
        {
            return tipoPuertoPeruDAO.ActualizarTipoPuertoPeru(tipoPuertoPeruDto);
        }

        public string EliminarTipoPuertoPeru(TipoPuertoPeruDTO tipoPuertoPeruDto)
        {
            return tipoPuertoPeruDAO.EliminarTipoPuertoPeru(tipoPuertoPeruDto);
        }

    }
}
