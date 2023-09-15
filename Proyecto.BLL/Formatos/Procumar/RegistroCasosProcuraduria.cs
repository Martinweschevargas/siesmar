using Marina.Siesmar.AccesoDatos.Formatos.Procumar;
using Marina.Siesmar.Entidades.Formatos.Procumar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Procumar
{
    public class RegistroCasosProcuraduria
    {
        RegistroCasosProcuraduriaDAO registroCasosProcuraduriaDAO = new();

        public List<RegistroCasosProcuraduriaDTO> ObtenerLista(int? CargaId = null)
        {
            return registroCasosProcuraduriaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(RegistroCasosProcuraduriaDTO registroCasosProcuraduria)
        {
            return registroCasosProcuraduriaDAO.AgregarRegistro(registroCasosProcuraduria);
        }

        public RegistroCasosProcuraduriaDTO BuscarFormato(int Codigo)
        {
            return registroCasosProcuraduriaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroCasosProcuraduriaDTO registroCasosProcuraduriaDTO)
        {
            return registroCasosProcuraduriaDAO.ActualizaFormato(registroCasosProcuraduriaDTO);
        }

        public bool EliminarFormato(RegistroCasosProcuraduriaDTO registroCasosProcuraduriaDTO)
        {
            return registroCasosProcuraduriaDAO.EliminarFormato(registroCasosProcuraduriaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroCasosProcuraduriaDAO.InsertarDatos(datos);
        }

    }
}
