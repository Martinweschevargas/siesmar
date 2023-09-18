using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoNovedad
    {
        readonly TipoNovedadDAO tipoNovedadDAO = new();

        public List<TipoNovedadDTO> ObtenerTipoNovedads()
        {
            return tipoNovedadDAO.ObtenerTipoNovedads();
        }

        public string AgregarTipoNovedad(TipoNovedadDTO tipoNovedadDto)
        {
            return tipoNovedadDAO.AgregarTipoNovedad(tipoNovedadDto);
        }

        public TipoNovedadDTO BuscarTipoNovedadID(int Codigo)
        {
            return tipoNovedadDAO.BuscarTipoNovedadID(Codigo);
        }

        public string ActualizarTipoNovedad(TipoNovedadDTO tipoNovedadDTO)
        {
            return tipoNovedadDAO.ActualizarTipoNovedad(tipoNovedadDTO);
        }

        public string EliminarTipoNovedad(TipoNovedadDTO tipoNovedadDTO)
        {
            return tipoNovedadDAO.EliminarTipoNovedad(tipoNovedadDTO);
        }

    }
}
