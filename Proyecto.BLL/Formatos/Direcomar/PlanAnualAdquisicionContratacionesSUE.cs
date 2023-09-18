using Marina.Siesmar.AccesoDatos.Formatos.Direcomar;
using Marina.Siesmar.Entidades.Formatos.Direcomar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Direcomar
{
    public class PlanAnualAdquisicionContratacionesSUE
    {
        PlanAnualAdquisicionContratacionesSUEDAO planAnualAdquisicionContratacionSUEDTODAO = new();

        public List<PlanAnualAdquisicionContratacionesSUEDTO> ObtenerLista(int? CargaId = null, string? fechaInicio = null, string? fechaFin = null)
        {
            return planAnualAdquisicionContratacionSUEDTODAO.ObtenerLista(CargaId, fechaInicio, fechaFin);
        }

        public List<PlanAnualAdquisicionContratacionesSUEDTO> DirecomarVisualizacionPlanAnualAdquisicionContratacionesSUE(int? CargaId = null, string? fechaInicio = null, string? fechaFin = null)
        {
            return planAnualAdquisicionContratacionSUEDTODAO.DirecomarVisualizacionPlanAnualAdquisicionContratacionesSUE(CargaId, fechaInicio, fechaFin);
        }

        public string AgregarRegistro(PlanAnualAdquisicionContratacionesSUEDTO planAnualAdquisicionContratacionSUEDTODTO, string fechaCarga)
        {
            return planAnualAdquisicionContratacionSUEDTODAO.AgregarRegistro(planAnualAdquisicionContratacionSUEDTODTO, fechaCarga);
        }

        public PlanAnualAdquisicionContratacionesSUEDTO EditarFormato(int Codigo)
        {
            return planAnualAdquisicionContratacionSUEDTODAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PlanAnualAdquisicionContratacionesSUEDTO planAnualAdquisicionContratacionSUEDTODTO)
        {
            return planAnualAdquisicionContratacionSUEDTODAO.ActualizaFormato(planAnualAdquisicionContratacionSUEDTODTO);
        }

        public bool EliminarFormato(PlanAnualAdquisicionContratacionesSUEDTO planAnualAdquisicionContratacionSUEDTODTO)
        {
            return planAnualAdquisicionContratacionSUEDTODAO.EliminarFormato(planAnualAdquisicionContratacionSUEDTODTO);
        }

        public bool EliminarCarga(PlanAnualAdquisicionContratacionesSUEDTO planAnualAdquisicionContratacionSUEDTODTO)
        {
            return planAnualAdquisicionContratacionSUEDTODAO.EliminarCarga(planAnualAdquisicionContratacionSUEDTODTO);
        }

        public string InsertarDatos(DataTable datos, string fechaCarga)
        {
            return planAnualAdquisicionContratacionSUEDTODAO.InsertarDatos(datos, fechaCarga);
        }

    }
}
