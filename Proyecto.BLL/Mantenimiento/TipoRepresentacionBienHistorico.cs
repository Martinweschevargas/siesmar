using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoRepresentacionBienHistorico
    {
        readonly TipoRepresentacionBienHistoricoDAO tipoRepresentacionBienHistoricoDAO = new();

        public List<TipoRepresentacionBienHistoricoDTO> ObtenerTipoRepresentacionBienHistoricos()
        {
            return tipoRepresentacionBienHistoricoDAO.ObtenerTipoRepresentacionBienHistoricos();
        }

        public string AgregarTipoRepresentacionBienHistorico(TipoRepresentacionBienHistoricoDTO tipoRepresentacionBienHistoricoDto)
        {
            return tipoRepresentacionBienHistoricoDAO.AgregarTipoRepresentacionBienHistorico(tipoRepresentacionBienHistoricoDto);
        }

        public TipoRepresentacionBienHistoricoDTO BuscarTipoRepresentacionBienHistoricoID(int Codigo)
        {
            return tipoRepresentacionBienHistoricoDAO.BuscarTipoRepresentacionBienHistoricoID(Codigo);
        }

        public string ActualizarTipoRepresentacionBienHistorico(TipoRepresentacionBienHistoricoDTO tipoRepresentacionBienHistoricoDTO)
        {
            return tipoRepresentacionBienHistoricoDAO.ActualizarTipoRepresentacionBienHistorico(tipoRepresentacionBienHistoricoDTO);
        }

        public bool EliminarTipoRepresentacionBienHistorico(TipoRepresentacionBienHistoricoDTO tipoRepresentacionBienHistoricoDTO)
        {
            return tipoRepresentacionBienHistoricoDAO.EliminarTipoRepresentacionBienHistorico(tipoRepresentacionBienHistoricoDTO);
        }

    }
}