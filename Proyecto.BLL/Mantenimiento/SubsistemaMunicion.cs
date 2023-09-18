using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SubsistemaMunicion
    {
        readonly SubsistemaMunicionDAO subsistemaMunicionDAO = new();

        public List<SubsistemaMunicionDTO> ObtenerSubsistemaMunicions()
        {
            return subsistemaMunicionDAO.ObtenerSubsistemaMunicions();
        }

        public string AgregarSubsistemaMunicion(SubsistemaMunicionDTO subsistemaMunicionDto)
        {
            return subsistemaMunicionDAO.AgregarSubsistemaMunicion(subsistemaMunicionDto);
        }

        public SubsistemaMunicionDTO BuscarSubsistemaMunicionID(int Codigo)
        {
            return subsistemaMunicionDAO.BuscarSubsistemaMunicionID(Codigo);
        }

        public string ActualizarSubsistemaMunicion(SubsistemaMunicionDTO subsistemaMunicionDto)
        {
            return subsistemaMunicionDAO.ActualizarSubsistemaMunicion(subsistemaMunicionDto);
        }

        public string EliminarSubsistemaMunicion(SubsistemaMunicionDTO subsistemaMunicionDto)
        {
            return subsistemaMunicionDAO.EliminarSubsistemaMunicion(subsistemaMunicionDto);
        }

    }
}
