using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GrupoTarea
    {
        readonly GrupoTareaDAO grupoTareaDAO = new();

        public List<GrupoTareaDTO> ObtenerGrupoTareas()
        {
            return grupoTareaDAO.ObtenerGrupoTareas();
        }

        public string AgregarGrupoTarea(GrupoTareaDTO grupoTareaDto)
        {
            return grupoTareaDAO.AgregarGrupoTarea(grupoTareaDto);
        }

        public GrupoTareaDTO BuscarGrupoTareaID(int Codigo)
        {
            return grupoTareaDAO.BuscarGrupoTareaID(Codigo);
        }

        public string ActualizarGrupoTarea(GrupoTareaDTO grupoTareaDTO)
        {
            return grupoTareaDAO.ActualizarGrupoTarea(grupoTareaDTO);
        }

        public bool EliminarGrupoTarea(int Codigo)
        {
            return grupoTareaDAO.EliminarGrupoTarea(Codigo);
        }

    }
}
