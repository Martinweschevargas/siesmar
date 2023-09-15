using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class DocenteInstitucioesEducativas
    {
        DocenteInstitucioesEducativasDAO docenteInstitucioesEducativasDAO = new();

        public List<DocenteInstitucioesEducativasDTO> ObtenerLista(int? CargaId = null, string? fechaInicio = null, string? fechaFin = null)
        {
            return docenteInstitucioesEducativasDAO.ObtenerLista(CargaId, fechaInicio, fechaFin);
        }

        //public List<DocenteInstitucioesEducativasDTO> BienestarVisualizacionDocenteInstitucionEducativa(int? CargaId, string? fechaInicio = null, string? fechaFin = null)
        //{
        //    return docenteInstitucioesEducativasDAO.BienestarVisualizacionDocenteInstitucionEducativa(CargaId, fechaInicio, fechaFin);
        //}

        public string AgregarRegistro(DocenteInstitucioesEducativasDTO docenteInstitucioesEducativasDTO, string fecha)
        {
            return docenteInstitucioesEducativasDAO.AgregarRegistro(docenteInstitucioesEducativasDTO, fecha);
        }

        public DocenteInstitucioesEducativasDTO EditarFormato(int Codigo)
        {
            return docenteInstitucioesEducativasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(DocenteInstitucioesEducativasDTO docenteInstitucioesEducativasDTO)
        {
            return docenteInstitucioesEducativasDAO.ActualizaFormato(docenteInstitucioesEducativasDTO);
        }

        public bool EliminarFormato(DocenteInstitucioesEducativasDTO docenteInstitucioesEducativasDTO)
        {
            return docenteInstitucioesEducativasDAO.EliminarFormato(docenteInstitucioesEducativasDTO);
        }

        public bool EliminarCarga(DocenteInstitucioesEducativasDTO docenteInstitucioesEducativasDTO)
        {
            return docenteInstitucioesEducativasDAO.EliminarCarga(docenteInstitucioesEducativasDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return docenteInstitucioesEducativasDAO.InsertarDatos(datos, fecha);
        }


    }
}
