using Marina.Siesmar.AccesoDatos.Formatos.Diperadmon;
using Marina.Siesmar.Entidades.Formatos.Diperadmon;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diperadmon
{
    public class PersonalMilitarRetiroBaja
    {
        PersonalMilitarRetiroBajaDAO personalMilitarRetiroBajaDAO = new();

        public List<PersonalMilitarRetiroBajaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return personalMilitarRetiroBajaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(PersonalMilitarRetiroBajaDTO personalMilitarRetiroBaja, string? fecha)
        {
            return personalMilitarRetiroBajaDAO.AgregarRegistro(personalMilitarRetiroBaja, fecha);
        }

        public PersonalMilitarRetiroBajaDTO BuscarFormato(int Codigo)
        {
            return personalMilitarRetiroBajaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PersonalMilitarRetiroBajaDTO personalMilitarRetiroBajaDTO)
        {
            return personalMilitarRetiroBajaDAO.ActualizaFormato(personalMilitarRetiroBajaDTO);
        }

        public bool EliminarFormato(PersonalMilitarRetiroBajaDTO personalMilitarRetiroBajaDTO)
        {
            return personalMilitarRetiroBajaDAO.EliminarFormato(personalMilitarRetiroBajaDTO);
        }

        public bool EliminarCarga(PersonalMilitarRetiroBajaDTO personalMilitarRetiroBajaDTO)
        {
            return personalMilitarRetiroBajaDAO.EliminarCarga(personalMilitarRetiroBajaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return personalMilitarRetiroBajaDAO.InsertarDatos(datos, fecha);
        }

    }
}
