using Marina.Siesmar.AccesoDatos.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diabaste
{
    public class RepuestoBuque
    {
        RepuestoBuqueDAO repuestoBuqueDAO = new();

        public List<RepuestoBuqueDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return repuestoBuqueDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(RepuestoBuqueDTO repuestoBuque, string? fecha)
        {
            return repuestoBuqueDAO.AgregarRegistro(repuestoBuque, fecha);
        }

        public RepuestoBuqueDTO BuscarFormato(int Codigo)
        {
            return repuestoBuqueDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RepuestoBuqueDTO repuestoBuqueDTO)
        {
            return repuestoBuqueDAO.ActualizaFormato(repuestoBuqueDTO);
        }

        public bool EliminarFormato(RepuestoBuqueDTO repuestoBuqueDTO)
        {
            return repuestoBuqueDAO.EliminarFormato( repuestoBuqueDTO);
        }

        public bool EliminarCarga(RepuestoBuqueDTO repuestoBuqueDTO)
        {
            return repuestoBuqueDAO.EliminarCarga(repuestoBuqueDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return repuestoBuqueDAO.InsertarDatos(datos, fecha);
        }

    }
}
