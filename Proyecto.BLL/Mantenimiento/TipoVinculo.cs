using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoVinculo
    {
        readonly TipoVinculoDAO tipoVinculoDAO = new();

        public List<TipoVinculoDTO> ObtenerTipoVinculos()
        {
            return tipoVinculoDAO.ObtenerTipoVinculos();
        }

        public string AgregarTipoVinculo(TipoVinculoDTO tipoVinculoDto)
        {
            return tipoVinculoDAO.AgregarTipoVinculo(tipoVinculoDto);
        }

        public TipoVinculoDTO BuscarTipoVinculoID(int Codigo)
        {
            return tipoVinculoDAO.BuscarTipoVinculoID(Codigo);
        }

        public string ActualizarTipoVinculo(TipoVinculoDTO tipoVinculoDTO)
        {
            return tipoVinculoDAO.ActualizarTipoVinculo(tipoVinculoDTO);
        }

        public string EliminarTipoVinculo(TipoVinculoDTO tipoVinculoDTO)
        {
            return tipoVinculoDAO.EliminarTipoVinculo(tipoVinculoDTO);
        }

    }
}
