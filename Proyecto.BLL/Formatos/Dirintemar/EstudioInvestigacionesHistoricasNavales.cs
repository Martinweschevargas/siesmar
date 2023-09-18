using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using Microsoft.SqlServer.Server;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirintemar
{
    public class EstudioInvestigacionesHistoricasNavales
    {
        EstudioInvestigacionesHistoricasNavalesDAO estudioinversionesDAO = new();

        public List<EstudioInvestigacionesHistoricasNavalesDTO> ObtenerLista()
        {
            return estudioinversionesDAO.ObtenerLista();
        }

        public string AgregarRegistro(EstudioInvestigacionesHistoricasNavalesDTO capitaniaDto)
        {
            return estudioinversionesDAO.AgregarRegistro(capitaniaDto);
        }

        public EstudioInvestigacionesHistoricasNavalesDTO EditarFormato(int Codigo)
        {
            return estudioinversionesDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EstudioInvestigacionesHistoricasNavalesDTO estudioInvestigacionesHistoricasNavalesDTO)
        {
            return estudioinversionesDAO.ActualizaFormato(estudioInvestigacionesHistoricasNavalesDTO);
        }

        public bool EliminarFormato(EstudioInvestigacionesHistoricasNavalesDTO estudioInvestigacionesHistoricasNavalesDTO)
        {
            return estudioinversionesDAO.EliminarFormato(estudioInvestigacionesHistoricasNavalesDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return estudioinversionesDAO.InsertarDatos(datos);
        }
    }
}
