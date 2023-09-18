using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ProgramaEspecializacionGrupo
    {
        readonly ProgramaEspecializacionGrupoDAO programaEspecializacionGrupoDAO = new();

        public List<ProgramaEspecializacionGrupoDTO> ObtenerProgramaEspecializacionGrupos()
        {
            return programaEspecializacionGrupoDAO.ObtenerProgramaEspecializacionGrupos();
        }

        public string AgregarProgramaEspecializacionGrupo(ProgramaEspecializacionGrupoDTO programaEspecializacionGrupoDto)
        {
            return programaEspecializacionGrupoDAO.AgregarProgramaEspecializacionGrupo(programaEspecializacionGrupoDto);
        }

        public ProgramaEspecializacionGrupoDTO BuscarProgramaEspecializacionGrupoID(int Codigo)
        {
            return programaEspecializacionGrupoDAO.BuscarProgramaEspecializacionGrupoID(Codigo);
        }

        public string ActualizarProgramaEspecializacionGrupo(ProgramaEspecializacionGrupoDTO programaEspecializacionGrupoDto)
        {
            return programaEspecializacionGrupoDAO.ActualizarProgramaEspecializacionGrupo(programaEspecializacionGrupoDto);
        }

        public string EliminarProgramaEspecializacionGrupo(ProgramaEspecializacionGrupoDTO programaEspecializacionGrupoDto)
        {
            return programaEspecializacionGrupoDAO.EliminarProgramaEspecializacionGrupo(programaEspecializacionGrupoDto);
        }

    }
}
