using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MotivoInvestigacion
    {
        readonly MotivoInvestigacionDAO motivoInvestigacionDAO = new();

        public List<MotivoInvestigacionDTO> ObtenerMotivoInvestigacions()
        {
            return motivoInvestigacionDAO.ObtenerMotivoInvestigacions();
        }

        public string AgregarMotivoInvestigacion(MotivoInvestigacionDTO motivoInvestigacionDto)
        {
            return motivoInvestigacionDAO.AgregarMotivoInvestigacion(motivoInvestigacionDto);
        }

        public MotivoInvestigacionDTO BuscarMotivoInvestigacionID(int Codigo)
        {
            return motivoInvestigacionDAO.BuscarMotivoInvestigacionID(Codigo);
        }

        public string ActualizarMotivoInvestigacion(MotivoInvestigacionDTO motivoInvestigacionDTO)
        {
            return motivoInvestigacionDAO.ActualizarMotivoInvestigacion(motivoInvestigacionDTO);
        }

        public string EliminarMotivoInvestigacion(MotivoInvestigacionDTO motivoInvestigacionDTO)
        {
            return motivoInvestigacionDAO.EliminarMotivoInvestigacion(motivoInvestigacionDTO);
        }

    }
}
