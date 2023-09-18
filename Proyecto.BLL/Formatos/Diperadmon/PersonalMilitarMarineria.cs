using Marina.Siesmar.AccesoDatos.Formatos.Diperadmon;
using Marina.Siesmar.Entidades.Formatos.Diperadmon;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diperadmon
{
    public class PersonalMilitarMarineria
    {
        PersonalMilitarMarineriaDAO personalMilitarMarineriaDAO = new();

        public List<PersonalMilitarMarineriaDTO> ObtenerLista(int? CargaId = null, int? mes = null, int? anio = null)
        {
            return personalMilitarMarineriaDAO.ObtenerLista(CargaId, mes, anio);
        }

        public string AgregarRegistro(PersonalMilitarMarineriaDTO personalMilitarMarineria, int mes, int anio)
        {
            return personalMilitarMarineriaDAO.AgregarRegistro(personalMilitarMarineria, mes, anio);
        }

        public PersonalMilitarMarineriaDTO BuscarFormato(int Codigo)
        {
            return personalMilitarMarineriaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PersonalMilitarMarineriaDTO personalMilitarMarineriaDTO)
        {
            return personalMilitarMarineriaDAO.ActualizaFormato(personalMilitarMarineriaDTO);
        }

        public bool EliminarFormato(PersonalMilitarMarineriaDTO personalMilitarMarineriaDTO)
        {
            return personalMilitarMarineriaDAO.EliminarFormato(personalMilitarMarineriaDTO);
        }

        public bool EliminarCarga(PersonalMilitarMarineriaDTO personalMilitarMarineriaDTO)
        {
            return personalMilitarMarineriaDAO.EliminarCarga(personalMilitarMarineriaDTO);
        }

        public string InsertarDatos(DataTable datos, int mes, int anio)
        {
            return personalMilitarMarineriaDAO.InsertarDatos(datos, mes, anio);
        }

    }
}
