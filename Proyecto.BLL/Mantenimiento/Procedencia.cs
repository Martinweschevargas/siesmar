using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Procedencia
    {
        readonly ProcedenciaDAO procedenciaDAO = new();

        public List<ProcedenciaDTO> ObtenerProcedencias()
        {
            return procedenciaDAO.ObtenerProcedencias();
        }

        public string AgregarProcedencia(ProcedenciaDTO procedenciaDto)
        {
            return procedenciaDAO.AgregarProcedencia(procedenciaDto);
        }

        public ProcedenciaDTO BuscarProcedenciaID(int Codigo)
        {
            return procedenciaDAO.BuscarProcedenciaID(Codigo);
        }

        public string ActualizarProcedencia(ProcedenciaDTO procedenciaDto)
        {
            return procedenciaDAO.ActualizarProcedencia(procedenciaDto);
        }

        public string EliminarProcedencia(ProcedenciaDTO procedenciaDto)
        {
            return procedenciaDAO.EliminarProcedencia(procedenciaDto);
        }

    }
}
