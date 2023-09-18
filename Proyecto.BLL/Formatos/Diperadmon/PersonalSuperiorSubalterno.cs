using Marina.Siesmar.AccesoDatos.Formatos.Diperadmon;
using Marina.Siesmar.Entidades.Formatos.Diperadmon;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diperadmon
{
    public class PersonalSuperiorSubalterno
    {
        PersonalSuperiorSubalternoDAO personalSuperiorSubalternoDAO = new();

        public List<PersonalSuperiorSubalternoDTO> ObtenerLista(int? CargaId = null)
        {
            return personalSuperiorSubalternoDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(PersonalSuperiorSubalternoDTO personalSuperiorSubalterno)
        {
            return personalSuperiorSubalternoDAO.AgregarRegistro(personalSuperiorSubalterno);
        }

        public PersonalSuperiorSubalternoDTO EditarFormato(int Codigo)
        {
            return personalSuperiorSubalternoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PersonalSuperiorSubalternoDTO personalSuperiorSubalternoDTO)
        {
            return personalSuperiorSubalternoDAO.ActualizaFormato(personalSuperiorSubalternoDTO);
        }

        public bool EliminarFormato(PersonalSuperiorSubalternoDTO personalSuperiorSubDTO)
        {
            return personalSuperiorSubalternoDAO.EliminarFormato(personalSuperiorSubDTO);
        }

        public bool InsertarRegistros(IEnumerable<PersonalSuperiorSubalternoDTO> personalSuperiorSubalternoDTO)
        {
            return InsertarRegistros(personalSuperiorSubalternoDTO);
        }

    }
}
