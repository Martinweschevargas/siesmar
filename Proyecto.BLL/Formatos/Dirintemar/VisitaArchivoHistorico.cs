using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirintemar
{
    public class VisitaArchivoHistorico
    {
        VisitaArchivoHistoricoDAO visitaArchivoHistoricoDAO = new();

        public List<VisitaArchivoHistoricoDTO> ObtenerLista()
        {
            return visitaArchivoHistoricoDAO.ObtenerLista();
        }

        public string AgregarRegistro(VisitaArchivoHistoricoDTO visitaArchivoHistorico)
        {
            return visitaArchivoHistoricoDAO.AgregarRegistro(visitaArchivoHistorico);
        }

        public VisitaArchivoHistoricoDTO EditarFormato(int Codigo)
        {
            return visitaArchivoHistoricoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(VisitaArchivoHistoricoDTO visitaArchivoHistoricoDTO)
        {
            return visitaArchivoHistoricoDAO.ActualizaFormato(visitaArchivoHistoricoDTO);
        }

        public bool EliminarFormato(VisitaArchivoHistoricoDTO visitaArchivoHistoricoDTO)
        {
            return visitaArchivoHistoricoDAO.EliminarFormato(visitaArchivoHistoricoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return visitaArchivoHistoricoDAO.InsertarDatos(datos);
        }

    }
}
