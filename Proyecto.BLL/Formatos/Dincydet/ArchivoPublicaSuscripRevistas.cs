using Marina.Siesmar.AccesoDatos.Formatos.Dincydet;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dincydet
{
    public class ArchivoPublicaSuscripRevistas
    {
        ArchivoPublicaSuscripRevistasDAO archivoPublicaSuscripRevistasDAO = new();

        public List<ArchivoPublicaSuscripRevistasDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return archivoPublicaSuscripRevistasDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ArchivoPublicaSuscripRevistasDTO archivoPublicaSuscripRevistas, string? fecha)
        {
            return archivoPublicaSuscripRevistasDAO.AgregarRegistro(archivoPublicaSuscripRevistas, fecha);
        }

        public ArchivoPublicaSuscripRevistasDTO BuscarFormato(int Codigo)
        {
            return archivoPublicaSuscripRevistasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ArchivoPublicaSuscripRevistasDTO archivoPublicaSuscripRevistasDTO)
        {
            return archivoPublicaSuscripRevistasDAO.ActualizaFormato(archivoPublicaSuscripRevistasDTO);
        }

        public bool EliminarFormato(ArchivoPublicaSuscripRevistasDTO archivoPublicaSuscripRevistasDTO)
        {
            return archivoPublicaSuscripRevistasDAO.EliminarFormato(archivoPublicaSuscripRevistasDTO);
        }

        public bool EliminarCarga(ArchivoPublicaSuscripRevistasDTO archivoPublicaSuscripRevistasDTO)
        {
            return archivoPublicaSuscripRevistasDAO.EliminarCarga(archivoPublicaSuscripRevistasDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return archivoPublicaSuscripRevistasDAO.InsertarDatos(datos, fecha);
        }

    }
}
