using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ProductoPanificacion
    {

        readonly ProductoPanificacionDAO productoPanificacionDAO = new();

        public List<ProductoPanificacionDTO> ObtenerProductos()
        {
            return productoPanificacionDAO.ObtenerProductos();
        }

        public string AgregarProducto(ProductoPanificacionDTO productoPanificacionDTO)
        {
            return productoPanificacionDAO.AgregarProducto(productoPanificacionDTO);
        }

        public ProductoPanificacionDTO BuscarProductoID(int Codigo)
        {
            return productoPanificacionDAO.BuscarProductoPanificacionId(Codigo);
        }

        public string ActualizarProducto(ProductoPanificacionDTO productoPanificacionDTO)
        {
            return productoPanificacionDAO.ActualizarProducto(productoPanificacionDTO);
        }

        public string EliminarProducto(ProductoPanificacionDTO productoPanificacionDTO)
        {
            return productoPanificacionDAO.EliminarProducto(productoPanificacionDTO);
        }

    }
}
