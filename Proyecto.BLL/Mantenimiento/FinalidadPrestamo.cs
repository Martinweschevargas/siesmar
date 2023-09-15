using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class FinalidadPrestamo
    {
        readonly FinalidadPrestamoDAO finalidadPrestamoDAO = new();

        public List<FinalidadPrestamoDTO> ObtenerFinalidadPrestamos()
        {
            return finalidadPrestamoDAO.ObtenerFinalidadPrestamos();
        }

        public string AgregarFinalidadPrestamo(FinalidadPrestamoDTO finalidadPrestamoDto)
        {
            return finalidadPrestamoDAO.AgregarFinalidadPrestamo(finalidadPrestamoDto);
        }

        public FinalidadPrestamoDTO BuscarFinalidadPrestamoID(int Codigo)
        {
            return finalidadPrestamoDAO.BuscarFinalidadPrestamoID(Codigo);
        }

        public string ActualizarFinalidadPrestamo(FinalidadPrestamoDTO finalidadPrestamoDto)
        {
            return finalidadPrestamoDAO.ActualizarFinalidadPrestamo(finalidadPrestamoDto);
        }

        public string EliminarFinalidadPrestamo(FinalidadPrestamoDTO finalidadPrestamoDto)
        {
            return finalidadPrestamoDAO.EliminarFinalidadPrestamo(finalidadPrestamoDto);
        }

    }
}
