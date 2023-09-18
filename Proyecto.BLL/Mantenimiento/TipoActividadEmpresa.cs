using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoActividadEmpresa
    {
        readonly TipoActividadEmpresaDAO tipoActividadEmpresaDAO = new();

        public List<TipoActividadEmpresaDTO> ObtenerTipoActividadEmpresas()
        {
            return tipoActividadEmpresaDAO.ObtenerTipoActividadEmpresas();
        }

        public string AgregarTipoActividadEmpresa(TipoActividadEmpresaDTO tipoActividadEmpresaDto)
        {
            return tipoActividadEmpresaDAO.AgregarTipoActividadEmpresa(tipoActividadEmpresaDto);
        }

        public TipoActividadEmpresaDTO BuscarTipoActividadEmpresaID(int Codigo)
        {
            return tipoActividadEmpresaDAO.BuscarTipoActividadEmpresaID(Codigo);
        }

        public string ActualizarTipoActividadEmpresa(TipoActividadEmpresaDTO tipoActividadEmpresaDto)
        {
            return tipoActividadEmpresaDAO.ActualizarTipoActividadEmpresa(tipoActividadEmpresaDto);
        }

        public string EliminarTipoActividadEmpresa(TipoActividadEmpresaDTO tipoActividadEmpresaDto)
        {
            return tipoActividadEmpresaDAO.EliminarTipoActividadEmpresa(tipoActividadEmpresaDto);
        }

    }
}
