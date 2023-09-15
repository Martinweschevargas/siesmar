using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class FormaContactoAfiliado
    {
        readonly FormaContactoAfiliadoDAO formaContactoAfiliadoDAO = new();

        public List<FormaContactoAfiliadoDTO> ObtenerFormaContactoAfiliados()
        {
            return formaContactoAfiliadoDAO.ObtenerFormaContactoAfiliados();
        }

        public string AgregarFormaContactoAfiliado(FormaContactoAfiliadoDTO formaContactoAfiliadoDto)
        {
            return formaContactoAfiliadoDAO.AgregarFormaContactoAfiliado(formaContactoAfiliadoDto);
        }

        public FormaContactoAfiliadoDTO BuscarFormaContactoAfiliadoID(int Codigo)
        {
            return formaContactoAfiliadoDAO.BuscarFormaContactoAfiliadoID(Codigo);
        }

        public string ActualizarFormaContactoAfiliado(FormaContactoAfiliadoDTO formaContactoAfiliadoDto)
        {
            return formaContactoAfiliadoDAO.ActualizarFormaContactoAfiliado(formaContactoAfiliadoDto);
        }

        public string EliminarFormaContactoAfiliado(FormaContactoAfiliadoDTO formaContactoAfiliadoDto)
        {
            return formaContactoAfiliadoDAO.EliminarFormaContactoAfiliado(formaContactoAfiliadoDto);
        }

    }
}
