using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dintemar
{
    public class DocumentoIntelFrenteInterno
    {
        DocumentoIntelFrenteInternoDAO documentoIntelFrenteInternoDAO = new();

        public List<DocumentoIntelFrenteInternoDTO> ObtenerLista(int? CargaId = null)
        {
            return documentoIntelFrenteInternoDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(DocumentoIntelFrenteInternoDTO documentoIntelFrenteInternoDTO)
        {
            return documentoIntelFrenteInternoDAO.AgregarRegistro(documentoIntelFrenteInternoDTO);
        }

        public DocumentoIntelFrenteInternoDTO EditarFormato(int Codigo)
        {
            return documentoIntelFrenteInternoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(DocumentoIntelFrenteInternoDTO documentoIntelFrenteInternoDTO)
        {
            return documentoIntelFrenteInternoDAO.ActualizaFormato(documentoIntelFrenteInternoDTO);
        }

        public bool EliminarFormato(DocumentoIntelFrenteInternoDTO documentoIntelFrenteInternoDTO)
        {
            return documentoIntelFrenteInternoDAO.EliminarFormato(documentoIntelFrenteInternoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return documentoIntelFrenteInternoDAO.InsertarDatos(datos);
        }

    }
}
