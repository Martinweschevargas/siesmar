using Marina.Siesmar.AccesoDatos.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diabaste
{
    public class ConsumoCombustible
    {
        ConsumoCombustibleDAO consumoCombustibleDAO = new();

        public List<ConsumoCombustibleDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return consumoCombustibleDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ConsumoCombustibleDTO consumoCombustible, string? fecha)
        {
            return consumoCombustibleDAO.AgregarRegistro(consumoCombustible, fecha);
        }

        public ConsumoCombustibleDTO EditarFormado(int Codigo)
        {
            return consumoCombustibleDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ConsumoCombustibleDTO consumoCombustibleDTO)
        {
            return consumoCombustibleDAO.ActualizaFormato(consumoCombustibleDTO);
        }

        public bool EliminarFormato(ConsumoCombustibleDTO consumoCombustibleDTO)
        {
            return consumoCombustibleDAO.EliminarFormato(consumoCombustibleDTO);
        }

        public bool EliminarCarga(ConsumoCombustibleDTO consumoCombustibleDTO)
        {
            return consumoCombustibleDAO.EliminarCarga(consumoCombustibleDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return consumoCombustibleDAO.InsertarDatos(datos, fecha);
        }

    }
}
