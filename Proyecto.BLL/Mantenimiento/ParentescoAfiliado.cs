using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ParentescoAfiliado
    {
        readonly ParentescoAfiliadoDAO parentescoAfiliadoDAO = new();

        public List<ParentescoAfiliadoDTO> ObtenerParentescoAfiliados()
        {
            return parentescoAfiliadoDAO.ObtenerParentescoAfiliados();
        }

        public string AgregarParentescoAfiliado(ParentescoAfiliadoDTO parentescoAfiliadoDto)
        {
            return parentescoAfiliadoDAO.AgregarParentescoAfiliado(parentescoAfiliadoDto);
        }

        public ParentescoAfiliadoDTO BuscarParentescoAfiliadoID(string Codigo)
        {
            return parentescoAfiliadoDAO.BuscarParentescoAfiliadoID(Codigo);
        }

        public string ActualizarParentescoAfiliado(ParentescoAfiliadoDTO parentescoAfiliadoDto)
        {
            return parentescoAfiliadoDAO.ActualizarParentescoAfiliado(parentescoAfiliadoDto);
        }

        public string EliminarParentescoAfiliado(ParentescoAfiliadoDTO parentescoAfiliadoDto)
        {
            return parentescoAfiliadoDAO.EliminarParentescoAfiliado(parentescoAfiliadoDto);
        }

    }
}
