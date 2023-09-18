using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SancionDisciplinariaCivil
    {
        readonly SancionDisciplinariaCivilDAO sancionDisciplinariaCivilDAO = new();

        public List<SancionDisciplinariaCivilDTO> ObtenerSancionDisciplinariaCivils()
        {
            return sancionDisciplinariaCivilDAO.ObtenerSancionDisciplinariaCivils();
        }

        public string AgregarSancionDisciplinariaCivil(SancionDisciplinariaCivilDTO sancionDisciplinariaCivilDto)
        {
            return sancionDisciplinariaCivilDAO.AgregarSancionDisciplinariaCivil(sancionDisciplinariaCivilDto);
        }

        public SancionDisciplinariaCivilDTO BuscarSancionDisciplinariaCivilID(int Codigo)
        {
            return sancionDisciplinariaCivilDAO.BuscarSancionDisciplinariaCivilID(Codigo);
        }

        public string ActualizarSancionDisciplinariaCivil(SancionDisciplinariaCivilDTO sancionDisciplinariaCivilDTO)
        {
            return sancionDisciplinariaCivilDAO.ActualizarSancionDisciplinariaCivil(sancionDisciplinariaCivilDTO);
        }

        public bool EliminarSancionDisciplinariaCivil(SancionDisciplinariaCivilDTO sancionDisciplinariaCivilDTO)
        {
            return sancionDisciplinariaCivilDAO.EliminarSancionDisciplinariaCivil(sancionDisciplinariaCivilDTO);
        }

    }
}
