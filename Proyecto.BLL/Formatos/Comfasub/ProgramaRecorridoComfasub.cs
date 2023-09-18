using Marina.Siesmar.AccesoDatos.Formatos.Comfasub;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfasub
{
    public class ProgramaRecorridoComfasub
    {
        ProgramaRecorridoComfasubDAO programaRecorridoComfasubDAO = new();

        public List<ProgramaRecorridoComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return programaRecorridoComfasubDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ProgramaRecorridoComfasubDTO programaRecorridoComfasub, string? fecha)
        {
            return programaRecorridoComfasubDAO.AgregarRegistro(programaRecorridoComfasub, fecha);
        }

        public ProgramaRecorridoComfasubDTO EditarFormado(int Codigo)
        {
            return programaRecorridoComfasubDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ProgramaRecorridoComfasubDTO programaRecorridoComfasubDTO)
        {
            return programaRecorridoComfasubDAO.ActualizaFormato(programaRecorridoComfasubDTO);
        }

        public bool EliminarFormato(ProgramaRecorridoComfasubDTO programaRecorridoComfasubDTO)
        {
            return programaRecorridoComfasubDAO.EliminarFormato( programaRecorridoComfasubDTO);
        }

        public bool EliminarCarga(ProgramaRecorridoComfasubDTO programaRecorridoComfasubDTO)
        {
            return programaRecorridoComfasubDAO.EliminarCarga(programaRecorridoComfasubDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return programaRecorridoComfasubDAO.InsertarDatos(datos, fecha);
        }

    }
}
