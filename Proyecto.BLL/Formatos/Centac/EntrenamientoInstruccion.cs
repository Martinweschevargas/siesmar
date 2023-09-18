using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.AccesoDatos.Formatos.Centac;
using Marina.Siesmar.Entidades.Formatos.Centac;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Centac
{
    public class EntrenamientoInstruccion
    {
        EntrenamientoInstruccionDAO entrenamientoInstruccionDAO = new();

        public List<EntrenamientoInstruccionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return entrenamientoInstruccionDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EntrenamientoInstruccionDTO entrenamientoInstruccionDTO, string? fecha = null)
        {
            return entrenamientoInstruccionDAO.AgregarRegistro(entrenamientoInstruccionDTO, fecha);
        }

        public EntrenamientoInstruccionDTO EditarFormado(int Codigo)
        {
            return entrenamientoInstruccionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EntrenamientoInstruccionDTO entrenamientoInstruccionDTO)
        {
            return entrenamientoInstruccionDAO.ActualizaFormato(entrenamientoInstruccionDTO);
        }

        public bool EliminarFormato(EntrenamientoInstruccionDTO entrenamientoInstruccionDTO)
        {
            return entrenamientoInstruccionDAO.EliminarFormato(entrenamientoInstruccionDTO);
        }

        public bool EliminarCarga(EntrenamientoInstruccionDTO entrenamientoInstruccionDTO)
        {
            return entrenamientoInstruccionDAO.EliminarCarga(entrenamientoInstruccionDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return entrenamientoInstruccionDAO.InsertarDatos(datos, fecha);
        }

    }
}
