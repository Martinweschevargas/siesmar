using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Direcomar;
using Marina.Siesmar.Entidades.Formatos.Direcomar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Direcomar
{
    public class RendicionCuentasSBEGastos
    {
        RendicionCuentasSBEGastosDAO rendicionCuentasSBEGastosDAO = new();

        public List<RendicionCuentasSBEGastosDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return rendicionCuentasSBEGastosDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }
        public List<RendicionCuentasSBEGastosDTO> DirecomarVisualizacionRendicionCuentasSBEGastos(int? CargaId = null, string? fechaInicio=null, string? fechaFin = null)
        {
            return rendicionCuentasSBEGastosDAO.DirecomarVisualizacionRendicionCuentasSBEGastos(CargaId, fechaInicio, fechaFin);
        }
        public string AgregarRegistro(RendicionCuentasSBEGastosDTO rendicionCuentasSBEGastosDTO, string? fecha)
        {
            return rendicionCuentasSBEGastosDAO.AgregarRegistro(rendicionCuentasSBEGastosDTO, fecha);
        }

        public RendicionCuentasSBEGastosDTO EditarFormato(int Codigo)
        {
            return rendicionCuentasSBEGastosDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RendicionCuentasSBEGastosDTO rendicionCuentasSBEGastosDTO)
        {
            return rendicionCuentasSBEGastosDAO.ActualizaFormato(rendicionCuentasSBEGastosDTO);
        }

        public bool EliminarFormato(RendicionCuentasSBEGastosDTO rendicionCuentasSBEGastosDTO)
        {
            return rendicionCuentasSBEGastosDAO.EliminarFormato(rendicionCuentasSBEGastosDTO);
        }

        public bool EliminarCarga(RendicionCuentasSBEGastosDTO rendicionCuentasSBEGastosDTO)
        {
            return rendicionCuentasSBEGastosDAO.EliminarCarga(rendicionCuentasSBEGastosDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return rendicionCuentasSBEGastosDAO.InsertarDatos(datos, fecha);
        }

    }
}
