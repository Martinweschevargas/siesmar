using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ProductoDimar
    {
        readonly ProductoDimarDAO productoDimarDAO = new();

        public List<ProductoDimarDTO> ObtenerProductoDimars()
        {
            return productoDimarDAO.ObtenerProductoDimars();
        }

        public string AgregarProductoDimar(ProductoDimarDTO productoDimarDto)
        {
            return productoDimarDAO.AgregarProductoDimar(productoDimarDto);
        }

        public ProductoDimarDTO BuscarProductoDimarID(int Codigo)
        {
            return productoDimarDAO.BuscarProductoDimarID(Codigo);
        }

        public string ActualizarProductoDimar(ProductoDimarDTO productoDimarDto)
        {
            return productoDimarDAO.ActualizarProductoDimar(productoDimarDto);
        }

        public string EliminarProductoDimar(ProductoDimarDTO productoDimarDto)
        {
            return productoDimarDAO.EliminarProductoDimar(productoDimarDto);
        }

    }
}
