using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EstablecimientoSaludMGP
    {
        readonly EstablecimientoSaludMGPDAO establecimientoSaludMGPDAO = new();

        public List<EstablecimientoSaludMGPDTO> ObtenerEstablecimientoSaludMGPs()
        {
            return establecimientoSaludMGPDAO.ObtenerEstablecimientoSaludMGPs();
        }

        public string AgregarEstablecimientoSaludMGP(EstablecimientoSaludMGPDTO establecimientoSaludMGPDto)
        {
            return establecimientoSaludMGPDAO.AgregarEstablecimientoSaludMGP(establecimientoSaludMGPDto);
        }

        public EstablecimientoSaludMGPDTO BuscarEstablecimientoSaludMGPID(int Codigo)
        {
            return establecimientoSaludMGPDAO.BuscarEstablecimientoSaludMGPID(Codigo);
        }

        public string ActualizarEstablecimientoSaludMGP(EstablecimientoSaludMGPDTO establecimientoSaludMGPDto)
        {
            return establecimientoSaludMGPDAO.ActualizarEstablecimientoSaludMGP(establecimientoSaludMGPDto);
        }

        public string EliminarEstablecimientoSaludMGP(EstablecimientoSaludMGPDTO establecimientoSaludMGPDto)
        {
            return establecimientoSaludMGPDAO.EliminarEstablecimientoSaludMGP(establecimientoSaludMGPDto);
        }

    }
}
