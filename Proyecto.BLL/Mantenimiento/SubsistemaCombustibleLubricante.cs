using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SubsistemaCombustibleLubricante
    {
        readonly SubsistemaCombustibleLubricanteDAO subsistemaCombustibleLubricanteDAO = new();

        public List<SubsistemaCombustibleLubricanteDTO> ObtenerSubsistemaCombustibleLubricantes()
        {
            return subsistemaCombustibleLubricanteDAO.ObtenerSubsistemaCombustibleLubricantes();
        }

        public string AgregarSubsistemaCombustibleLubricante(SubsistemaCombustibleLubricanteDTO subsistemaCombustibleLubricanteDto)
        {
            return subsistemaCombustibleLubricanteDAO.AgregarSubsistemaCombustibleLubricante(subsistemaCombustibleLubricanteDto);
        }

        public SubsistemaCombustibleLubricanteDTO BuscarSubsistemaCombustibleLubricanteID(int Codigo)
        {
            return subsistemaCombustibleLubricanteDAO.BuscarSubsistemaCombustibleLubricanteID(Codigo);
        }

        public string ActualizarSubsistemaCombustibleLubricante(SubsistemaCombustibleLubricanteDTO subsistemaCombustibleLubricanteDto)
        {
            return subsistemaCombustibleLubricanteDAO.ActualizarSubsistemaCombustibleLubricante(subsistemaCombustibleLubricanteDto);
        }

        public string EliminarSubsistemaCombustibleLubricante(SubsistemaCombustibleLubricanteDTO subsistemaCombustibleLubricanteDto)
        {
            return subsistemaCombustibleLubricanteDAO.EliminarSubsistemaCombustibleLubricante(subsistemaCombustibleLubricanteDto);
        }

    }
}
