using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GrupoOcupacionalCivil
    {
        readonly GrupoOcupacionalCivilDAO grupoOcupacionalCivilDAO = new();

        public List<GrupoOcupacionalCivilDTO> ObtenerGrupoOcupacionalCivils()
        {
            return grupoOcupacionalCivilDAO.ObtenerGrupoOcupacionalCivils();
        }

        public string AgregarGrupoOcupacionalCivil(GrupoOcupacionalCivilDTO grupoOcupacionalCivilDto)
        {
            return grupoOcupacionalCivilDAO.AgregarGrupoOcupacionalCivil(grupoOcupacionalCivilDto);
        }

        public GrupoOcupacionalCivilDTO BuscarGrupoOcupacionalCivilID(int Codigo)
        {
            return grupoOcupacionalCivilDAO.BuscarGrupoOcupacionalCivilID(Codigo);
        }

        public string ActualizarGrupoOcupacionalCivil(GrupoOcupacionalCivilDTO grupoOcupacionalCivilDTO)
        {
            return grupoOcupacionalCivilDAO.ActualizarGrupoOcupacionalCivil(grupoOcupacionalCivilDTO);
        }

        public string EliminarGrupoOcupacionalCivil(GrupoOcupacionalCivilDTO grupoOcupacionalCivilDTO)
        {
            return grupoOcupacionalCivilDAO.EliminarGrupoOcupacionalCivil(grupoOcupacionalCivilDTO);
        }

    }
}
