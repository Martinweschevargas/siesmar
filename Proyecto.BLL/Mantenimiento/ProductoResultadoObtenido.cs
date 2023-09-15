using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ProductoResultadoObtenido
    {
        readonly ProductoResultadoObtenidoDAO productoResultadoObtenidoDAO = new();

        public List<ProductoResultadoObtenidoDTO> ObtenerProductoResultadoObtenidos()
        {
            return productoResultadoObtenidoDAO.ObtenerProductoResultadoObtenidos();
        }

        public string AgregarProductoResultadoObtenido(ProductoResultadoObtenidoDTO productoResultadoObtenidoDto)
        {
            return productoResultadoObtenidoDAO.AgregarProductoResultadoObtenido(productoResultadoObtenidoDto);
        }

        public ProductoResultadoObtenidoDTO BuscarProductoResultadoObtenidoID(int Codigo)
        {
            return productoResultadoObtenidoDAO.BuscarProductoResultadoObtenidoID(Codigo);
        }

        public string ActualizarProductoResultadoObtenido(ProductoResultadoObtenidoDTO productoResultadoObtenidoDto)
        {
            return productoResultadoObtenidoDAO.ActualizarProductoResultadoObtenido(productoResultadoObtenidoDto);
        }

        public string EliminarProductoResultadoObtenido(ProductoResultadoObtenidoDTO productoResultadoObtenidoDto)
        {
            return productoResultadoObtenidoDAO.EliminarProductoResultadoObtenido(productoResultadoObtenidoDto);
        }

    }
}
