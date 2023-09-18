using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PuntoDistribucionPanificacion
    {
        readonly PuntoDistribucionPanificacionDAO puntoDistribucionPanificacionDAO = new();

        public List<PuntoDistribucionPanificacionDTO> ObtenerPuntoDistribucionPanificacions()
        {
            return puntoDistribucionPanificacionDAO.ObtenerPuntoDistribucionPanificacions();
        }

        public string AgregarPuntoDistribucionPanificacion(PuntoDistribucionPanificacionDTO puntoDistribucionPanificacionDto)
        {
            return puntoDistribucionPanificacionDAO.AgregarPuntoDistribucionPanificacion(puntoDistribucionPanificacionDto);
        }

        public PuntoDistribucionPanificacionDTO BuscarPuntoDistribucionPanificacionID(int Codigo)
        {
            return puntoDistribucionPanificacionDAO.BuscarPuntoDistribucionPanificacionID(Codigo);
        }

        public string ActualizarPuntoDistribucionPanificacion(PuntoDistribucionPanificacionDTO puntoDistribucionPanificacionDTO)
        {
            return puntoDistribucionPanificacionDAO.ActualizarPuntoDistribucionPanificacion(puntoDistribucionPanificacionDTO);
        }

        public bool EliminarPuntoDistribucionPanificacion(PuntoDistribucionPanificacionDTO puntoDistribucionPanificacionDTO)
        {
            return puntoDistribucionPanificacionDAO.EliminarPuntoDistribucionPanificacion(puntoDistribucionPanificacionDTO);
        }

    }
}
