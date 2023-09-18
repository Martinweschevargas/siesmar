using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MedioInvestigacion
    {
        readonly MedioInvestigacionDAO medioInvestigacionDAO = new();

        public List<MedioInvestigacionDTO> ObtenerMedioInvestigacions()
        {
            return medioInvestigacionDAO.ObtenerMedioInvestigacions();
        }

        public string AgregarMedioInvestigacion(MedioInvestigacionDTO medioInvestigacionDto)
        {
            return medioInvestigacionDAO.AgregarMedioInvestigacion(medioInvestigacionDto);
        }

        public MedioInvestigacionDTO BuscarMedioInvestigacionID(int Codigo)
        {
            return medioInvestigacionDAO.BuscarMedioInvestigacionID(Codigo);
        }

        public string ActualizarMedioInvestigacion(MedioInvestigacionDTO medioInvestigacionDTO)
        {
            return medioInvestigacionDAO.ActualizarMedioInvestigacion(medioInvestigacionDTO);
        }

        public string EliminarMedioInvestigacion(MedioInvestigacionDTO medioInvestigacionDTO)
        {
            return medioInvestigacionDAO.EliminarMedioInvestigacion(medioInvestigacionDTO);
        }

    }
}
