using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class UnidadNavalEspecificacion
    {
        readonly UnidadNavalEspecificacionDAO unidadNavalEspecificacionDAO = new();

        public List<UnidadNavalEspecificacionDTO> ObtenerUnidadNavalEspecificacions()
        {
            return unidadNavalEspecificacionDAO.ObtenerUnidadNavalEspecificacions();
        }

        public string AgregarUnidadNavalEspecificacion(UnidadNavalEspecificacionDTO unidadNavalEspecificacionDto)
        {
            return unidadNavalEspecificacionDAO.AgregarUnidadNavalEspecificacion(unidadNavalEspecificacionDto);
        }

        public UnidadNavalEspecificacionDTO BuscarUnidadNavalEspecificacionID(int Codigo)
        {
            return unidadNavalEspecificacionDAO.BuscarUnidadNavalEspecificacionID(Codigo);
        }

        public string ActualizarUnidadNavalEspecificacion(UnidadNavalEspecificacionDTO unidadNavalEspecificacionDto)
        {
            return unidadNavalEspecificacionDAO.ActualizarUnidadNavalEspecificacion(unidadNavalEspecificacionDto);
        }

        public string EliminarUnidadNavalEspecificacion(UnidadNavalEspecificacionDTO unidadNavalEspecificacionDto)
        {
            return unidadNavalEspecificacionDAO.EliminarUnidadNavalEspecificacion(unidadNavalEspecificacionDto);
        }

    }
}
