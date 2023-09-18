using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ProgramaCapacitacionPSubalterno
    {
        readonly ProgramaCapacitacionPSubalternoDAO programaCapacitacionPSubalternoDAO = new();

        public List<ProgramaCapacitacionPSubalternoDTO> ObtenerProgramaCapacitacionPSubalternos()
        {
            return programaCapacitacionPSubalternoDAO.ObtenerProgramaCapacitacionPSubalternos();
        }

        public string AgregarProgramaCapacitacionPSubalterno(ProgramaCapacitacionPSubalternoDTO programaCapacitacionPSubalternoDto)
        {
            return programaCapacitacionPSubalternoDAO.AgregarProgramaCapacitacionPSubalterno(programaCapacitacionPSubalternoDto);
        }

        public ProgramaCapacitacionPSubalternoDTO BuscarProgramaCapacitacionPSubalternoID(int Codigo)
        {
            return programaCapacitacionPSubalternoDAO.BuscarProgramaCapacitacionPSubalternoID(Codigo);
        }

        public string ActualizarProgramaCapacitacionPSubalterno(ProgramaCapacitacionPSubalternoDTO programaCapacitacionPSubalternoDTO)
        {
            return programaCapacitacionPSubalternoDAO.ActualizarProgramaCapacitacionPSubalterno(programaCapacitacionPSubalternoDTO);
        }

        public bool EliminarProgramaCapacitacionPSubalterno(ProgramaCapacitacionPSubalternoDTO programaCapacitacionPSubalternoDTO)
        {
            return programaCapacitacionPSubalternoDAO.EliminarProgramaCapacitacionPSubalterno(programaCapacitacionPSubalternoDTO);
        }

    }
}
