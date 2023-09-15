using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Producto
    {
        readonly ProductoDAO productoDAO = new();

        public List<ProductoDTO> ObtenerProductos()
        {
            return productoDAO.ObtenerProductos();
        }

        public string AgregarProducto(ProductoDTO productoDto)
        {
            return productoDAO.AgregarProducto(productoDto);
        }

        public ProductoDTO BuscarProductoID(int Codigo)
        {
            return productoDAO.BuscarProductoID(Codigo);
        }

        public string ActualizarProducto(ProductoDTO productoDto)
        {
            return productoDAO.ActualizarProducto(productoDto);
        }

        public string EliminarProducto(ProductoDTO productoDto)
        {
            return productoDAO.EliminarProducto(productoDto);
        }

    }
}
