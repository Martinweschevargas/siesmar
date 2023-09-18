using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PlataformaMedioComunicacion
    {
        readonly PlataformaMedioComunicacionDAO plataformaMedioComunicacionDAO = new();

        public List<PlataformaMedioComunicacionDTO> ObtenerPlataformaMedioComunicacions()
        {
            return plataformaMedioComunicacionDAO.ObtenerPlataformaMedioComunicacions();
        }

        public string AgregarPlataformaMedioComunicacion(PlataformaMedioComunicacionDTO plataformaMedioComunicacionDto)
        {
            return plataformaMedioComunicacionDAO.AgregarPlataformaMedioComunicacion(plataformaMedioComunicacionDto);
        }

        public PlataformaMedioComunicacionDTO BuscarPlataformaMedioComunicacionID(int Codigo)
        {
            return plataformaMedioComunicacionDAO.BuscarPlataformaMedioComunicacionID(Codigo);
        }

        public string ActualizarPlataformaMedioComunicacion(PlataformaMedioComunicacionDTO plataformaMedioComunicacionDTO)
        {
            return plataformaMedioComunicacionDAO.ActualizarPlataformaMedioComunicacion(plataformaMedioComunicacionDTO);
        }

        public bool EliminarPlataformaMedioComunicacion(PlataformaMedioComunicacionDTO plataformaMedioComunicacionDTO)
        {
            return plataformaMedioComunicacionDAO.EliminarPlataformaMedioComunicacion(plataformaMedioComunicacionDTO);
        }

    }
}
