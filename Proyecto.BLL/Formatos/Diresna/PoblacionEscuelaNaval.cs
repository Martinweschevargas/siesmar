using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Diresna;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresna;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diresna
{
    public class PoblacionEscuelaNaval
    {
        PoblacionEscuelaNavalDAO poblacionEscuelaNavalDAO = new();

        public List<PoblacionEscuelaNavalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return poblacionEscuelaNavalDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(PoblacionEscuelaNavalDTO poblacionEscuelaNavalDTO, string? fecha = null)
        {
            return poblacionEscuelaNavalDAO.AgregarRegistro(poblacionEscuelaNavalDTO, fecha);
        }

        public PoblacionEscuelaNavalDTO EditarFormato(int Codigo)
        {
            return poblacionEscuelaNavalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PoblacionEscuelaNavalDTO poblacionEscuelaNavalDTO)
        {
            return poblacionEscuelaNavalDAO.ActualizaFormato(poblacionEscuelaNavalDTO);
        }

        public bool EliminarFormato(PoblacionEscuelaNavalDTO poblacionEscuelaNavalDTO)
        {
            return poblacionEscuelaNavalDAO.EliminarFormato(poblacionEscuelaNavalDTO);
        }

        public bool EliminarCarga(PoblacionEscuelaNavalDTO poblacionEscuelaNavalDTO)
        {
            return poblacionEscuelaNavalDAO.EliminarCarga(poblacionEscuelaNavalDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return poblacionEscuelaNavalDAO.InsertarDatos(datos, fecha);
        }

    }
}
