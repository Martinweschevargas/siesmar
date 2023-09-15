using Marina.Siesmar.AccesoDatos.Formatos.Difoserece;
using Marina.Siesmar.Entidades.Formatos.Difoserece;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Difoserece
{
    public class AportacionesFondoRetiroCesacion
    {
        AportFondoRetiroCesacionDAO aportacionesFondoRetiroCesacionDAO = new();

        public List<AportFondoRetiroCesacionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return aportacionesFondoRetiroCesacionDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AportFondoRetiroCesacionDTO aportacionesFondoRetiroCesacion, string? fecha)
        {
            return aportacionesFondoRetiroCesacionDAO.AgregarRegistro(aportacionesFondoRetiroCesacion, fecha);
        }

        public AportFondoRetiroCesacionDTO EditarFormato(int Codigo)
        {
            return aportacionesFondoRetiroCesacionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AportFondoRetiroCesacionDTO aportacionesFondoRetiroCesacionDTO)
        {
            return aportacionesFondoRetiroCesacionDAO.ActualizaFormato(aportacionesFondoRetiroCesacionDTO);
        }

        public bool EliminarFormato(AportFondoRetiroCesacionDTO aportacionesFondoRetiroCesacionDTO)
        {
            return aportacionesFondoRetiroCesacionDAO.EliminarFormato(aportacionesFondoRetiroCesacionDTO);
        }

        public bool EliminarCarga(AportFondoRetiroCesacionDTO aportacionesFondoRetiroCesacionDTO)
        {
            return aportacionesFondoRetiroCesacionDAO.EliminarCarga(aportacionesFondoRetiroCesacionDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return aportacionesFondoRetiroCesacionDAO.InsertarDatos(datos, fecha);
        }
    }
}
