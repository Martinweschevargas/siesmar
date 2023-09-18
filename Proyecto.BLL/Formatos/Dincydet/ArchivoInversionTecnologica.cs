using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dincydet;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dincydet
{
    public class ArchivoInversionTecnologica
    {
        ArchivoInversionTecnologicaDAO archivoInversionTecnologicaDAO = new();

        public List<ArchivoInversionTecnologicaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return archivoInversionTecnologicaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ArchivoInversionTecnologicaDTO archivoInversionTecnologica, string? fecha)
        {
            return archivoInversionTecnologicaDAO.AgregarRegistro(archivoInversionTecnologica, fecha);
        }

        public ArchivoInversionTecnologicaDTO BuscarFormato(int Codigo)
        {
            return archivoInversionTecnologicaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ArchivoInversionTecnologicaDTO archivoInversionTecnologicaDTO)
        {
            return archivoInversionTecnologicaDAO.ActualizaFormato(archivoInversionTecnologicaDTO);
        }

        public bool EliminarFormato(ArchivoInversionTecnologicaDTO archivoInversionTecnologicaDTO)
        {
            return archivoInversionTecnologicaDAO.EliminarFormato(archivoInversionTecnologicaDTO);
        }

        public bool EliminarCarga(ArchivoInversionTecnologicaDTO archivoInversionTecnologicaDTO)
        {
            return archivoInversionTecnologicaDAO.EliminarCarga(archivoInversionTecnologicaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return archivoInversionTecnologicaDAO.InsertarDatos(datos, fecha);
        }

    }
}
