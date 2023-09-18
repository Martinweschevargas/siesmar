using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ModalidadVenta
    {
        readonly ModalidadVentaDAO modalidadVentaDAO = new();

        public List<ModalidadVentaDTO> ObtenerModalidadVentas()
        {
            return modalidadVentaDAO.ObtenerModalidadVentas();
        }

        public string AgregarModalidadVenta(ModalidadVentaDTO modalidadVentaDto)
        {
            return modalidadVentaDAO.AgregarModalidadVenta(modalidadVentaDto);
        }

        public ModalidadVentaDTO BuscarModalidadVentaID(int Codigo)
        {
            return modalidadVentaDAO.BuscarModalidadVentaID(Codigo);
        }

        public string ActualizarModalidadVenta(ModalidadVentaDTO modalidadVentaDto)
        {
            return modalidadVentaDAO.ActualizarModalidadVenta(modalidadVentaDto);
        }

        public string EliminarModalidadVenta(ModalidadVentaDTO modalidadVentaDto)
        {
            return modalidadVentaDAO.EliminarModalidadVenta(modalidadVentaDto);
        }

    }
}
