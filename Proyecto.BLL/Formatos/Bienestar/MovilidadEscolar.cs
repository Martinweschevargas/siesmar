using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class MovilidadEscolar
    {
        MovilidadEscolarDAO movilidadEscolarDAO = new();

        public List<MovilidadEscolarDTO> ObtenerLista(int? CargaId = null, string? fechaInicio = null, string? fechaFin = null)
        {
            return movilidadEscolarDAO.ObtenerLista(CargaId, fechaInicio, fechaFin);
        }
       public List<MovilidadEscolarDTO> BienestarVisualizacionMovilidadEscolar(int? CargaId = null, string? fechaInicio = null, string? fechaFin = null)
        {
            return movilidadEscolarDAO.BienestarVisualizacionMovilidadEscolar(CargaId, fechaInicio, fechaFin);
        }

        public string AgregarRegistro(MovilidadEscolarDTO movilidadEscolarDTO, string fechaCarga)
        {
            return movilidadEscolarDAO.AgregarRegistro(movilidadEscolarDTO, fechaCarga);
        }

        public MovilidadEscolarDTO BuscarFormato(int Codigo)
        {
            return movilidadEscolarDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(MovilidadEscolarDTO movilidadEscolarDTO)
        {
            return movilidadEscolarDAO.ActualizaFormato(movilidadEscolarDTO);
        }

        public bool EliminarFormato(MovilidadEscolarDTO movilidadEscolarDTO)
        {
            return movilidadEscolarDAO.EliminarFormato(movilidadEscolarDTO);
        }

        public bool EliminarCarga(MovilidadEscolarDTO movilidadEscolarDTO)
        {
            return movilidadEscolarDAO.EliminarCarga(movilidadEscolarDTO);
        }

        public string InsertarDatos(DataTable datos, string fechaCarga)
        {
            return movilidadEscolarDAO.InsertarDatos(datos, fechaCarga);
        }

    }
}
