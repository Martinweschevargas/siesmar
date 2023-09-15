using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CondicionSolicitante
    {
        readonly CondicionSolicitanteDAO condicionSolicitanteDAO = new();

        public List<CondicionSolicitanteDTO> ObtenerCondicionSolicitantes()
        {
            return condicionSolicitanteDAO.ObtenerCondicionSolicitantes();
        }

        public string AgregarCondicionSolicitante(CondicionSolicitanteDTO condicionSolicitanteDto)
        {
            return condicionSolicitanteDAO.AgregarCondicionSolicitante(condicionSolicitanteDto);
        }

        public CondicionSolicitanteDTO BuscarCondicionSolicitanteID(int Codigo)
        {
            return condicionSolicitanteDAO.BuscarCondicionSolicitanteID(Codigo);
        }

        public string ActualizarCondicionSolicitante(CondicionSolicitanteDTO condicionSolicitanteDto)
        {
            return condicionSolicitanteDAO.ActualizarCondicionSolicitante(condicionSolicitanteDto);
        }

        public string EliminarCondicionSolicitante(CondicionSolicitanteDTO condicionSolicitanteDto)
        {
            return condicionSolicitanteDAO.EliminarCondicionSolicitante(condicionSolicitanteDto);
        }

    }
}
