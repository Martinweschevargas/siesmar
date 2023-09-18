using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ProcedimientoMedicoSubseccion
    {
        readonly ProcedimientoMedicoSubseccionDAO procedimientoMedicoSubseccionDAO = new();

        public List<ProcedimientoMedicoSubseccionDTO> ObtenerProcedimientoMedicoSubseccions()
        {
            return procedimientoMedicoSubseccionDAO.ObtenerProcedimientoMedicoSubseccions();
        }

        public string AgregarProcedimientoMedicoSubseccion(ProcedimientoMedicoSubseccionDTO procedimientoMedicoSubseccionDto)
        {
            return procedimientoMedicoSubseccionDAO.AgregarProcedimientoMedicoSubseccion(procedimientoMedicoSubseccionDto);
        }

        public ProcedimientoMedicoSubseccionDTO BuscarProcedimientoMedicoSubseccionID(int Codigo)
        {
            return procedimientoMedicoSubseccionDAO.BuscarProcedimientoMedicoSubseccionID(Codigo);
        }

        public string ActualizarProcedimientoMedicoSubseccion(ProcedimientoMedicoSubseccionDTO procedimientoMedicoSubseccionDto)
        {
            return procedimientoMedicoSubseccionDAO.ActualizarProcedimientoMedicoSubseccion(procedimientoMedicoSubseccionDto);
        }

        public string EliminarProcedimientoMedicoSubseccion(ProcedimientoMedicoSubseccionDTO procedimientoMedicoSubseccionDto)
        {
            return procedimientoMedicoSubseccionDAO.EliminarProcedimientoMedicoSubseccion(procedimientoMedicoSubseccionDto);
        }

    }
}
