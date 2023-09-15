using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoComputadora
    {
        readonly TipoComputadoraDAO tipoComputadoraDAO = new();

        public List<TipoComputadoraDTO> ObtenerTipoComputadoras()
        {
            return tipoComputadoraDAO.ObtenerTipoComputadoras();
        }

        public string AgregarTipoComputadora(TipoComputadoraDTO tipoComputadoraDto)
        {
            return tipoComputadoraDAO.AgregarTipoComputadora(tipoComputadoraDto);
        }

        public TipoComputadoraDTO BuscarTipoComputadoraID(int Codigo)
        {
            return tipoComputadoraDAO.BuscarTipoComputadoraID(Codigo);
        }

        public string ActualizarTipoComputadora(TipoComputadoraDTO tipoComputadoraDTO)
        {
            return tipoComputadoraDAO.ActualizarTipoComputadora(tipoComputadoraDTO);
        }

        public string EliminarTipoComputadora(TipoComputadoraDTO tipoComputadoraDTO)
        {
            return tipoComputadoraDAO.EliminarTipoComputadora(tipoComputadoraDTO);
        }

    }
}
