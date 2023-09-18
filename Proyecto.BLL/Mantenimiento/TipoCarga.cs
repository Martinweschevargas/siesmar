using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoCarga
    {
        readonly TipoCargaDAO TipoCargaDAO = new();

        public List<TipoCargaDTO> ObtenerCapintanias()
        {
            return TipoCargaDAO.ObtenerTipoCargas();
        }

        public string AgregarTipoCarga(TipoCargaDTO tipoCargaDto)
        {
            return TipoCargaDAO.AgregarTipoCarga(tipoCargaDto);
        }

        public TipoCargaDTO BuscarTipoCargaID(int Codigo)
        {
            return TipoCargaDAO.BuscarTipoCargaID(Codigo);
        }

        public string ActualizarTipoCarga(TipoCargaDTO tipoCargaDto)
        {
            return TipoCargaDAO.ActualizarTipoCarga(tipoCargaDto);
        }

        public string EliminarTipoCarga(TipoCargaDTO tipoCargaDto)
        {
            return TipoCargaDAO.EliminarTipoCarga(tipoCargaDto);
        }

    }
}
