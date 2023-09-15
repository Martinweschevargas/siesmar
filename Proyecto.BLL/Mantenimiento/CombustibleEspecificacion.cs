using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CombustibleEspecificacion
    {
        readonly CombustibleEspecificacionDAO combustibleEspecificacionDAO = new();

        public List<CombustibleEspecificacionDTO> ObtenerCombustibleEspecificacions()
        {
            return combustibleEspecificacionDAO.ObtenerCombustibleEspecificacions();
        }

        public string AgregarCombustibleEspecificacion(CombustibleEspecificacionDTO combustibleEspecificacionDto)
        {
            return combustibleEspecificacionDAO.AgregarCombustibleEspecificacion(combustibleEspecificacionDto);
        }

        public CombustibleEspecificacionDTO BuscarCombustibleEspecificacionID(int Codigo)
        {
            return combustibleEspecificacionDAO.BuscarCombustibleEspecificacionID(Codigo);
        }

        public string ActualizarCombustibleEspecificacion(CombustibleEspecificacionDTO combustibleEspecificacionDto)
        {
            return combustibleEspecificacionDAO.ActualizarCombustibleEspecificacion(combustibleEspecificacionDto);
        }

        public string EliminarCombustibleEspecificacion(CombustibleEspecificacionDTO combustibleEspecificacionDto)
        {
            return combustibleEspecificacionDAO.EliminarCombustibleEspecificacion(combustibleEspecificacionDto);
        }

    }
}
