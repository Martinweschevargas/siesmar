using Marina.Siesmar.AccesoDatos.Formatos.Iafas;
using Marina.Siesmar.Entidades.Formatos.Iafas;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Iafas
{
    public class PersonalAfiliadoProgramaSalud
    {
        PersonalAfiliadoProgramaSaludDAO personalAfiliadoProgramaSaludDAO = new();

        public List<PersonalAfiliadoProgramaSaludDTO> ObtenerLista(int? CargaId = null)
        {
            return personalAfiliadoProgramaSaludDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(PersonalAfiliadoProgramaSaludDTO personalAfiliadoProgramaSalud)
        {
            return personalAfiliadoProgramaSaludDAO.AgregarRegistro(personalAfiliadoProgramaSalud);
        }

        public PersonalAfiliadoProgramaSaludDTO BuscarFormato(int Codigo)
        {
            return personalAfiliadoProgramaSaludDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PersonalAfiliadoProgramaSaludDTO personalAfiliadoProgramaSaludDTO)
        {
            return personalAfiliadoProgramaSaludDAO.ActualizaFormato(personalAfiliadoProgramaSaludDTO);
        }

        public bool EliminarFormato(PersonalAfiliadoProgramaSaludDTO personalAfiliadoProgramaSaludDTO)
        {
            return personalAfiliadoProgramaSaludDAO.EliminarFormato( personalAfiliadoProgramaSaludDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return personalAfiliadoProgramaSaludDAO.InsertarDatos(datos);
        }



    }
}
