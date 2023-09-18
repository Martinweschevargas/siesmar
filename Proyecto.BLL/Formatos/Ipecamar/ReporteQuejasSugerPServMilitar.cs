using Marina.Siesmar.AccesoDatos.Formatos.Ipecamar;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Ipecamar
{
    public class ReporteQuejasSugerPServMilitar
    {
        ReporteQuejasSugerPServMilitarDAO reporteQuejasSugerPServMilitarDAO = new();

        public List<ReporteQuejasSugerPServMilitarDTO> ObtenerLista(int? CargaId = null)
        {
            return reporteQuejasSugerPServMilitarDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ReporteQuejasSugerPServMilitarDTO reporteQuejasSugerPServMilitarDTO)
        {
            return reporteQuejasSugerPServMilitarDAO.AgregarRegistro(reporteQuejasSugerPServMilitarDTO);
        }

        public ReporteQuejasSugerPServMilitarDTO EditarFormato(int Codigo)
        {
            return reporteQuejasSugerPServMilitarDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ReporteQuejasSugerPServMilitarDTO reporteQuejasSugerPServMilitarDTO)
        {
            return reporteQuejasSugerPServMilitarDAO.ActualizaFormato(reporteQuejasSugerPServMilitarDTO);
        }

        public bool EliminarFormato(ReporteQuejasSugerPServMilitarDTO reporteQuejasSugerPServMilitarDTO)
        {
            return reporteQuejasSugerPServMilitarDAO.EliminarFormato(reporteQuejasSugerPServMilitarDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return reporteQuejasSugerPServMilitarDAO.InsertarDatos(datos);
        }

    }
}
