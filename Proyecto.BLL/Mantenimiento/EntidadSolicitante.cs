using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EntidadSolicitante
    {
        readonly EntidadSolicitanteDAO entidadSolicitanteDAO = new();

        public List<EntidadSolicitanteDTO> ObtenerEntidadSolicitantes()
        {
            return entidadSolicitanteDAO.ObtenerEntidadSolicitantes();
        }

        public string AgregarEntidadSolicitante(EntidadSolicitanteDTO entidadSolicitanteDto)
        {
            return entidadSolicitanteDAO.AgregarEntidadSolicitante(entidadSolicitanteDto);
        }

        public EntidadSolicitanteDTO BuscarEntidadSolicitanteID(int Codigo)
        {
            return entidadSolicitanteDAO.BuscarEntidadSolicitanteID(Codigo);
        }

        public string ActualizarEntidadSolicitante(EntidadSolicitanteDTO entidadSolicitanteDto)
        {
            return entidadSolicitanteDAO.ActualizarEntidadSolicitante(entidadSolicitanteDto);
        }

        public string EliminarEntidadSolicitante(EntidadSolicitanteDTO entidadSolicitanteDto)
        {
            return entidadSolicitanteDAO.EliminarEntidadSolicitante(entidadSolicitanteDto);
        }

    }
}
