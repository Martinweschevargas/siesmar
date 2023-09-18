using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MaterialIncautado
    {
        readonly MaterialIncautadoDAO MaterialIncautadoDAO = new();

        public List<MaterialIncautadoDTO> ObtenerCapintanias()
        {
            return MaterialIncautadoDAO.ObtenerMaterialIncautados();
        }

        public string AgregarMaterialIncautado(MaterialIncautadoDTO MaterialIncautadoDto)
        {
            return MaterialIncautadoDAO.AgregarMaterialIncautado(MaterialIncautadoDto);
        }

        public MaterialIncautadoDTO BuscarMaterialIncautadoID(int Codigo)
        {
            return MaterialIncautadoDAO.BuscarMaterialIncautadoID(Codigo);
        }

        public string ActualizarMaterialIncautado(MaterialIncautadoDTO MaterialIncautadoDTO)
        {
            return MaterialIncautadoDAO.ActualizarMaterialIncautado(MaterialIncautadoDTO);
        }

        public string EliminarMaterialIncautado(MaterialIncautadoDTO MaterialIncautadoDTO)
        {
            return MaterialIncautadoDAO.EliminarMaterialIncautado(MaterialIncautadoDTO);
        }

    }
}
