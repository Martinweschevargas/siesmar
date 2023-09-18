using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class PlanAnualRecaerAsignacionPresuestalComfas
    {
        PlanAnualRecaerAsignacionPresuestalComfasDAO planAnualRecaerAsignacionPresuestalComfasDAO = new();

        public List<PlanAnualRecaerAsignacionPresuestalComfasDTO> ObtenerLista()
        {
            return planAnualRecaerAsignacionPresuestalComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(PlanAnualRecaerAsignacionPresuestalComfasDTO planAnualRecaerAsignacionPresuestalComfasDTO)
        {
            return planAnualRecaerAsignacionPresuestalComfasDAO.AgregarRegistro(planAnualRecaerAsignacionPresuestalComfasDTO);
        }

        public PlanAnualRecaerAsignacionPresuestalComfasDTO BuscarFormato(int Codigo)
        {
            return planAnualRecaerAsignacionPresuestalComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PlanAnualRecaerAsignacionPresuestalComfasDTO planAnualRecaerAsignacionPresuestalComfasDTO)
        {
            return planAnualRecaerAsignacionPresuestalComfasDAO.ActualizaFormato(planAnualRecaerAsignacionPresuestalComfasDTO);
        }

        public bool EliminarFormato(PlanAnualRecaerAsignacionPresuestalComfasDTO planAnualRecaerAsignacionPresuestalComfasDTO)
        {
            return planAnualRecaerAsignacionPresuestalComfasDAO.EliminarFormato(planAnualRecaerAsignacionPresuestalComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<PlanAnualRecaerAsignacionPresuestalComfasDTO> planAnualRecaerAsignacionPresuestalComfasDTO)
        {
            return planAnualRecaerAsignacionPresuestalComfasDAO.InsercionMasiva(planAnualRecaerAsignacionPresuestalComfasDTO);
        }

    }
}
