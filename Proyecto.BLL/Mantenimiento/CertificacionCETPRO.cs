using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CertificacionCETPRO
    {
        readonly CertificacionCETPRODAO certificacionCETPRODAO = new();

        public List<CertificacionCETPRODTO> ObtenerCertificacionCETPROs()
        {
            return certificacionCETPRODAO.ObtenerCertificacionCETPROs();
        }

        public string AgregarCertificacionCETPRO(CertificacionCETPRODTO certificacionCETPRODto)
        {
            return certificacionCETPRODAO.AgregarCertificacionCETPRO(certificacionCETPRODto);
        }

        public CertificacionCETPRODTO BuscarCertificacionCETPROID(int Codigo)
        {
            return certificacionCETPRODAO.BuscarCertificacionCETPROID(Codigo);
        }

        public string ActualizarCertificacionCETPRO(CertificacionCETPRODTO certificacionCETPRODto)
        {
            return certificacionCETPRODAO.ActualizarCertificacionCETPRO(certificacionCETPRODto);
        }

        public string EliminarCertificacionCETPRO(CertificacionCETPRODTO certificacionCETPRODto)
        {
            return certificacionCETPRODAO.EliminarCertificacionCETPRO(certificacionCETPRODto);
        }

    }
}
