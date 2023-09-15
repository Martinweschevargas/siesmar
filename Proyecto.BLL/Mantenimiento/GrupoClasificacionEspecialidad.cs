using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GrupoClasificacionEspecialidad
    {
        readonly GrupoClasificacionEspecialidadDAO grupoClasificacionEspecialidadDAO = new();

        public List<GrupoClasificacionEspecialidadDTO> ObtenerGrupoClasificacionEspecialidads()
        {
            return grupoClasificacionEspecialidadDAO.ObtenerGrupoClasificacionEspecialidads();
        }

        public string AgregarGrupoClasificacionEspecialidad(GrupoClasificacionEspecialidadDTO grupoClasificacionEspecialidadDto)
        {
            return grupoClasificacionEspecialidadDAO.AgregarGrupoClasificacionEspecialidad(grupoClasificacionEspecialidadDto);
        }

        public GrupoClasificacionEspecialidadDTO BuscarGrupoClasificacionEspecialidadID(int Codigo)
        {
            return grupoClasificacionEspecialidadDAO.BuscarGrupoClasificacionEspecialidadID(Codigo);
        }

        public string ActualizarGrupoClasificacionEspecialidad(GrupoClasificacionEspecialidadDTO grupoClasificacionEspecialidadDTO)
        {
            return grupoClasificacionEspecialidadDAO.ActualizarGrupoClasificacionEspecialidad(grupoClasificacionEspecialidadDTO);
        }

        public bool EliminarGrupoClasificacionEspecialidad(GrupoClasificacionEspecialidadDTO grupoClasificacionEspecialidadDTO)
        {
            return grupoClasificacionEspecialidadDAO.EliminarGrupoClasificacionEspecialidad(grupoClasificacionEspecialidadDTO);
        }

    }
}
