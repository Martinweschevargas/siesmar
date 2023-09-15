using Marina.Siesmar.AccesoDatos.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diabaste
{
    public class ConsumoRacionUnidadDependencia
    {
        ConsumoRacionUnidadDependenciaDAO consumoRacionUnidadDependenciaDAO = new();

        public List<ConsumoRacionUnidadDependenciaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return consumoRacionUnidadDependenciaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ConsumoRacionUnidadDependenciaDTO consumoRacionUnidadDependencia, string? fecha)
        {
            return consumoRacionUnidadDependenciaDAO.AgregarRegistro(consumoRacionUnidadDependencia, fecha);
        }

        public ConsumoRacionUnidadDependenciaDTO EditarFormado(int Codigo)
        {
            return consumoRacionUnidadDependenciaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ConsumoRacionUnidadDependenciaDTO consumoRacionUnidadDependenciaDTO)
        {
            return consumoRacionUnidadDependenciaDAO.ActualizaFormato(consumoRacionUnidadDependenciaDTO);
        }

        public bool EliminarFormato(ConsumoRacionUnidadDependenciaDTO consumoRacionUnidadDependenciaDTO)
        {
            return consumoRacionUnidadDependenciaDAO.EliminarFormato(consumoRacionUnidadDependenciaDTO);
        }

        public bool EliminarCarga(ConsumoRacionUnidadDependenciaDTO consumoRacionUnidadDependenciaDTO)
        {
            return consumoRacionUnidadDependenciaDAO.EliminarCarga(consumoRacionUnidadDependenciaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return consumoRacionUnidadDependenciaDAO.InsertarDatos(datos, fecha);
        }

    }
}
