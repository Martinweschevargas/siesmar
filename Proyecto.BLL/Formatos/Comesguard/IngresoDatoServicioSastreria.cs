
using Marina.Siesmar.AccesoDatos.Formatos.Comesguard;
using Marina.Siesmar.Entidades.Formatos.Comesguard;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comesguard
{
    public class IngresoDatoServicioSastreria
    {
        IngresoDatoServicioSastreriaDAO ingresoDatoServicioSastreriaDAO = new();

        public List<IngresoDatoServicioSastreriaDTO> ObtenerLista(int? CargaId = null)
        {
            return ingresoDatoServicioSastreriaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(IngresoDatoServicioSastreriaDTO ingresoDatoServicioSastreriaDTO)
        {
            return ingresoDatoServicioSastreriaDAO.AgregarRegistro(ingresoDatoServicioSastreriaDTO);
        }

        public IngresoDatoServicioSastreriaDTO BuscarFormato(int Codigo)
        {
            return ingresoDatoServicioSastreriaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(IngresoDatoServicioSastreriaDTO ingresoDatoServicioSastreriaDTO)
        {
            return ingresoDatoServicioSastreriaDAO.ActualizaFormato(ingresoDatoServicioSastreriaDTO);
        }

        public bool EliminarFormato(IngresoDatoServicioSastreriaDTO ingresoDatoServicioSastreriaDTO)
        {
            return ingresoDatoServicioSastreriaDAO.EliminarFormato(ingresoDatoServicioSastreriaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return ingresoDatoServicioSastreriaDAO.InsertarDatos(datos);
        }

    }
}
