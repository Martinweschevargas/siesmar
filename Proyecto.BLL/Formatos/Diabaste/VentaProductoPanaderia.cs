using Marina.Siesmar.AccesoDatos.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using System.Data;


namespace Marina.Siesmar.LogicaNegocios.Formatos.Diabaste
{
    public class VentaProductoPanaderia
    {

        VentaProductoPanaderiaDAO ventaProductoPanaderiaDAO = new();

        public List<VentaProductoPanaderiaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return ventaProductoPanaderiaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(VentaProductoPanaderiaDTO ventaProductoPanaderia, string? fecha)
        {
            return ventaProductoPanaderiaDAO.AgregarRegistro(ventaProductoPanaderia, fecha);
        }

        public VentaProductoPanaderiaDTO EditarFormado(int Codigo)
        {
            return ventaProductoPanaderiaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(VentaProductoPanaderiaDTO ventaProductoPanaderiaDTO)
        {
            return ventaProductoPanaderiaDAO.ActualizaFormato(ventaProductoPanaderiaDTO);
        }

        public bool EliminarFormato(VentaProductoPanaderiaDTO ventaProductoPanaderiaDTO)
        {
            return ventaProductoPanaderiaDAO.EliminarFormato(ventaProductoPanaderiaDTO);
        }

        public bool EliminarCarga(VentaProductoPanaderiaDTO ventaProductoPanaderiaDTO)
        {
            return ventaProductoPanaderiaDAO.EliminarCarga(ventaProductoPanaderiaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return ventaProductoPanaderiaDAO.InsertarDatos(datos, fecha);
        }


    }
}
