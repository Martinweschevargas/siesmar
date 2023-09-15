
using Marina.Siesmar.AccesoDatos.Formatos.Comesguard;
using Marina.Siesmar.Entidades.Formatos.Comesguard;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comesguard
{
    public class IngresoDatoServicioAlimentacion
    {
        IngresoDatoServicioAlimentacionDAO ingresoDatoServicioAlimentacionDAO = new();

        public List<IngresoDatoServicioAlimentacionDTO> ObtenerLista(int? CargaId = null)
        {
            return ingresoDatoServicioAlimentacionDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(IngresoDatoServicioAlimentacionDTO ingresoDatoServicioAlimentacionDTO)
        {
            return ingresoDatoServicioAlimentacionDAO.AgregarRegistro(ingresoDatoServicioAlimentacionDTO);
        }

        public IngresoDatoServicioAlimentacionDTO BuscarFormato(int Codigo)
        {
            return ingresoDatoServicioAlimentacionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(IngresoDatoServicioAlimentacionDTO ingresoDatoServicioAlimentacionDTO)
        {
            return ingresoDatoServicioAlimentacionDAO.ActualizaFormato(ingresoDatoServicioAlimentacionDTO);
        }

        public bool EliminarFormato(IngresoDatoServicioAlimentacionDTO ingresoDatoServicioAlimentacionDTO)
        {
            return ingresoDatoServicioAlimentacionDAO.EliminarFormato(ingresoDatoServicioAlimentacionDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return ingresoDatoServicioAlimentacionDAO.InsertarDatos(datos);
        }

    }
}
