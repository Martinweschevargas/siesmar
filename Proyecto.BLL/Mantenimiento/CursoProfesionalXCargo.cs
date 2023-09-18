using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CursoProfesionalXCargo
    {
        readonly CursoProfesionalXCargoDAO cursoProfesionalXCargoDAO = new();

        public List<CursoProfesionalXCargoDTO> ObtenerCursoProfesionalXCargos()
        {
            return cursoProfesionalXCargoDAO.ObtenerCursoProfesionalXCargos();
        }

        public string AgregarCursoProfesionalXCargo(CursoProfesionalXCargoDTO cursoProfesionalXCargoDto)
        {
            return cursoProfesionalXCargoDAO.AgregarCursoProfesionalXCargo(cursoProfesionalXCargoDto);
        }

        public CursoProfesionalXCargoDTO BuscarCursoProfesionalXCargoID(int Codigo)
        {
            return cursoProfesionalXCargoDAO.BuscarCursoProfesionalXCargoID(Codigo);
        }

        public string ActualizarCursoProfesionalXCargo(CursoProfesionalXCargoDTO cursoProfesionalXCargoDto)
        {
            return cursoProfesionalXCargoDAO.ActualizarCursoProfesionalXCargo(cursoProfesionalXCargoDto);
        }

        public string EliminarCursoProfesionalXCargo(CursoProfesionalXCargoDTO cursoProfesionalXCargoDto)
        {
            return cursoProfesionalXCargoDAO.EliminarCursoProfesionalXCargo(cursoProfesionalXCargoDto);
        }

    }
}
