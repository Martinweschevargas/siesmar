using Marina.Siesmar.AccesoDatos.Formatos.Dirciten;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirciten
{
    public class EgresoPromociones
    {
        EgresoPromocionesDAO egresoPromocionesDAO = new();

        public List<EgresoPromocionesDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return egresoPromocionesDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EgresoPromocionesDTO egresoPromocionesDTO, string? fecha)
        {
            return egresoPromocionesDAO.AgregarRegistro(egresoPromocionesDTO, fecha);
        }

        public EgresoPromocionesDTO EditarFormato(int Codigo)
        {
            return egresoPromocionesDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EgresoPromocionesDTO egresoPromocionesDTO)
        {
            return egresoPromocionesDAO.ActualizaFormato(egresoPromocionesDTO);
        }

        public bool EliminarFormato(EgresoPromocionesDTO egresoPromocionesDTO)
        {
            return egresoPromocionesDAO.EliminarFormato(egresoPromocionesDTO);
        }

        public bool EliminarCarga(EgresoPromocionesDTO egresoPromocionesDTO)
        {
            return egresoPromocionesDAO.EliminarCarga(egresoPromocionesDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return egresoPromocionesDAO.InsertarDatos(datos, fecha);
        }

    }
}
