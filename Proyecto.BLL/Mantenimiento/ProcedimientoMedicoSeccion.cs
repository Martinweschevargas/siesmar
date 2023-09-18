using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ProcedimientoMedicoSeccion
    {
        readonly ProcedimientoMedicoSeccionDAO procedimientoMedicoSeccionDAO = new();

        public List<ProcedimientoMedicoSeccionDTO> ObtenerProcedimientoMedicoSeccions()
        {
            return procedimientoMedicoSeccionDAO.ObtenerProcedimientoMedicoSeccions();
        }

        public string AgregarProcedimientoMedicoSeccion(ProcedimientoMedicoSeccionDTO procedimientoMedicoSeccionDto)
        {
            return procedimientoMedicoSeccionDAO.AgregarProcedimientoMedicoSeccion(procedimientoMedicoSeccionDto);
        }

        public ProcedimientoMedicoSeccionDTO BuscarProcedimientoMedicoSeccionID(int Codigo)
        {
            return procedimientoMedicoSeccionDAO.BuscarProcedimientoMedicoSeccionID(Codigo);
        }

        public string ActualizarProcedimientoMedicoSeccion(ProcedimientoMedicoSeccionDTO procedimientoMedicoSeccionDto)
        {
            return procedimientoMedicoSeccionDAO.ActualizarProcedimientoMedicoSeccion(procedimientoMedicoSeccionDto);
        }

        public string EliminarProcedimientoMedicoSeccion(ProcedimientoMedicoSeccionDTO procedimientoMedicoSeccionDto)
        {
            return procedimientoMedicoSeccionDAO.EliminarProcedimientoMedicoSeccion(procedimientoMedicoSeccionDto);
        }

    }
}
