using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class PerfilProfesionalSistema
    {
        PerfilProfesionalSistemaDAO perfilProfesionalSistemaDAO = new();

        public List<PerfilProfesionalSistemaDTO> ObtenerLista(int? CargaId = null)
        {
            return perfilProfesionalSistemaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(PerfilProfesionalSistemaDTO perfilProfesionalSistema)
        {
            return perfilProfesionalSistemaDAO.AgregarRegistro(perfilProfesionalSistema);
        }

        public PerfilProfesionalSistemaDTO BuscarFormato(int Codigo)
        {
            return perfilProfesionalSistemaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PerfilProfesionalSistemaDTO perfilProfesionalSistemaDTO)
        {
            return perfilProfesionalSistemaDAO.ActualizaFormato(perfilProfesionalSistemaDTO);
        }

        public bool EliminarFormato(PerfilProfesionalSistemaDTO perfilProfesionalSistemaDTO)
        {
            return perfilProfesionalSistemaDAO.EliminarFormato(perfilProfesionalSistemaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return perfilProfesionalSistemaDAO.InsertarDatos(datos);
        }

    }
}