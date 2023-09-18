using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class HospedajeAdultoMayor
    {
        HospedajeAdultoMayorDAO hospedajeAdultoMayorDAO = new();

        public List<HospedajeAdultoMayorDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return hospedajeAdultoMayorDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public List<HospedajeAdultoMayorDTO> BienestarVisualizacionHospedajeAdultoMayor(int CargaId)
        {
            return hospedajeAdultoMayorDAO.BienestarVisualizacionHospedajeAdultoMayor(CargaId);
        }

        public string AgregarRegistro(HospedajeAdultoMayorDTO hospedajeAdultoMayorDTO, string? fecha)
        {
            return hospedajeAdultoMayorDAO.AgregarRegistro(hospedajeAdultoMayorDTO,fecha);
        }

        public HospedajeAdultoMayorDTO EditarFormato(int Codigo)
        {
            return hospedajeAdultoMayorDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(HospedajeAdultoMayorDTO hospedajeAdultoMayorDTO)
        {
            return hospedajeAdultoMayorDAO.ActualizaFormato(hospedajeAdultoMayorDTO);
        }

        public bool EliminarFormato(HospedajeAdultoMayorDTO hospedajeAdultoMayorDTO)
        {
            return hospedajeAdultoMayorDAO.EliminarFormato(hospedajeAdultoMayorDTO);
        }

        public bool EliminarCarga(HospedajeAdultoMayorDTO hospedajeAdultoMayorDTO)
        {
            return hospedajeAdultoMayorDAO.EliminarCarga(hospedajeAdultoMayorDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return hospedajeAdultoMayorDAO.InsertarDatos(datos, fecha);
        }


    }
}
