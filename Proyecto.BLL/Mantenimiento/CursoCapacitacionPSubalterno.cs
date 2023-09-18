using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CursoCapacitacionPSubalterno
    {
        readonly CursoCapacitacionPSubalternoDAO cursoCapacitacionPSubalternoDAO = new();

        public List<CursoCapacitacionPSubalternoDTO> ObtenerCursoCapacitacionPSubalternos()
        {
            return cursoCapacitacionPSubalternoDAO.ObtenerCursoCapacitacionPSubalternos();
        }

        public string AgregarCursoCapacitacionPSubalterno(CursoCapacitacionPSubalternoDTO cursoCapacitacionPSubalternoDto)
        {
            return cursoCapacitacionPSubalternoDAO.AgregarCursoCapacitacionPSubalterno(cursoCapacitacionPSubalternoDto);
        }

        public CursoCapacitacionPSubalternoDTO BuscarCursoCapacitacionPSubalternoID(int Codigo)
        {
            return cursoCapacitacionPSubalternoDAO.BuscarCursoCapacitacionPSubalternoID(Codigo);
        }

        public string ActualizarCursoCapacitacionPSubalterno(CursoCapacitacionPSubalternoDTO cursoCapacitacionPSubalternoDTO)
        {
            return cursoCapacitacionPSubalternoDAO.ActualizarCursoCapacitacionPSubalterno(cursoCapacitacionPSubalternoDTO);
        }

        public bool EliminarCursoCapacitacionPSubalterno(CursoCapacitacionPSubalternoDTO cursoCapacitacionPSubalternoDTO)
        {
            return cursoCapacitacionPSubalternoDAO.EliminarCursoCapacitacionPSubalterno(cursoCapacitacionPSubalternoDTO);
        }

    }
}
