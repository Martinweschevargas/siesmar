using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dincydet;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dincydet
{
    public class PatenteInvestigacionDesarrollo
    {
        PatenteInvestigacionDesarrolloDAO patenteInvestigacionDesarrolloDAO = new();

        public List<PatenteInvestigacionDesarrolloDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return patenteInvestigacionDesarrolloDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(PatenteInvestigacionDesarrolloDTO patenteInvestigacionDesarrollo, string? fecha)
        {
            return patenteInvestigacionDesarrolloDAO.AgregarRegistro(patenteInvestigacionDesarrollo, fecha);
        }

        public PatenteInvestigacionDesarrolloDTO BuscarFormato(int Codigo)
        {
            return patenteInvestigacionDesarrolloDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PatenteInvestigacionDesarrolloDTO patenteInvestigacionDesarrolloDTO)
        {
            return patenteInvestigacionDesarrolloDAO.ActualizaFormato(patenteInvestigacionDesarrolloDTO);
        }

        public bool EliminarFormato(PatenteInvestigacionDesarrolloDTO patenteInvestigacionDesarrolloDTO)
        {
            return patenteInvestigacionDesarrolloDAO.EliminarFormato(patenteInvestigacionDesarrolloDTO);
        }

        public bool EliminarCarga(PatenteInvestigacionDesarrolloDTO patenteInvestigacionDesarrolloDTO)
        {
            return patenteInvestigacionDesarrolloDAO.EliminarCarga(patenteInvestigacionDesarrolloDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return patenteInvestigacionDesarrolloDAO.InsertarDatos(datos, fecha);
        }


    }
}
