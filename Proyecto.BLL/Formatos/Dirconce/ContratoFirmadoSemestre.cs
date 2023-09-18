using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dirconce;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirconce;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirconce
{
    public class ContratoFirmadoSemestre
    {
        ContratoFirmadoSemestreDAO contratoFirmadoSemestreDAO = new();

        public List<ContratoFirmadoSemestreDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return contratoFirmadoSemestreDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ContratoFirmadoSemestreDTO contratoFirmadoSemestre, string? fecha)
        {
            return contratoFirmadoSemestreDAO.AgregarRegistro(contratoFirmadoSemestre, fecha);
        }

        public ContratoFirmadoSemestreDTO EditarFormado(int Codigo)
        {
            return contratoFirmadoSemestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ContratoFirmadoSemestreDTO contratoFirmadoSemestreDTO)
        {
            return contratoFirmadoSemestreDAO.ActualizaFormato(contratoFirmadoSemestreDTO);
        }

        public bool EliminarFormato(ContratoFirmadoSemestreDTO contratoFirmadoSemestreDTO)
        {
            return contratoFirmadoSemestreDAO.EliminarFormato( contratoFirmadoSemestreDTO);
        }

        public bool EliminarCarga(ContratoFirmadoSemestreDTO contratoFirmadoSemestreDTO)
        {
            return contratoFirmadoSemestreDAO.EliminarCarga(contratoFirmadoSemestreDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return contratoFirmadoSemestreDAO.InsertarDatos(datos, fecha);
        }

    }
}
