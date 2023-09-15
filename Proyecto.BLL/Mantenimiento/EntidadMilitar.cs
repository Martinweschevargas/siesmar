using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EntidadMilitar
    {
        readonly EntidadMilitarDAO entidadMilitarDAO = new();

        public List<EntidadMilitarDTO> ObtenerEntidadMilitars()
        {
            return entidadMilitarDAO.ObtenerEntidadMilitars();
        }

        public string AgregarEntidadMilitar(EntidadMilitarDTO entidadMilitarDto)
        {
            return entidadMilitarDAO.AgregarEntidadMilitar(entidadMilitarDto);
        }

        public EntidadMilitarDTO BuscarEntidadMilitarID(int Codigo)
        {
            return entidadMilitarDAO.BuscarEntidadMilitarID(Codigo);
        }

        public string ActualizarEntidadMilitar(EntidadMilitarDTO entidadMilitarDTO)
        {
            return entidadMilitarDAO.ActualizarEntidadMilitar(entidadMilitarDTO);
        }

        public string EliminarEntidadMilitar(EntidadMilitarDTO entidadMilitarDTO)
        {
            return entidadMilitarDAO.EliminarEntidadMilitar(entidadMilitarDTO);
        }

    }
}