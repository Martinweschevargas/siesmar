using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PersonalBeneficiado
    {
        readonly PersonalBeneficiadoDAO PersonalBeneficiadoDAO = new();

        public List<PersonalBeneficiadoDTO> ObtenerPersonalBeneficiados()
        {
            return PersonalBeneficiadoDAO.ObtenerPersonalBeneficiados();
        }

        public string AgregarPersonalBeneficiado(PersonalBeneficiadoDTO personalBeneficiadoDto)
        {
            return PersonalBeneficiadoDAO.AgregarPersonalBeneficiado(personalBeneficiadoDto);
        }

        public PersonalBeneficiadoDTO BuscarPersonalBeneficiadoID(int Codigo)
        {
            return PersonalBeneficiadoDAO.BuscarPersonalBeneficiadoID(Codigo);
        }

        public string ActualizarPersonalBeneficiado(PersonalBeneficiadoDTO personalBeneficiadoDto)
        {
            return PersonalBeneficiadoDAO.ActualizarPersonalBeneficiado(personalBeneficiadoDto);
        }

        public string EliminarPersonalBeneficiado(PersonalBeneficiadoDTO personalBeneficiadoDto)
        {
            return PersonalBeneficiadoDAO.EliminarPersonalBeneficiado(personalBeneficiadoDto);
        }

    }
}
