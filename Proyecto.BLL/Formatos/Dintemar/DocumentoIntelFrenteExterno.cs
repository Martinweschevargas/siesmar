using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dintemar
{
    public class DocumentoIntelFrenteExterno
    {
        DocumentoIntelFrenteExternoDAO documentoIntelFrenteExternoDAO = new();

        public List<DocumentoIntelFrenteExternoDTO> ObtenerLista(int? CargaId = null)
        {
            return documentoIntelFrenteExternoDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(DocumentoIntelFrenteExternoDTO documentoIntelFrenteExternoDTO)
        {
            return documentoIntelFrenteExternoDAO.AgregarRegistro(documentoIntelFrenteExternoDTO);
        }

        public DocumentoIntelFrenteExternoDTO EditarFormato(int Codigo)
        {
            return documentoIntelFrenteExternoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(DocumentoIntelFrenteExternoDTO documentoIntelFrenteExternoDTO)
        {
            return documentoIntelFrenteExternoDAO.ActualizaFormato(documentoIntelFrenteExternoDTO);
        }

        public bool EliminarFormato(DocumentoIntelFrenteExternoDTO documentoIntelFrenteExternoDTO)
        {
            return documentoIntelFrenteExternoDAO.EliminarFormato(documentoIntelFrenteExternoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return documentoIntelFrenteExternoDAO.InsertarDatos(datos);
        }

    }
}
