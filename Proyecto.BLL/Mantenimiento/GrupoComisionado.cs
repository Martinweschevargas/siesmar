using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GrupoComisionado
    {
        readonly GrupoComisionadoDAO grupoComisionadoDAO = new();

        public List<GrupoComisionadoDTO> ObtenerGrupoComisionados()
        {
            return grupoComisionadoDAO.ObtenerGrupoComisionados();
        }

        public string AgregarGrupoComisionado(GrupoComisionadoDTO grupoComisionadoDto)
        {
            return grupoComisionadoDAO.AgregarGrupoComisionado(grupoComisionadoDto);
        }

        public GrupoComisionadoDTO BuscarGrupoComisionadoID(int Codigo)
        {
            return grupoComisionadoDAO.BuscarGrupoComisionadoID(Codigo);
        }

        public string ActualizarGrupoComisionado(GrupoComisionadoDTO grupoComisionadoDto)
        {
            return grupoComisionadoDAO.ActualizarGrupoComisionado(grupoComisionadoDto);
        }

        public string EliminarGrupoComisionado(GrupoComisionadoDTO grupoComisionadoDto)
        {
            return grupoComisionadoDAO.EliminarGrupoComisionado(grupoComisionadoDto);
        }

    }
}
