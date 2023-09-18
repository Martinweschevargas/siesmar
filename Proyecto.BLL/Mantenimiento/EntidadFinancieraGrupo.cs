using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EntidadFinancieraGrupo
    {
        readonly EntidadFinancieraGrupoDAO entidadFinancieraGrupoDAO = new();

        public List<EntidadFinancieraGrupoDTO> ObtenerEntidadFinancieraGrupos()
        {
            return entidadFinancieraGrupoDAO.ObtenerEntidadFinancieraGrupos();
        }

        public string AgregarEntidadFinancieraGrupo(EntidadFinancieraGrupoDTO entidadFinancieraGrupoDto)
        {
            return entidadFinancieraGrupoDAO.AgregarEntidadFinancieraGrupo(entidadFinancieraGrupoDto);
        }

        public EntidadFinancieraGrupoDTO BuscarEntidadFinancieraGrupoID(int Codigo)
        {
            return entidadFinancieraGrupoDAO.BuscarEntidadFinancieraGrupoID(Codigo);
        }

        public string ActualizarEntidadFinancieraGrupo(EntidadFinancieraGrupoDTO entidadFinancieraGrupoDTO)
        {
            return entidadFinancieraGrupoDAO.ActualizarEntidadFinancieraGrupo(entidadFinancieraGrupoDTO);
        }

        public bool EliminarEntidadFinancieraGrupo(EntidadFinancieraGrupoDTO entidadFinancieraGrupoDTO)
        {
            return entidadFinancieraGrupoDAO.EliminarEntidadFinancieraGrupo(entidadFinancieraGrupoDTO);
        }

    }
}
