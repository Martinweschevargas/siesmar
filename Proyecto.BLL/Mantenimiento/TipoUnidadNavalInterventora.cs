using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoUnidadNavalInterventora
    {
        readonly TipoUnidadNavalInterventoraDAO TipoUnidadNavalInterventoraDAO = new();

        public List<TipoUnidadNavalInterventoraDTO> ObtenerCapintanias()
        {
            return TipoUnidadNavalInterventoraDAO.ObtenerTipoUnidadNavalInterventoras();
        }

        public string AgregarTipoUnidadNavalInterventora(TipoUnidadNavalInterventoraDTO tipoUnidadNavalInterventoraDto)
        {
            return TipoUnidadNavalInterventoraDAO.AgregarTipoUnidadNavalInterventora(tipoUnidadNavalInterventoraDto);
        }

        public TipoUnidadNavalInterventoraDTO BuscarTipoUnidadNavalInterventoraID(int Codigo)
        {
            return TipoUnidadNavalInterventoraDAO.BuscarTipoUnidadNavalInterventoraID(Codigo);
        }

        public string ActualizarTipoUnidadNavalInterventora(TipoUnidadNavalInterventoraDTO tipoUnidadNavalInterventoraDto)
        {
            return TipoUnidadNavalInterventoraDAO.ActualizarTipoUnidadNavalInterventora(tipoUnidadNavalInterventoraDto);
        }

        public string EliminarTipoUnidadNavalInterventora(TipoUnidadNavalInterventoraDTO tipoUnidadNavalInterventoraDto)
        {
            return TipoUnidadNavalInterventoraDAO.EliminarTipoUnidadNavalInterventora(tipoUnidadNavalInterventoraDto);
        }

    }
}
