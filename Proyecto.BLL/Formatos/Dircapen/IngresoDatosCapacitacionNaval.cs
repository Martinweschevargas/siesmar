using Marina.Siesmar.AccesoDatos.Formatos.Dircapen;
using Marina.Siesmar.Entidades.Formatos.Dircapen;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dircapen
{
    public class IngresoDatosCapacitacionNaval
    {
        IngresoDatosCapacitacionNavalDAO ingresoDatosCapacitacionNavalDAO = new();

        public List<IngresoDatosCapacitacionNavalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return ingresoDatosCapacitacionNavalDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(IngresoDatosCapacitacionNavalDTO ingresoDatosCapacitacionNavalDTO, string? fecha = null)
        {
            return ingresoDatosCapacitacionNavalDAO.AgregarRegistro(ingresoDatosCapacitacionNavalDTO, fecha);
        }

        public IngresoDatosCapacitacionNavalDTO EditarFormato(int Codigo)
        {
            return ingresoDatosCapacitacionNavalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(IngresoDatosCapacitacionNavalDTO ingresoDatosCapacitacionNavalDTO)
        {
            return ingresoDatosCapacitacionNavalDAO.ActualizaFormato(ingresoDatosCapacitacionNavalDTO);
        }

        public bool EliminarFormato(IngresoDatosCapacitacionNavalDTO ingresoDatosCapacitacionNavalDTO)
        {
            return ingresoDatosCapacitacionNavalDAO.EliminarFormato(ingresoDatosCapacitacionNavalDTO);
        }

        public bool EliminarCarga(IngresoDatosCapacitacionNavalDTO ingresoDatosCapacitacionNavalDTO)
        {
            return ingresoDatosCapacitacionNavalDAO.EliminarCarga(ingresoDatosCapacitacionNavalDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return ingresoDatosCapacitacionNavalDAO.InsertarDatos(datos, fecha);
        }

    }
}
