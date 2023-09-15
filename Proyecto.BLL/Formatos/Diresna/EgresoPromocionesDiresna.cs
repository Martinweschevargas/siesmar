using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Diresna;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresna;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diresna
{
    public class EgresoPromocionesDiresna
    {
        EgresoPromocionesDiresnaDAO egresoPromocionesDiresnaDAO = new();

        public List<EgresoPromocionesDiresnaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return egresoPromocionesDiresnaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EgresoPromocionesDiresnaDTO egresoPromocionesDiresnaDTO, string? fecha = null)
        {
            return egresoPromocionesDiresnaDAO.AgregarRegistro(egresoPromocionesDiresnaDTO, fecha);
        }

        public EgresoPromocionesDiresnaDTO EditarFormato(int Codigo)
        {
            return egresoPromocionesDiresnaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EgresoPromocionesDiresnaDTO egresoPromocionesDiresnaDTO)
        {
            return egresoPromocionesDiresnaDAO.ActualizaFormato(egresoPromocionesDiresnaDTO);
        }

        public bool EliminarFormato(EgresoPromocionesDiresnaDTO egresoPromocionesDiresnaDTO)
        {
            return egresoPromocionesDiresnaDAO.EliminarFormato(egresoPromocionesDiresnaDTO);
        }

        public bool EliminarCarga(EgresoPromocionesDiresnaDTO egresoPromocionesDiresnaDTO)
        {
            return egresoPromocionesDiresnaDAO.EliminarCarga(egresoPromocionesDiresnaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return egresoPromocionesDiresnaDAO.InsertarDatos(datos, fecha);
        }
    }
}
