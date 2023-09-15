using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MotivoTerminoCurso
    {
        readonly MotivoTerminoCursoDAO motivoTerminoCursoDAO = new();

        public List<MotivoTerminoCursoDTO> ObtenerMotivoTerminoCursos()
        {
            return motivoTerminoCursoDAO.ObtenerMotivoTerminoCursos();
        }

        public string AgregarMotivoTerminoCurso(MotivoTerminoCursoDTO motivoTerminoCursoDto)
        {
            return motivoTerminoCursoDAO.AgregarMotivoTerminoCurso(motivoTerminoCursoDto);
        }

        public MotivoTerminoCursoDTO BuscarMotivoTerminoCursoID(int Codigo)
        {
            return motivoTerminoCursoDAO.BuscarMotivoTerminoCursoID(Codigo);
        }

        public string ActualizarMotivoTerminoCurso(MotivoTerminoCursoDTO motivoTerminoCursoDTO)
        {
            return motivoTerminoCursoDAO.ActualizarMotivoTerminoCurso(motivoTerminoCursoDTO);
        }

        public string EliminarMotivoTerminoCurso(MotivoTerminoCursoDTO motivoTerminoCursoDTO)
        {
            return motivoTerminoCursoDAO.EliminarMotivoTerminoCurso(motivoTerminoCursoDTO);
        }

    }
}
