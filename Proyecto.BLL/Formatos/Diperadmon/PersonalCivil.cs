using Marina.Siesmar.AccesoDatos.Formatos.Diperadmon;
using Marina.Siesmar.Entidades.Formatos.Diperadmon;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diperadmon
{
    public class PersonalCivil
    {
        PersonalCivilDAO personalCivilDAO = new();

        public List<PersonalCivilDTO> ObtenerLista(int? CargaId = null, string? fechacarga=null)
        {
            return personalCivilDAO.ObtenerLista(CargaId, fechacarga);
        }

        public string AgregarRegistro(PersonalCivilDTO personalCivil, string fechacara)
        {
            return personalCivilDAO.AgregarRegistro(personalCivil, fechacara);
        }

        public PersonalCivilDTO EditarFormado(int Codigo)
        {
            return personalCivilDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PersonalCivilDTO personalCivilDTO)
        {
            return personalCivilDAO.ActualizaFormato(personalCivilDTO);
        }

        public bool EliminarFormato(PersonalCivilDTO personalCivilDTO)
        {
            return personalCivilDAO.EliminarFormato(personalCivilDTO);
        }

        public bool EliminarCarga(PersonalCivilDTO personalCivilDTO)
        {
            return personalCivilDAO.EliminarCarga(personalCivilDTO);
        }

        public string InsertarDatos(DataTable datos, string fechacarga)
        {
            return personalCivilDAO.InsertarDatos(datos, fechacarga);
        }

    }
}
