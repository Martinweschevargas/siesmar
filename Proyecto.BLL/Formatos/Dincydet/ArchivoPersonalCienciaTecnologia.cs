using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dincydet;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dincydet
{
    public class ArchivoPersonalCienciaTecnologia
    {
        ArchivoPersonalCienciaTecnologiaDAO archivoPersonalCienciaTecnologiaDAO = new();

        public List<ArchivoPersonalCienciaTecnologiaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return archivoPersonalCienciaTecnologiaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ArchivoPersonalCienciaTecnologiaDTO archivoPersonalCienciaTecnologia, string? fecha)
        {
            return archivoPersonalCienciaTecnologiaDAO.AgregarRegistro(archivoPersonalCienciaTecnologia, fecha);
        }

        public ArchivoPersonalCienciaTecnologiaDTO BuscarFormato(int Codigo)
        {
            return archivoPersonalCienciaTecnologiaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ArchivoPersonalCienciaTecnologiaDTO archivoPersonalCienciaTecnologiaDTO)
        {
            return archivoPersonalCienciaTecnologiaDAO.ActualizaFormato(archivoPersonalCienciaTecnologiaDTO);
        }

        public bool EliminarFormato(ArchivoPersonalCienciaTecnologiaDTO archivoPersonalCienciaTecnologiaDTO)
        {
            return archivoPersonalCienciaTecnologiaDAO.EliminarFormato(archivoPersonalCienciaTecnologiaDTO);
        }

        public bool EliminarCarga(ArchivoPersonalCienciaTecnologiaDTO archivoPersonalCienciaTecnologiaDTO)
        {
            return archivoPersonalCienciaTecnologiaDAO.EliminarCarga(archivoPersonalCienciaTecnologiaDTO);
        }


        public string InsertarDatos(DataTable datos, string fecha)
        {
            return archivoPersonalCienciaTecnologiaDAO.InsertarDatos(datos, fecha);
        }
    }
}
