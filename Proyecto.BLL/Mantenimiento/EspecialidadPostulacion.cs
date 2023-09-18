using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EspecialidadPostulacion
    {
        readonly EspecialidadPostulacionDAO especialidadPostulacionDAO = new();

        public List<EspecialidadPostulacionDTO> ObtenerEspecialidadPostulacions()
        {
            return especialidadPostulacionDAO.ObtenerEspecialidadPostulacions();
        }

        public string AgregarEspecialidadPostulacion(EspecialidadPostulacionDTO especialidadPostulacionDto)
        {
            return especialidadPostulacionDAO.AgregarEspecialidadPostulacion(especialidadPostulacionDto);
        }

        public EspecialidadPostulacionDTO BuscarEspecialidadPostulacionID(int Codigo)
        {
            return especialidadPostulacionDAO.BuscarEspecialidadPostulacionID(Codigo);
        }

        public string ActualizarEspecialidadPostulacion(EspecialidadPostulacionDTO especialidadPostulacionDto)
        {
            return especialidadPostulacionDAO.ActualizarEspecialidadPostulacion(especialidadPostulacionDto);
        }

        public string EliminarEspecialidadPostulacion(EspecialidadPostulacionDTO especialidadPostulacionDto)
        {
            return especialidadPostulacionDAO.EliminarEspecialidadPostulacion(especialidadPostulacionDto);
        }

    }
}
