using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CategoriaNovedad
    {
        readonly CategoriaNovedadDAO categoriaNovedadDAO = new();

        public List<CategoriaNovedadDTO> ObtenerCategoriaNovedads()
        {
            return categoriaNovedadDAO.ObtenerCategoriaNovedads();
        }

        public string AgregarCategoriaNovedad(CategoriaNovedadDTO categoriaNovedadDto)
        {
            return categoriaNovedadDAO.AgregarCategoriaNovedad(categoriaNovedadDto);
        }

        public CategoriaNovedadDTO BuscarCategoriaNovedadID(int Codigo)
        {
            return categoriaNovedadDAO.BuscarCategoriaNovedadID(Codigo);
        }

        public string ActualizarCategoriaNovedad(CategoriaNovedadDTO categoriaNovedadDto)
        {
            return categoriaNovedadDAO.ActualizarCategoriaNovedad(categoriaNovedadDto);
        }

        public string EliminarCategoriaNovedad(CategoriaNovedadDTO categoriaNovedadDto)
        {
            return categoriaNovedadDAO.EliminarCategoriaNovedad(categoriaNovedadDto);
        }

    }
}
