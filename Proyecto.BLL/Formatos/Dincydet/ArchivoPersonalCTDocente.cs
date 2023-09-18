using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dincydet;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dincydet
{
    public class ArchivoPersonalCTDocente
    {
        ArchivoPersonalCTDocenteDAO archivoPersonalCTDocenteDAO = new();

        public List<ArchivoPersonalCTDocenteDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return archivoPersonalCTDocenteDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ArchivoPersonalCTDocenteDTO archivoPersonalCTDocente, string? fecha)
        {
            return archivoPersonalCTDocenteDAO.AgregarRegistro(archivoPersonalCTDocente, fecha);
        }

        public ArchivoPersonalCTDocenteDTO BuscarFormato(int Codigo)
        {
            return archivoPersonalCTDocenteDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ArchivoPersonalCTDocenteDTO archivoPersonalCTDocenteDTO)
        {
            return archivoPersonalCTDocenteDAO.ActualizaFormato(archivoPersonalCTDocenteDTO);
        }

        public bool EliminarFormato(ArchivoPersonalCTDocenteDTO archivoPersonalCTDocenteDTO)
        {
            return archivoPersonalCTDocenteDAO.EliminarFormato(archivoPersonalCTDocenteDTO);
        }

        public bool EliminarCarga(ArchivoPersonalCTDocenteDTO archivoPersonalCTDocenteDTO)
        {
            return archivoPersonalCTDocenteDAO.EliminarCarga(archivoPersonalCTDocenteDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return archivoPersonalCTDocenteDAO.InsertarDatos(datos, fecha);
        }


    }
}
