using Marina.Siesmar.AccesoDatos.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfasub
{
    public class ProgramaDiqueoComfasub
    {
        ProgramaDiqueoComfasubDAO programaDiqueoComfasubDAO = new();

        public List<ProgramaDiqueoComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return programaDiqueoComfasubDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ProgramaDiqueoComfasubDTO programaDiqueoComfasub, string? fecha)
        {
            return programaDiqueoComfasubDAO.AgregarRegistro(programaDiqueoComfasub, fecha);
        }

        public ProgramaDiqueoComfasubDTO EditarFormado(int Codigo)
        {
            return programaDiqueoComfasubDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ProgramaDiqueoComfasubDTO programaDiqueoComfasubDTO)
        {
            return programaDiqueoComfasubDAO.ActualizaFormato(programaDiqueoComfasubDTO);
        }

        public bool EliminarFormato(ProgramaDiqueoComfasubDTO programaDiqueoComfasubDTO)
        {
            return programaDiqueoComfasubDAO.EliminarFormato( programaDiqueoComfasubDTO);
        }

        public bool EliminarCarga(ProgramaDiqueoComfasubDTO programaDiqueoComfasubDTO)
        {
            return programaDiqueoComfasubDAO.EliminarCarga(programaDiqueoComfasubDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return programaDiqueoComfasubDAO.InsertarDatos(datos, fecha);
        }

    }
}
