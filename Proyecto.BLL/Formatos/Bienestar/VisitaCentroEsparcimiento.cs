using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class VisitaCentroEsparcimiento
    {
        VisitaCentroEsparcimientoDAO visitaCentroEsparcimientoDAO = new();

        public List<VisitaCentroEsparcimientoDTO> ObtenerLista(int? CargaId = null, string? fechaInicio = null, string? fechaFin = null)
        {
            return visitaCentroEsparcimientoDAO.ObtenerLista(CargaId, fechaInicio, fechaFin);
        }

        //public List<VisitaCentroEsparcimientoDTO> BienestarVisualizacionVisitaCentroEsparcimiento( int CargaId)
        //{
        //    return visitaCentroEsparcimientoDAO.BienestarVisualizacionVisitaCentroEsparcimiento(CargaId);
        //}

        //public List<VisitaCentroEsparcimientoDTO> TotalVisitasMensualesCentrosEsparcimientosXTipoUsuarioAnio(int para1, int para2)
        //{
        //    return visitaCentroEsparcimientoDAO.TotalVisitasMensualesCentrosEsparcimientosXTipoUsuarioAnio(para1, para2);
        //}

        public string AgregarRegistro(VisitaCentroEsparcimientoDTO visitaCentroEsparcimientoDTO, string? fecha)
        {
            return visitaCentroEsparcimientoDAO.AgregarRegistro(visitaCentroEsparcimientoDTO, fecha);
        }

        public VisitaCentroEsparcimientoDTO EditarFormato(int Codigo)
        {
            return visitaCentroEsparcimientoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(VisitaCentroEsparcimientoDTO visitaCentroEsparcimientoDTO)
        {
            return visitaCentroEsparcimientoDAO.ActualizaFormato(visitaCentroEsparcimientoDTO);
        }

        public bool EliminarFormato(VisitaCentroEsparcimientoDTO visitaCentroEsparcimientoDTO)
        {
            return visitaCentroEsparcimientoDAO.EliminarFormato(visitaCentroEsparcimientoDTO);
        }

        public bool EliminarCarga(VisitaCentroEsparcimientoDTO visitaCentroEsparcimientoDTO)
        {
            return visitaCentroEsparcimientoDAO.EliminarCarga(visitaCentroEsparcimientoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return visitaCentroEsparcimientoDAO.InsertarDatos(datos, fecha);
        }

    }
}
