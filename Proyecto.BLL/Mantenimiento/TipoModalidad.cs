using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoModalidad
    {
        readonly TipoModalidadDAO tipoModalidadDAO = new();

        public List<TipoModalidadDTO> ObtenerTipoModalidads()
        {
            return tipoModalidadDAO.ObtenerTipoModalidads();
        }

        public string AgregarTipoModalidad(TipoModalidadDTO tipoModalidadDto)
        {
            return tipoModalidadDAO.AgregarTipoModalidad(tipoModalidadDto);
        }

        public TipoModalidadDTO BuscarTipoModalidadID(int Codigo)
        {
            return tipoModalidadDAO.BuscarTipoModalidadID(Codigo);
        }

        public string ActualizarTipoModalidad(TipoModalidadDTO tipoModalidadDTO)
        {
            return tipoModalidadDAO.ActualizarTipoModalidad(tipoModalidadDTO);
        }

        public bool EliminarTipoModalidad(TipoModalidadDTO tipoModalidadDTO)
        {
            return tipoModalidadDAO.EliminarTipoModalidad(tipoModalidadDTO);
        }

    }
}
