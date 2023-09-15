using Marina.Siesmar.AccesoDatos.Formatos.Ipecamar;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Ipecamar
{
    public class ReporteAcademiaServMilitar
    {
        ReporteAcademiaServMilitarDAO reporteAcademiaServMilitarDAO = new();

        public List<ReporteAcademiaServMilitarDTO> ObtenerLista(int? CargaId=null)
        {
            return reporteAcademiaServMilitarDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ReporteAcademiaServMilitarDTO reporteAcademiaServMilitarDTO)
        {
            return reporteAcademiaServMilitarDAO.AgregarRegistro(reporteAcademiaServMilitarDTO);
        }

        public ReporteAcademiaServMilitarDTO BuscarFormato(int Codigo)
        {
            return reporteAcademiaServMilitarDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ReporteAcademiaServMilitarDTO reporteAcademiaServMilitarDTO)
        {
            return reporteAcademiaServMilitarDAO.ActualizaFormato(reporteAcademiaServMilitarDTO);
        }

        public bool EliminarFormato(ReporteAcademiaServMilitarDTO reporteAcademiaServMilitarDTO)
        {
            return reporteAcademiaServMilitarDAO.EliminarFormato(reporteAcademiaServMilitarDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return reporteAcademiaServMilitarDAO.InsertarDatos(datos);
        }


    }
}
