using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EmpresaProveedora
    {
        readonly EmpresaProveedoraDAO empresaProveedoraDAO = new();

        public List<EmpresaProveedoraDTO> ObtenerEmpresaProveedoras()
        {
            return empresaProveedoraDAO.ObtenerEmpresaProveedoras();
        }

        public string AgregarEmpresaProveedora(EmpresaProveedoraDTO empresaProveedoraDto)
        {
            return empresaProveedoraDAO.AgregarEmpresaProveedora(empresaProveedoraDto);
        }

        public EmpresaProveedoraDTO BuscarEmpresaProveedoraID(int Codigo)
        {
            return empresaProveedoraDAO.BuscarEmpresaProveedoraID(Codigo);
        }

        public string ActualizarEmpresaProveedora(EmpresaProveedoraDTO empresaProveedoraDto)
        {
            return empresaProveedoraDAO.ActualizarEmpresaProveedora(empresaProveedoraDto);
        }

        public string EliminarEmpresaProveedora(EmpresaProveedoraDTO empresaProveedoraDto)
        {
            return empresaProveedoraDAO.EliminarEmpresaProveedora(empresaProveedoraDto);
        }

    }
}
