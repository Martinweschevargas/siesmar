using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MedioComunicacion
    {
        readonly MedioComunicacionDAO medioComunicacionDAO = new();

        public List<MedioComunicacionDTO> ObtenerMedioComunicacions()
        {
            return medioComunicacionDAO.ObtenerMedioComunicacions();
        }

        public string AgregarMedioComunicacion(MedioComunicacionDTO medioComunicacionDto)
        {
            return medioComunicacionDAO.AgregarMedioComunicacion(medioComunicacionDto);
        }

        public MedioComunicacionDTO BuscarMedioComunicacionID(int Codigo)
        {
            return medioComunicacionDAO.BuscarMedioComunicacionID(Codigo);
        }

        public string ActualizarMedioComunicacion(MedioComunicacionDTO medioComunicacionDto)
        {
            return medioComunicacionDAO.ActualizarMedioComunicacion(medioComunicacionDto);
        }

        public string EliminarMedioComunicacion(MedioComunicacionDTO medioComunicacionDto)
        {
            return medioComunicacionDAO.EliminarMedioComunicacion(medioComunicacionDto);
        }

    }
}
