
using Marina.Siesmar.AccesoDatos.Formatos.Comesguard;
using Marina.Siesmar.Entidades.Formatos.Comesguard;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comesguard
{
    public class IngresoDatoServicioLavanderia
    {
        IngresoDatoServicioLavanderiaDAO ingresoDatoServicioLavanderiaDAO = new();

        public List<IngresoDatoServicioLavanderiaDTO> ObtenerLista(int? CargaId = null)
        {
            return ingresoDatoServicioLavanderiaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(IngresoDatoServicioLavanderiaDTO ingresoDatoServicioLavanderiaDTO)
        {
            return ingresoDatoServicioLavanderiaDAO.AgregarRegistro(ingresoDatoServicioLavanderiaDTO);
        }

        public IngresoDatoServicioLavanderiaDTO BuscarFormato(int Codigo)
        {
            return ingresoDatoServicioLavanderiaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(IngresoDatoServicioLavanderiaDTO ingresoDatoServicioLavanderiaDTO)
        {
            return ingresoDatoServicioLavanderiaDAO.ActualizaFormato(ingresoDatoServicioLavanderiaDTO);
        }

        public bool EliminarFormato(IngresoDatoServicioLavanderiaDTO ingresoDatoServicioLavanderiaDTO)
        {
            return ingresoDatoServicioLavanderiaDAO.EliminarFormato(ingresoDatoServicioLavanderiaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return ingresoDatoServicioLavanderiaDAO.InsertarDatos(datos);
        }

    }
}
