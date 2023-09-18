using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Documento
    {
        readonly DocumentoDAO documentoDAO = new();

        public List<DocumentoDTO> ObtenerDocumentos()
        {
            return documentoDAO.ObtenerDocumentos();
        }

        public string AgregarDocumento(DocumentoDTO documentoDto)
        {
            return documentoDAO.AgregarDocumento(documentoDto);
        }

        public DocumentoDTO BuscarDocumentoID(int Codigo)
        {
            return documentoDAO.BuscarDocumentoID(Codigo);
        }

        public string ActualizarDocumento(DocumentoDTO documentoDto)
        {
            return documentoDAO.ActualizarDocumento(documentoDto);
        }

        public string EliminarDocumento(DocumentoDTO documentoDto)
        {
            return documentoDAO.EliminarDocumento(documentoDto);
        }

    }
}
