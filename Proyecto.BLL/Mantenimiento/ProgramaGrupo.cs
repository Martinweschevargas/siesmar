using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ProgramaGrupo
    {
        readonly ProgramaGrupoDAO programaGrupoDAO = new();

        public List<ProgramaGrupoDTO> ObtenerProgramaGrupos()
        {
            return programaGrupoDAO.ObtenerProgramaGrupos();
        }

        public string AgregarProgramaGrupo(ProgramaGrupoDTO programaGrupoDto)
        {
            return programaGrupoDAO.AgregarProgramaGrupo(programaGrupoDto);
        }

        public ProgramaGrupoDTO BuscarProgramaGrupoID(int Codigo)
        {
            return programaGrupoDAO.BuscarProgramaGrupoID(Codigo);
        }

        public string ActualizarProgramaGrupo(ProgramaGrupoDTO programaGrupoDTO)
        {
            return programaGrupoDAO.ActualizarProgramaGrupo(programaGrupoDTO);
        }

        public bool EliminarProgramaGrupo(ProgramaGrupoDTO programaGrupoDTO)
        {
            return programaGrupoDAO.EliminarProgramaGrupo(programaGrupoDTO);
        }

    }
}
