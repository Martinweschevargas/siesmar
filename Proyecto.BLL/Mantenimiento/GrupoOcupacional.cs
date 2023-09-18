using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GrupoOcupacional
    {
        readonly GrupoOcupacionalDAO grupoOcupacionalDAO = new();

        public List<GrupoOcupacionalDTO> ObtenerGrupoOcupacionals()
        {
            return grupoOcupacionalDAO.ObtenerGrupoOcupacionals();
        }

        public string AgregarGrupoOcupacional(GrupoOcupacionalDTO grupoOcupacionalDto)
        {
            return grupoOcupacionalDAO.AgregarGrupoOcupacional(grupoOcupacionalDto);
        }

        public GrupoOcupacionalDTO BuscarGrupoOcupacionalID(int Codigo)
        {
            return grupoOcupacionalDAO.BuscarGrupoOcupacionalID(Codigo);
        }

        public string ActualizarGrupoOcupacional(GrupoOcupacionalDTO grupoOcupacionalDTO)
        {
            return grupoOcupacionalDAO.ActualizarGrupoOcupacional(grupoOcupacionalDTO);
        }

        public bool EliminarGrupoOcupacional(GrupoOcupacionalDTO grupoOcupacionalDTO)
        {
            return grupoOcupacionalDAO.EliminarGrupoOcupacional(grupoOcupacionalDTO);
        }

    }
}
