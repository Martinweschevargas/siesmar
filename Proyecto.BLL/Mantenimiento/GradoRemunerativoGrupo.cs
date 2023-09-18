using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GradoRemunerativoGrupo
    {
        readonly GradoRemunerativoGrupoDAO gradoRemunerativoGrupoDAO = new();

        public List<GradoRemunerativoGrupoDTO> ObtenerGradoRemunerativoGrupos()
        {
            return gradoRemunerativoGrupoDAO.ObtenerGradoRemunerativoGrupos();
        }

        public string AgregarGradoRemunerativoGrupo(GradoRemunerativoGrupoDTO gradoRemunerativoGrupoDto)
        {
            return gradoRemunerativoGrupoDAO.AgregarGradoRemunerativoGrupo(gradoRemunerativoGrupoDto);
        }

        public GradoRemunerativoGrupoDTO BuscarGradoRemunerativoGrupoID(int Codigo)
        {
            return gradoRemunerativoGrupoDAO.BuscarGradoRemunerativoGrupoID(Codigo);
        }

        public string ActualizarGradoRemunerativoGrupo(GradoRemunerativoGrupoDTO gradoRemunerativoGrupoDTO)
        {
            return gradoRemunerativoGrupoDAO.ActualizarGradoRemunerativoGrupo(gradoRemunerativoGrupoDTO);
        }

        public string EliminarGradoRemunerativoGrupo(GradoRemunerativoGrupoDTO gradoRemunerativoGrupoDTO)
        {
            return gradoRemunerativoGrupoDAO.EliminarGradoRemunerativoGrupo(gradoRemunerativoGrupoDTO);
        }

    }
}
