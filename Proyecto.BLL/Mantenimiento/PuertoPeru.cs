using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PuertoPeru
    {
        readonly PuertoPeruDAO puertoPeruDAO = new();

        public List<PuertoPeruDTO> ObtenerPuertoPerus()
        {
            return puertoPeruDAO.ObtenerPuertoPerus();
        }

        public string AgregarPuertoPeru(PuertoPeruDTO puertoPeruDTO)
        {
            return puertoPeruDAO.AgregarPuertoPeru(puertoPeruDTO);
        }

        public PuertoPeruDTO BuscarPuertoPeruID(int Codigo)
        {
            return puertoPeruDAO.BuscarPuertoPeruID(Codigo);
        }

        public string ActualizarPuertoPeru(PuertoPeruDTO puertoPeruDTO)
        {
            return puertoPeruDAO.ActualizarPuertoPeru(puertoPeruDTO);
        }

        public string EliminarPuertoPeru(PuertoPeruDTO puertoPeruDTO)
        {
            return puertoPeruDAO.EliminarPuertoPeru(puertoPeruDTO);
        }

    }
}