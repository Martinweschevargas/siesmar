using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SubUnidadEjecutora
    {
        readonly SubUnidadEjecutoraDAO subUnidadEjecutoraDAO = new();

        public List<SubUnidadEjecutoraDTO> ObtenerSubUnidadEjecutoras()
        {
            return subUnidadEjecutoraDAO.ObtenerSubUnidadEjecutoras();
        }

        public string AgregarSubUnidadEjecutora(SubUnidadEjecutoraDTO subUnidadEjecutoraDto)
        {
            return subUnidadEjecutoraDAO.AgregarSubUnidadEjecutora(subUnidadEjecutoraDto);
        }

        public SubUnidadEjecutoraDTO BuscarSubUnidadEjecutoraID(int Codigo)
        {
            return subUnidadEjecutoraDAO.BuscarSubUnidadEjecutoraID(Codigo);
        }

        public string ActualizarSubUnidadEjecutora(SubUnidadEjecutoraDTO subUnidadEjecutoraDTO)
        {
            return subUnidadEjecutoraDAO.ActualizarSubUnidadEjecutora(subUnidadEjecutoraDTO);
        }

        public string EliminarSubUnidadEjecutora(SubUnidadEjecutoraDTO subUnidadEjecutoraDTO)
        {
            return subUnidadEjecutoraDAO.EliminarSubUnidadEjecutora(subUnidadEjecutoraDTO);
        }

    }
}
