using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SeccionEstudio
    {
        readonly SeccionEstudioDAO SeccionEstudioDAO = new();

        public List<SeccionEstudioDTO> ObtenerSeccionEstudios()
        {
            return SeccionEstudioDAO.ObtenerSeccionEstudios();
        }

        public string AgregarSeccionEstudio(SeccionEstudioDTO SeccionEstudioDto)
        {
            return SeccionEstudioDAO.AgregarSeccionEstudio(SeccionEstudioDto);
        }

        public SeccionEstudioDTO BuscarSeccionEstudioID(int Codigo)
        {
            return SeccionEstudioDAO.BuscarSeccionEstudioID(Codigo);
        }

        public string ActualizarSeccionEstudio(SeccionEstudioDTO SeccionEstudioDto)
        {
            return SeccionEstudioDAO.ActualizarSeccionEstudio(SeccionEstudioDto);
        }

        public string EliminarSeccionEstudio(SeccionEstudioDTO SeccionEstudioDto)
        {
            return SeccionEstudioDAO.EliminarSeccionEstudio(SeccionEstudioDto);
        }

    }
}
