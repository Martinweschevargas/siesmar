using Marina.Siesmar.AccesoDatos.Formatos.Comzodos;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comzodos;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzodos
{
    public class AntidisturbioAlistamientoLogistico
    {
        AntidisturbioAlistamientoLogisticoDAO antidisturbioAlistamientoLogisticoDAO = new();

        public List<AntidisturbioAlistamientoLogisticoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return antidisturbioAlistamientoLogisticoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AntidisturbioAlistamientoLogisticoDTO antidisturbioAlistamientoLogistico, string? fecha = null)
        {
            return antidisturbioAlistamientoLogisticoDAO.AgregarRegistro(antidisturbioAlistamientoLogistico, fecha);
        }

        public AntidisturbioAlistamientoLogisticoDTO EditarFormato(int Codigo)
        {
            return antidisturbioAlistamientoLogisticoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AntidisturbioAlistamientoLogisticoDTO antidisturbioAlistamientoLogisticoDTO)
        {
            return antidisturbioAlistamientoLogisticoDAO.ActualizaFormato(antidisturbioAlistamientoLogisticoDTO);
        }

        public bool EliminarFormato(AntidisturbioAlistamientoLogisticoDTO antidisturbioAlistamientoLogisticoDTO)
        {
            return antidisturbioAlistamientoLogisticoDAO.EliminarFormato( antidisturbioAlistamientoLogisticoDTO);
        }

        public bool EliminarCarga(AntidisturbioAlistamientoLogisticoDTO antidisturbioAlistamientoLogisticoDTO)
        {
            return antidisturbioAlistamientoLogisticoDAO.EliminarCarga(antidisturbioAlistamientoLogisticoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return antidisturbioAlistamientoLogisticoDAO.InsertarDatos(datos, fecha);
        }


    }
}
