using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MotivoEmergencia
    {
        readonly MotivoEmergenciaDAO motivoEmergenciaDAO = new();

        public List<MotivoEmergenciaDTO> ObtenerMotivoEmergencias()
        {
            return motivoEmergenciaDAO.ObtenerMotivoEmergencias();
        }

        public string AgregarMotivoEmergencia(MotivoEmergenciaDTO motivoEmergenciaDto)
        {
            return motivoEmergenciaDAO.AgregarMotivoEmergencia(motivoEmergenciaDto);
        }

        public MotivoEmergenciaDTO BuscarMotivoEmergenciaID(int Codigo)
        {
            return motivoEmergenciaDAO.BuscarMotivoEmergenciaID(Codigo);
        }

        public string ActualizarMotivoEmergencia(MotivoEmergenciaDTO motivoEmergenciaDto)
        {
            return motivoEmergenciaDAO.ActualizarMotivoEmergencia(motivoEmergenciaDto);
        }

        public string EliminarMotivoEmergencia(MotivoEmergenciaDTO motivoEmergenciaDto)
        {
            return motivoEmergenciaDAO.EliminarMotivoEmergencia(motivoEmergenciaDto);
        }

    }
}
