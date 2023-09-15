
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Disamar;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.Entidades.Formatos.Disamar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Disamar
{
    public class RegistroPersonalSaludEstablecimiento
    {
        RegistroPersonalSaludEstablecimientoDAO registroPersonalSaludEstablecimientoDAO = new();

        public List<RegistroPersonalSaludEstablecimientoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return registroPersonalSaludEstablecimientoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(RegistroPersonalSaludEstablecimientoDTO registroPersonalSaludEstablecimientoDTO, string? fecha)
        {
            return registroPersonalSaludEstablecimientoDAO.AgregarRegistro(registroPersonalSaludEstablecimientoDTO, fecha);
        }

        public RegistroPersonalSaludEstablecimientoDTO EditarFormato(int Codigo)
        {
            return registroPersonalSaludEstablecimientoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroPersonalSaludEstablecimientoDTO registroPersonalSaludEstablecimientoDTO)
        {
            return registroPersonalSaludEstablecimientoDAO.ActualizaFormato(registroPersonalSaludEstablecimientoDTO);
        }

        public bool EliminarFormato(RegistroPersonalSaludEstablecimientoDTO registroPersonalSaludEstablecimientoDTO)
        {
            return registroPersonalSaludEstablecimientoDAO.EliminarFormato(registroPersonalSaludEstablecimientoDTO);
        }

        public bool EliminarCarga(RegistroPersonalSaludEstablecimientoDTO registroPersonalSaludEstablecimientoDTO)
        {
            return registroPersonalSaludEstablecimientoDAO.EliminarCarga(registroPersonalSaludEstablecimientoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return registroPersonalSaludEstablecimientoDAO.InsertarDatos(datos, fecha);
        }

    }
}
