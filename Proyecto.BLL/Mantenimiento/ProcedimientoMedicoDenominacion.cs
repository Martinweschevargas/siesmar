using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ProcedimientoMedicoDenominacion
    {
        readonly ProcedimientoMedicoDenominacionDAO procedimientoMedicoDenominacionDAO = new();

        public List<ProcedimientoMedicoDenominacionDTO> ObtenerProcedimientoMedicoDenominacions()
        {
            return procedimientoMedicoDenominacionDAO.ObtenerProcedimientoMedicoDenominacions();
        }

        public string AgregarProcedimientoMedicoDenominacion(ProcedimientoMedicoDenominacionDTO procedimientoMedicoDenominacionDto)
        {
            return procedimientoMedicoDenominacionDAO.AgregarProcedimientoMedicoDenominacion(procedimientoMedicoDenominacionDto);
        }

        public ProcedimientoMedicoDenominacionDTO BuscarProcedimientoMedicoDenominacionID(int Codigo)
        {
            return procedimientoMedicoDenominacionDAO.BuscarProcedimientoMedicoDenominacionID(Codigo);
        }

        public string ActualizarProcedimientoMedicoDenominacion(ProcedimientoMedicoDenominacionDTO procedimientoMedicoDenominacionDto)
        {
            return procedimientoMedicoDenominacionDAO.ActualizarProcedimientoMedicoDenominacion(procedimientoMedicoDenominacionDto);
        }

        public string EliminarProcedimientoMedicoDenominacion(ProcedimientoMedicoDenominacionDTO procedimientoMedicoDenominacionDto)
        {
            return procedimientoMedicoDenominacionDAO.EliminarProcedimientoMedicoDenominacion(procedimientoMedicoDenominacionDto);
        }

    }
}
