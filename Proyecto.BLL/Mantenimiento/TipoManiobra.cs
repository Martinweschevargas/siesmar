using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoManiobra
    {
        readonly TipoManiobraDAO tipoManiobraDAO = new();

        public List<TipoManiobraDTO> ObtenerTipoManiobras()
        {
            return tipoManiobraDAO.ObtenerTipoManiobras();
        }

        public string AgregarTipoManiobra(TipoManiobraDTO tipoManiobraDto)
        {
            return tipoManiobraDAO.AgregarTipoManiobra(tipoManiobraDto);
        }

        public TipoManiobraDTO BuscarTipoManiobraID(int Codigo)
        {
            return tipoManiobraDAO.BuscarTipoManiobraID(Codigo);
        }

        public string ActualizarTipoManiobra(TipoManiobraDTO tipoManiobraDto)
        {
            return tipoManiobraDAO.ActualizarTipoManiobra(tipoManiobraDto);
        }

        public string EliminarTipoManiobra(TipoManiobraDTO tipoManiobraDto)
        {
            return tipoManiobraDAO.EliminarTipoManiobra(tipoManiobraDto);
        }

    }
}
