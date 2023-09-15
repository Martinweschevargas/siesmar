using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ProgramaEspecializacionEspecifico
    {
        readonly ProgramaEspecializacionEspecificoDAO programaEspecializacionEspecificoDAO = new();

        public List<ProgramaEspecializacionEspecificoDTO> ObtenerProgramaEspecializacionEspecificos()
        {
            return programaEspecializacionEspecificoDAO.ObtenerProgramaEspecializacionEspecificos();
        }

        public string AgregarProgramaEspecializacionEspecifico(ProgramaEspecializacionEspecificoDTO programaEspecializacionEspecificoDto)
        {
            return programaEspecializacionEspecificoDAO.AgregarProgramaEspecializacionEspecifico(programaEspecializacionEspecificoDto);
        }

        public ProgramaEspecializacionEspecificoDTO BuscarProgramaEspecializacionEspecificoID(int Codigo)
        {
            return programaEspecializacionEspecificoDAO.BuscarProgramaEspecializacionEspecificoID(Codigo);
        }

        public string ActualizarProgramaEspecializacionEspecifico(ProgramaEspecializacionEspecificoDTO programaEspecializacionEspecificoDto)
        {
            return programaEspecializacionEspecificoDAO.ActualizarProgramaEspecializacionEspecifico(programaEspecializacionEspecificoDto);
        }

        public string EliminarProgramaEspecializacionEspecifico(ProgramaEspecializacionEspecificoDTO programaEspecializacionEspecificoDto)
        {
            return programaEspecializacionEspecificoDAO.EliminarProgramaEspecializacionEspecifico(programaEspecializacionEspecificoDto);
        }

    }
}
