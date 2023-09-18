using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class PresenteRecordatorioInstitucional
    {
        PresenteRecordatorioInstitucionalDAO presenteRecordatorioInstitucionalDAO = new();

        public List<PresenteRecordatorioInstitucionalDTO> ObtenerLista(int? CargaId = null)
        {
            return presenteRecordatorioInstitucionalDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(PresenteRecordatorioInstitucionalDTO presenteRecordatorioInstitucionalDTO)
        {
            return presenteRecordatorioInstitucionalDAO.AgregarRegistro(presenteRecordatorioInstitucionalDTO);
        }

        public PresenteRecordatorioInstitucionalDTO BuscarFormato(int Codigo)
        {
            return presenteRecordatorioInstitucionalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PresenteRecordatorioInstitucionalDTO presenteRecordatorioInstitucionalDTO)
        {
            return presenteRecordatorioInstitucionalDAO.ActualizaFormato(presenteRecordatorioInstitucionalDTO);
        }

        public bool EliminarFormato(PresenteRecordatorioInstitucionalDTO presenteRecordatorioInstitucionalDTO)
        {
            return presenteRecordatorioInstitucionalDAO.EliminarFormato(presenteRecordatorioInstitucionalDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return presenteRecordatorioInstitucionalDAO.InsertarDatos(datos);
        }

    }
}
