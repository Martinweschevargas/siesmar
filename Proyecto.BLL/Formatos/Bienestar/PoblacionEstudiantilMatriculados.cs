using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class PoblacionEstudiantilMatriculados
    {
        PoblacionEstudiantilMatriculadosDAO poblacionEstudiantilMatriculadosDAO = new();

        public List<PoblacionEstudiantilMatriculadosDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return poblacionEstudiantilMatriculadosDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public List<PoblacionEstudiantilMatriculadosDTO> BienestarVisualizacionPoblacionEstudiantilMatriculado(int CargaId)
        {
            return poblacionEstudiantilMatriculadosDAO.BienestarVisualizacionPoblacionEstudiantilMatriculado(CargaId);
        }

        public string AgregarRegistro(PoblacionEstudiantilMatriculadosDTO poblacionEstudiantilMatriculadosDTO, string? fecha)
        {
            return poblacionEstudiantilMatriculadosDAO.AgregarRegistro(poblacionEstudiantilMatriculadosDTO, fecha);
        }

        public PoblacionEstudiantilMatriculadosDTO BuscarFormato(int Codigo)
        {
            return poblacionEstudiantilMatriculadosDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PoblacionEstudiantilMatriculadosDTO poblacionEstudiantilMatriculadosDTO)
        {
            return poblacionEstudiantilMatriculadosDAO.ActualizaFormato(poblacionEstudiantilMatriculadosDTO);
        }

        public bool EliminarFormato(PoblacionEstudiantilMatriculadosDTO poblacionEstudiantilMatriculadosDTO)
        {
            return poblacionEstudiantilMatriculadosDAO.EliminarFormato(poblacionEstudiantilMatriculadosDTO);
        }

        public bool EliminarCarga(PoblacionEstudiantilMatriculadosDTO poblacionEstudiantilMatriculadosDTO)
        {
            return poblacionEstudiantilMatriculadosDAO.EliminarCarga(poblacionEstudiantilMatriculadosDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return poblacionEstudiantilMatriculadosDAO.InsertarDatos(datos, fecha);
        }


    }
}
