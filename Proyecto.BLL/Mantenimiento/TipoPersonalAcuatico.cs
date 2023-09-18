using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoPersonalAcuatico
    {
        readonly TipoPersonalAcuaticoDAO tipoPersonalAcuaticoDAO = new();

        public List<TipoPersonalAcuaticoDTO> ObtenerTipoPersonalAcuaticos()
        {
            return tipoPersonalAcuaticoDAO.ObtenerTipoPersonalAcuaticos();
        }

        public string AgregarTipoPersonalAcuatico(TipoPersonalAcuaticoDTO tipoPersonalAcuaticoDto)
        {
            return tipoPersonalAcuaticoDAO.AgregarTipoPersonalAcuatico(tipoPersonalAcuaticoDto);
        }

        public TipoPersonalAcuaticoDTO BuscarTipoPersonalAcuaticoID(int Codigo)
        {
            return tipoPersonalAcuaticoDAO.BuscarTipoPersonalAcuaticoID(Codigo);
        }

        public string ActualizarTipoPersonalAcuatico(TipoPersonalAcuaticoDTO tipoPersonalAcuaticoDto)
        {
            return tipoPersonalAcuaticoDAO.ActualizarTipoPersonalAcuatico(tipoPersonalAcuaticoDto);
        }

        public string EliminarTipoPersonalAcuatico(TipoPersonalAcuaticoDTO tipoPersonalAcuaticoDto)
        {
            return tipoPersonalAcuaticoDAO.EliminarTipoPersonalAcuatico(tipoPersonalAcuaticoDto);
        }

    }
}
