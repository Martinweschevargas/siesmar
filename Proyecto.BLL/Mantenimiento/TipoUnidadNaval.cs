using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoUnidadNaval
    {
        readonly TipoUnidadNavalDAO tipoUnidadNavalDAO = new();

        public List<TipoUnidadNavalDTO> ObtenerTipoUnidadNavals()
        {
            return tipoUnidadNavalDAO.ObtenerTipoUnidadNavals();
        }

        public string AgregarTipoUnidadNaval(TipoUnidadNavalDTO tipoUnidadNavalDto)
        {
            return tipoUnidadNavalDAO.AgregarTipoUnidadNaval(tipoUnidadNavalDto);
        }

        public TipoUnidadNavalDTO BuscarTipoUnidadNavalID(int Codigo)
        {
            return tipoUnidadNavalDAO.BuscarTipoUnidadNavalID(Codigo);
        }

        public string ActualizarTipoUnidadNaval(TipoUnidadNavalDTO tipoUnidadNavalDto)
        {
            return tipoUnidadNavalDAO.ActualizarTipoUnidadNaval(tipoUnidadNavalDto);
        }

        public string EliminarTipoUnidadNaval(TipoUnidadNavalDTO tipoUnidadNavalDto)
        {
            return tipoUnidadNavalDAO.EliminarTipoUnidadNaval(tipoUnidadNavalDto);
        }

    }
}
