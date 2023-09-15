
using Marina.Siesmar.AccesoDatos.Formatos.Comesguard;
using Marina.Siesmar.Entidades.Formatos.Comesguard;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comesguard
{
    public class IngresoDatoServicioApoyoMovilidad
    {
        IngresoDatoServicioApoyoMovilidadDAO ingresoDatoServicioApoyoMovilidadDAO = new();

        public List<IngresoDatoServicioApoyoMovilidadDTO> ObtenerLista(int? CargaId = null)
        {
            return ingresoDatoServicioApoyoMovilidadDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(IngresoDatoServicioApoyoMovilidadDTO ingresoDatoServicioApoyoMovilidadDTO)
        {
            return ingresoDatoServicioApoyoMovilidadDAO.AgregarRegistro(ingresoDatoServicioApoyoMovilidadDTO);
        }

        public IngresoDatoServicioApoyoMovilidadDTO BuscarFormato(int Codigo)
        {
            return ingresoDatoServicioApoyoMovilidadDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(IngresoDatoServicioApoyoMovilidadDTO ingresoDatoServicioApoyoMovilidadDTO)
        {
            return ingresoDatoServicioApoyoMovilidadDAO.ActualizaFormato(ingresoDatoServicioApoyoMovilidadDTO);
        }

        public bool EliminarFormato(IngresoDatoServicioApoyoMovilidadDTO ingresoDatoServicioApoyoMovilidadDTO)
        {
            return ingresoDatoServicioApoyoMovilidadDAO.EliminarFormato(ingresoDatoServicioApoyoMovilidadDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return ingresoDatoServicioApoyoMovilidadDAO.InsertarDatos(datos);
        }

    }
}
