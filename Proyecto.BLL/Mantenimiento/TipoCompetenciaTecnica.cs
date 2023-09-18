using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoCompetenciaTecnica
    {
        readonly TipoCompetenciaTecnicaDAO tipoCompetenciaTecnicaDAO = new();

        public List<TipoCompetenciaTecnicaDTO> ObtenerTipoCompetenciaTecnicas()
        {
            return tipoCompetenciaTecnicaDAO.ObtenerTipoCompetenciaTecnicas();
        }

        public string AgregarTipoCompetenciaTecnica(TipoCompetenciaTecnicaDTO tipoCompetenciaTecnicaDto)
        {
            return tipoCompetenciaTecnicaDAO.AgregarTipoCompetenciaTecnica(tipoCompetenciaTecnicaDto);
        }

        public TipoCompetenciaTecnicaDTO BuscarTipoCompetenciaTecnicaID(int Codigo)
        {
            return tipoCompetenciaTecnicaDAO.BuscarTipoCompetenciaTecnicaID(Codigo);
        }

        public string ActualizarTipoCompetenciaTecnica(TipoCompetenciaTecnicaDTO tipoCompetenciaTecnicaDto)
        {
            return tipoCompetenciaTecnicaDAO.ActualizarTipoCompetenciaTecnica(tipoCompetenciaTecnicaDto);
        }

        public string EliminarTipoCompetenciaTecnica(TipoCompetenciaTecnicaDTO tipoCompetenciaTecnicaDto)
        {
            return tipoCompetenciaTecnicaDAO.EliminarTipoCompetenciaTecnica(tipoCompetenciaTecnicaDto);
        }

    }
}
