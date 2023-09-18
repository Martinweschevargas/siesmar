using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoDocumento
    {
        readonly TipoDocumentoDAO tipoDocumentoDAO = new();

        public List<TipoDocumentoDTO> ObtenerTipoDocumentos()
        {
            return tipoDocumentoDAO.ObtenerTipoDocumentos();
        }

        public string AgregarTipoDocumento(TipoDocumentoDTO tipoDocumentoDto)
        {
            return tipoDocumentoDAO.AgregarTipoDocumento(tipoDocumentoDto);
        }

        public TipoDocumentoDTO BuscarTipoDocumentoID(int Codigo)
        {
            return tipoDocumentoDAO.BuscarTipoDocumentoID(Codigo);
        }

        public string ActualizarTipoDocumento(TipoDocumentoDTO tipoDocumentoDto)
        {
            return tipoDocumentoDAO.ActualizarTipoDocumento(tipoDocumentoDto);
        }

        public string EliminarTipoDocumento(TipoDocumentoDTO tipoDocumentoDto)
        {
            return tipoDocumentoDAO.EliminarTipoDocumento(tipoDocumentoDto);
        }

    }
}
