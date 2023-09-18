using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class InventarioSIProduccion
    {
        InventarioSIProduccionDAO inventarioSIProduccionDAO = new();

        public List<InventarioSIProduccionDTO> ObtenerLista(int? CargaId = null)
        {
            return inventarioSIProduccionDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(InventarioSIProduccionDTO inventarioSIProduccion)
        {
            return inventarioSIProduccionDAO.AgregarRegistro(inventarioSIProduccion);
        }

        public InventarioSIProduccionDTO BuscarFormato(int Codigo)
        {
            return inventarioSIProduccionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(InventarioSIProduccionDTO inventarioSIProduccionDTO)
        {
            return inventarioSIProduccionDAO.ActualizaFormato(inventarioSIProduccionDTO);
        }

        public bool EliminarFormato(InventarioSIProduccionDTO inventarioSIProduccionDTO)
        {
            return inventarioSIProduccionDAO.EliminarFormato( inventarioSIProduccionDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return inventarioSIProduccionDAO.InsertarDatos(datos);
        }


    }
}
