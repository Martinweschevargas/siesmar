using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class PlanAnualRecaerDistribucionPresupuestoComfas
    {
        PlanAnualRecaerDistribucionPresupuestoComfasDAO planAnualRecaerDistribucionPresupuestoComfasDAO = new();

        public List<PlanAnualRecaerDistribucionPresupuestoComfasDTO> ObtenerLista()
        {
            return planAnualRecaerDistribucionPresupuestoComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(PlanAnualRecaerDistribucionPresupuestoComfasDTO planAnualRecaerDistribucionPresupuestoComfasDTO)
        {
            return planAnualRecaerDistribucionPresupuestoComfasDAO.AgregarRegistro(planAnualRecaerDistribucionPresupuestoComfasDTO);
        }

        public PlanAnualRecaerDistribucionPresupuestoComfasDTO BuscarFormato(int Codigo)
        {
            return planAnualRecaerDistribucionPresupuestoComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PlanAnualRecaerDistribucionPresupuestoComfasDTO planAnualRecaerDistribucionPresupuestoComfasDTO)
        {
            return planAnualRecaerDistribucionPresupuestoComfasDAO.ActualizaFormato(planAnualRecaerDistribucionPresupuestoComfasDTO);
        }

        public bool EliminarFormato(PlanAnualRecaerDistribucionPresupuestoComfasDTO planAnualRecaerDistribucionPresupuestoComfasDTO)
        {
            return planAnualRecaerDistribucionPresupuestoComfasDAO.EliminarFormato(planAnualRecaerDistribucionPresupuestoComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<PlanAnualRecaerDistribucionPresupuestoComfasDTO> planAnualRecaerDistribucionPresupuestoComfasDTO)
        {
            return planAnualRecaerDistribucionPresupuestoComfasDAO.InsercionMasiva(planAnualRecaerDistribucionPresupuestoComfasDTO);
        }

    }
}
