using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoMaterialBienHistorico
    {
        readonly TipoMaterialBienHistoricoDAO tipoMaterialBienHistoricoDAO = new();

        public List<TipoMaterialBienHistoricoDTO> ObtenerTipoMaterialBienHistoricos()
        {
            return tipoMaterialBienHistoricoDAO.ObtenerTipoMaterialBienHistoricos();
        }

        public string AgregarTipoMaterialBienHistorico(TipoMaterialBienHistoricoDTO tipoMaterialBienHistoricoDto)
        {
            return tipoMaterialBienHistoricoDAO.AgregarTipoMaterialBienHistorico(tipoMaterialBienHistoricoDto);
        }

        public TipoMaterialBienHistoricoDTO BuscarTipoMaterialBienHistoricoID(int Codigo)
        {
            return tipoMaterialBienHistoricoDAO.BuscarTipoMaterialBienHistoricoID(Codigo);
        }

        public string ActualizarTipoMaterialBienHistorico(TipoMaterialBienHistoricoDTO tipoMaterialBienHistoricoDTO)
        {
            return tipoMaterialBienHistoricoDAO.ActualizarTipoMaterialBienHistorico(tipoMaterialBienHistoricoDTO);
        }

        public bool EliminarTipoMaterialBienHistorico(TipoMaterialBienHistoricoDTO tipoMaterialBienHistoricoDTO)
        {
            return tipoMaterialBienHistoricoDAO.EliminarTipoMaterialBienHistorico(tipoMaterialBienHistoricoDTO);
        }

    }
}