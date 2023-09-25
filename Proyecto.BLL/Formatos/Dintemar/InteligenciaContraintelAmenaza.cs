using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dintemar
{
    public class InteligenciaContraintelAmenaza
    {
        InteligenciaContraintelAmenazaDAO inteligenciaContraintelAmenazaDAO = new();

        public List<InteligenciaContraintelAmenazaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return inteligenciaContraintelAmenazaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(InteligenciaContraintelAmenazaDTO inteligenciaContraintelAmenazaDTO)
        {
            return inteligenciaContraintelAmenazaDAO.AgregarRegistro(inteligenciaContraintelAmenazaDTO);
        }

        public InteligenciaContraintelAmenazaDTO EditarFormato(int Codigo)
        {
            return inteligenciaContraintelAmenazaDAO.BuscarFormato(Codigo);
        }

        public bool EliminarCarga(InteligenciaContraintelAmenazaDTO inteligenciaContraintelAmenazaDTO)
        {
            return inteligenciaContraintelAmenazaDAO.EliminarCarga(inteligenciaContraintelAmenazaDTO);
        }

        public string ActualizarFormato(InteligenciaContraintelAmenazaDTO inteligenciaContraintelAmenazaDTO)
        {
            return inteligenciaContraintelAmenazaDAO.ActualizaFormato(inteligenciaContraintelAmenazaDTO);
        }

        public bool EliminarFormato(InteligenciaContraintelAmenazaDTO inteligenciaContraintelAmenazaDTO)
        {
            return inteligenciaContraintelAmenazaDAO.EliminarFormato(inteligenciaContraintelAmenazaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return inteligenciaContraintelAmenazaDAO.InsertarDatos(datos, fecha);
        }

    }
}
