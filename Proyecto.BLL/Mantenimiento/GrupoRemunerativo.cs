using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GrupoRemunerativo
    {
        readonly GrupoRemunerativoDAO grupoRemunerativoDAO = new();

        public List<GrupoRemunerativoDTO> ObtenerGrupoRemunerativos()
        {
            return grupoRemunerativoDAO.ObtenerGrupoRemunerativos();
        }

        public string AgregarGrupoRemunerativo(GrupoRemunerativoDTO grupoRemunerativoDto)
        {
            return grupoRemunerativoDAO.AgregarGrupoRemunerativo(grupoRemunerativoDto);
        }

        public GrupoRemunerativoDTO BuscarGrupoRemunerativoID(int Codigo)
        {
            return grupoRemunerativoDAO.BuscarGrupoRemunerativoID(Codigo);
        }

        public string ActualizarGrupoRemunerativo(GrupoRemunerativoDTO grupoRemunerativoDTO)
        {
            return grupoRemunerativoDAO.ActualizarGrupoRemunerativo(grupoRemunerativoDTO);
        }

        public string EliminarGrupoRemunerativo(GrupoRemunerativoDTO grupoRemunerativoDTO)
        {
            return grupoRemunerativoDAO.EliminarGrupoRemunerativo(grupoRemunerativoDTO);
        }

    }
}
