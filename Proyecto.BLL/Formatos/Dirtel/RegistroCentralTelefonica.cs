using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class RegistroCentralTelefonica
    {
        RegistroCentralTelefonicaDAO registroCentralTelefonicaDAO = new();

        public List<RegistroCentralTelefonicaDTO> ObtenerLista()
        {
            return registroCentralTelefonicaDAO.ObtenerLista();
        }

        public string AgregarRegistro(RegistroCentralTelefonicaDTO registroCentralTelefonica)
        {
            return registroCentralTelefonicaDAO.AgregarRegistro(registroCentralTelefonica);
        }

        public RegistroCentralTelefonicaDTO BuscarFormato(int Codigo)
        {
            return registroCentralTelefonicaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroCentralTelefonicaDTO registroCentralTelefonicaDTO)
        {
            return registroCentralTelefonicaDAO.ActualizaFormato(registroCentralTelefonicaDTO);
        }

        public bool EliminarFormato(RegistroCentralTelefonicaDTO registroCentralTelefonicaDTO)
        {
            return registroCentralTelefonicaDAO.EliminarFormato( registroCentralTelefonicaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroCentralTelefonicaDAO.InsertarDatos(datos);
        }


    }
}
