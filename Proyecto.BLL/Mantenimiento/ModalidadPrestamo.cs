using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ModalidadPrestamo
    {
        readonly ModalidadPrestamoDAO modalidadPrestamoDAO = new();

        public List<ModalidadPrestamoDTO> ObtenerModalidadPrestamos()
        {
            return modalidadPrestamoDAO.ObtenerModalidadPrestamos();
        }

        public string AgregarModalidadPrestamo(ModalidadPrestamoDTO modalidadPrestamoDto)
        {
            return modalidadPrestamoDAO.AgregarModalidadPrestamo(modalidadPrestamoDto);
        }

        public ModalidadPrestamoDTO BuscarModalidadPrestamoID(int Codigo)
        {
            return modalidadPrestamoDAO.BuscarModalidadPrestamoID(Codigo);
        }

        public string ActualizarModalidadPrestamo(ModalidadPrestamoDTO modalidadPrestamoDto)
        {
            return modalidadPrestamoDAO.ActualizarModalidadPrestamo(modalidadPrestamoDto);
        }

        public string EliminarModalidadPrestamo(ModalidadPrestamoDTO modalidadPrestamoDto)
        {
            return modalidadPrestamoDAO.EliminarModalidadPrestamo(modalidadPrestamoDto);
        }

    }
}
