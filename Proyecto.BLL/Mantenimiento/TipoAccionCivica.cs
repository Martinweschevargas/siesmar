using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoAccionCivica
    {
        readonly TipoAccionCivicaDAO tipoAccionCivicaDAO = new();

        public List<TipoAccionCivicaDTO> ObtenerTipoAccionCivicas()
        {
            return tipoAccionCivicaDAO.ObtenerTipoAccionCivicas();
        }

        public string AgregarTipoAccionCivica(TipoAccionCivicaDTO tipoAccionCivicaDto)
        {
            return tipoAccionCivicaDAO.AgregarTipoAccionCivica(tipoAccionCivicaDto);
        }

        public TipoAccionCivicaDTO BuscarTipoAccionCivicaID(int Codigo)
        {
            return tipoAccionCivicaDAO.BuscarTipoAccionCivicaID(Codigo);
        }

        public string ActualizarTipoAccionCivica(TipoAccionCivicaDTO tipoAccionCivicaDto)
        {
            return tipoAccionCivicaDAO.ActualizarTipoAccionCivica(tipoAccionCivicaDto);
        }

        public string EliminarTipoAccionCivica(TipoAccionCivicaDTO tipoAccionCivicaDto)
        {
            return tipoAccionCivicaDAO.EliminarTipoAccionCivica(tipoAccionCivicaDto);
        }

    }
}
