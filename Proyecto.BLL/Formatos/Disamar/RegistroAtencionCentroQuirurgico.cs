
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Disamar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Disamar;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Disamar
{
    public class RegistroAtencionCentroQuirurgico
    {
        RegistroAtencionCentroQuirurgicoDAO registroAtencionCentroQuirurgicoDAO = new();

        public List<RegistroAtencionCentroQuirurgicoDTO> ObtenerLista(int? CargaId = null, int? mes = null, int? anio = null)
        {
            return registroAtencionCentroQuirurgicoDAO.ObtenerLista(CargaId, mes, anio);
        }

        public string AgregarRegistro(RegistroAtencionCentroQuirurgicoDTO registroAtencionCentroQuirurgicoDTO, int mes, int anio)
        {
            return registroAtencionCentroQuirurgicoDAO.AgregarRegistro(registroAtencionCentroQuirurgicoDTO, mes, anio);
        }

        public RegistroAtencionCentroQuirurgicoDTO EditarFormato(int Codigo)
        {
            return registroAtencionCentroQuirurgicoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroAtencionCentroQuirurgicoDTO registroAtencionCentroQuirurgicoDTO)
        {
            return registroAtencionCentroQuirurgicoDAO.ActualizaFormato(registroAtencionCentroQuirurgicoDTO);
        }

        public bool EliminarFormato(RegistroAtencionCentroQuirurgicoDTO registroAtencionCentroQuirurgicoDTO)
        {
            return registroAtencionCentroQuirurgicoDAO.EliminarFormato(registroAtencionCentroQuirurgicoDTO);
        }

        public bool EliminarCarga(RegistroAtencionCentroQuirurgicoDTO registroAtencionCentroQuirurgicoDTO)
        {
            return registroAtencionCentroQuirurgicoDAO.EliminarCarga(registroAtencionCentroQuirurgicoDTO);
        }

        public string InsertarDatos(DataTable datos, int mes, int anio)
        {
            return registroAtencionCentroQuirurgicoDAO.InsertarDatos(datos, mes, anio);
        }


    }
}
