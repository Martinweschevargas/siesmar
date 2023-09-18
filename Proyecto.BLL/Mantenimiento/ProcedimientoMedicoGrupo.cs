using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ProcedimientoMedicoGrupo
    {
        readonly ProcedimientoMedicoGrupoDAO procedimientoMedicoGrupoDAO = new();

        public List<ProcedimientoMedicoGrupoDTO> ObtenerProcedimientoMedicoGrupos()
        {
            return procedimientoMedicoGrupoDAO.ObtenerProcedimientoMedicoGrupos();
        }

        public string AgregarProcedimientoMedicoGrupo(ProcedimientoMedicoGrupoDTO procedimientoMedicoGrupoDto)
        {
            return procedimientoMedicoGrupoDAO.AgregarProcedimientoMedicoGrupo(procedimientoMedicoGrupoDto);
        }

        public ProcedimientoMedicoGrupoDTO BuscarProcedimientoMedicoGrupoID(int Codigo)
        {
            return procedimientoMedicoGrupoDAO.BuscarProcedimientoMedicoGrupoID(Codigo);
        }

        public string ActualizarProcedimientoMedicoGrupo(ProcedimientoMedicoGrupoDTO procedimientoMedicoGrupoDto)
        {
            return procedimientoMedicoGrupoDAO.ActualizarProcedimientoMedicoGrupo(procedimientoMedicoGrupoDto);
        }

        public string EliminarProcedimientoMedicoGrupo(ProcedimientoMedicoGrupoDTO procedimientoMedicoGrupoDto)
        {
            return procedimientoMedicoGrupoDAO.EliminarProcedimientoMedicoGrupo(procedimientoMedicoGrupoDto);
        }

    }
}
