using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AsuntoApelacionReconsideracion
    {
        readonly AsuntoApelacionReconsideracionDAO asuntoApelacionReconsideracionDAO = new();

        public List<AsuntoApelacionReconsideracionDTO> ObtenerAsuntoApelacionReconsideracions()
        {
            return asuntoApelacionReconsideracionDAO.ObtenerAsuntoApelacionReconsideraciones();
        }

        public string AgregarAsuntoApelacionReconsideracion(AsuntoApelacionReconsideracionDTO asuntoApelacionReconsideracionDto)
        {
            return asuntoApelacionReconsideracionDAO.AgregarAsuntoApelacionReconsideracion(asuntoApelacionReconsideracionDto);
        }

        public AsuntoApelacionReconsideracionDTO BuscarAsuntoApelacionReconsideracionID(int Codigo)
        {
            return asuntoApelacionReconsideracionDAO.BuscarAsuntoApelacionReconsideracionID(Codigo);
        }

        public string ActualizarAsuntoApelacionReconsideracion(AsuntoApelacionReconsideracionDTO asuntoApelacionReconsideracionDto)
        {
            return asuntoApelacionReconsideracionDAO.ActualizarAsuntoApelacionReconsideracion(asuntoApelacionReconsideracionDto);
        }

        public string EliminarAsuntoApelacionReconsideracion(AsuntoApelacionReconsideracionDTO asuntoApelacionReconsideracionDto)
        {
            return asuntoApelacionReconsideracionDAO.EliminarAsuntoApelacionReconsideracion(asuntoApelacionReconsideracionDto);
        }

    }
}
