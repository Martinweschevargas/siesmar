using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dintemar
{
    public class ProduccionDocumentosContraintel
    {
        ProduccionDocumentosContraintelDAO produccionDocumentosContraintelDAO = new();

        public List<ProduccionDocumentosContraintelDTO> ObtenerLista(int? CargaId = null)
        {
            return produccionDocumentosContraintelDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ProduccionDocumentosContraintelDTO produccionDocumentosContraintelDTO)
        {
            return produccionDocumentosContraintelDAO.AgregarRegistro(produccionDocumentosContraintelDTO);
        }

        public ProduccionDocumentosContraintelDTO EditarFormato(int Codigo)
        {
            return produccionDocumentosContraintelDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ProduccionDocumentosContraintelDTO produccionDocumentosContraintelDTO)
        {
            return produccionDocumentosContraintelDAO.ActualizaFormato(produccionDocumentosContraintelDTO);
        }

        public bool EliminarFormato(ProduccionDocumentosContraintelDTO produccionDocumentosContraintelDTO)
        {
            return produccionDocumentosContraintelDAO.EliminarFormato(produccionDocumentosContraintelDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return produccionDocumentosContraintelDAO.InsertarDatos(datos);
        }

    }
}
