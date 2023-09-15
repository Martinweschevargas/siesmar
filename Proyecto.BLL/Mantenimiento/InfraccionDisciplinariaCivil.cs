using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class InfraccionDisciplinariaCivil
    {
        readonly InfraccionDisciplinariaCivilDAO infraccionDisciplinariaCivilDAO = new();

        public List<InfraccionDisciplinariaCivilDTO> ObtenerInfraccionDisciplinariaCivils()
        {
            return infraccionDisciplinariaCivilDAO.ObtenerInfraccionDisciplinariaCivils();
        }

        public string AgregarInfraccionDisciplinariaCivil(InfraccionDisciplinariaCivilDTO infraccionDisciplinariaCivilDto)
        {
            return infraccionDisciplinariaCivilDAO.AgregarInfraccionDisciplinariaCivil(infraccionDisciplinariaCivilDto);
        }

        public InfraccionDisciplinariaCivilDTO BuscarInfraccionDisciplinariaCivilID(int Codigo)
        {
            return infraccionDisciplinariaCivilDAO.BuscarInfraccionDisciplinariaCivilID(Codigo);
        }

        public string ActualizarInfraccionDisciplinariaCivil(InfraccionDisciplinariaCivilDTO infraccionDisciplinariaCivilDTO)
        {
            return infraccionDisciplinariaCivilDAO.ActualizarInfraccionDisciplinariaCivil(infraccionDisciplinariaCivilDTO);
        }

        public bool EliminarInfraccionDisciplinariaCivil(InfraccionDisciplinariaCivilDTO infraccionDisciplinariaCivilDTO)
        {
            return infraccionDisciplinariaCivilDAO.EliminarInfraccionDisciplinariaCivil(infraccionDisciplinariaCivilDTO);
        }

    }
}
