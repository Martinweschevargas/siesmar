using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoArmamento
    {
        readonly TipoArmamentoDAO tipoArmamentoDAO = new();

        public List<TipoArmamentoDTO> ObtenerTipoArmamentos()
        {
            return tipoArmamentoDAO.ObtenerTipoArmamentos();
        }

        public string AgregarTipoArmamento(TipoArmamentoDTO tipoArmamentoDto)
        {
            return tipoArmamentoDAO.AgregarTipoArmamento(tipoArmamentoDto);
        }

        public TipoArmamentoDTO BuscarTipoArmamentoID(int Codigo)
        {
            return tipoArmamentoDAO.BuscarTipoArmamentoID(Codigo);
        }

        public string ActualizarTipoArmamento(TipoArmamentoDTO tipoArmamentoDTO)
        {
            return tipoArmamentoDAO.ActualizarTipoArmamento(tipoArmamentoDTO);
        }

        public bool EliminarTipoArmamento(TipoArmamentoDTO tipoArmamentoDTO)
        {
            return tipoArmamentoDAO.EliminarTipoArmamento(tipoArmamentoDTO);
        }

    }
}
