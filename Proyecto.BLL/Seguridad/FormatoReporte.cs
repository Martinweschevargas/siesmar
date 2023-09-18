using Marina.Siesmar.AccesoDatos.Seguridad;
using Marina.Siesmar.Entidades.Seguridad;


namespace Marina.Siesmar.LogicaNegocios.Seguridad
{
    public class FormatoReporte
    {
        FormatoReporteDAO FormatoReporteDAO = new FormatoReporteDAO();

        public List<FormatoReporteDTO> ObtenerFormatoReportes()
        {
            return FormatoReporteDAO.ObtenerFormatoReportes();
        }

        public string AgregarFormatoReporte(FormatoReporteDTO FormatoReporteDto)
        {
            return FormatoReporteDAO.AgregarFormatoReporte(FormatoReporteDto);
        }

        public FormatoReporteDTO BuscarFormatoReporte(int Codigo)
        {
            return FormatoReporteDAO.BuscarFormatoReporteID(Codigo);
        }

        public string ActualizaFormatoReporte(FormatoReporteDTO FormatoReporteDto)
        {
            return FormatoReporteDAO.ActualizarFormatoReporte(FormatoReporteDto);
        }

        public string EliminarFormatoReporte(FormatoReporteDTO formatoReporteDto)
        {
            return FormatoReporteDAO.EliminarFormatoReporte(formatoReporteDto);
        }



    }
}
