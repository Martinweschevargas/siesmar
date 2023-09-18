using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CategoriaPago
    {
        readonly CategoriaPagoDAO CategoriaPagoDAO = new();

        public List<CategoriaPagoDTO> ObtenerCategoriaPagos()
        {
            return CategoriaPagoDAO.ObtenerCategoriaPagos();
        }

        public string AgregarCategoriaPago(CategoriaPagoDTO categoriaPagoDto)
        {
            return CategoriaPagoDAO.AgregarCategoriaPago(categoriaPagoDto);
        }

        public CategoriaPagoDTO BuscarCategoriaPagoID(int Codigo)
        {
            return CategoriaPagoDAO.BuscarCategoriaPagoID(Codigo);
        }

        public string ActualizarCategoriaPago(CategoriaPagoDTO categoriaPagoDto)
        {
            return CategoriaPagoDAO.ActualizarCategoriaPago(categoriaPagoDto);
        }

        public string EliminarCategoriaPago(CategoriaPagoDTO categoriaPagoDto)
        {
            return CategoriaPagoDAO.EliminarCategoriaPago(categoriaPagoDto);
        }

    }
}
