using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class ConvenioUniversidadInstituto
    {
        ConvenioUniversidadInstitutoDAO conveniosUniversidadesInstitutosDAO = new();

        public List<ConvenioUniversidadInstitutoDTO> ObtenerLista(int? CargaId = null, string? fechaInicio = null, string? fechaFin = null)
        {
            return conveniosUniversidadesInstitutosDAO.ObtenerLista(CargaId, fechaInicio, fechaFin);
        }

        public List<ConvenioUniversidadInstitutoDTO> BienestarVisualizacionConvenioUniversidadInstituto(int? CargaId, string? fechaInicio = null, string? fechaFin = null)
        {
            return conveniosUniversidadesInstitutosDAO.BienestarVisualizacionConvenioUniversidadInstituto(CargaId, fechaInicio, fechaFin);
        }

        public string AgregarRegistro(ConvenioUniversidadInstitutoDTO conveniosUniversidadesInstitutosDTO, string fechaCarga)
        {
            return conveniosUniversidadesInstitutosDAO.AgregarRegistro(conveniosUniversidadesInstitutosDTO, fechaCarga);
        }

        public ConvenioUniversidadInstitutoDTO BuscarFormato(int Codigo)
        {
            return conveniosUniversidadesInstitutosDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ConvenioUniversidadInstitutoDTO conveniosUniversidadesInstitutosDTO)
        {
            return conveniosUniversidadesInstitutosDAO.ActualizaFormato(conveniosUniversidadesInstitutosDTO);
        }

        public bool EliminarFormato(ConvenioUniversidadInstitutoDTO conveniosUniversidadesInstitutosDTO)
        {
            return conveniosUniversidadesInstitutosDAO.EliminarFormato(conveniosUniversidadesInstitutosDTO);
        }

        public bool EliminarCarga(ConvenioUniversidadInstitutoDTO conveniosUniversidadesInstitutosDTO)
        {
            return conveniosUniversidadesInstitutosDAO.EliminarCarga(conveniosUniversidadesInstitutosDTO);
        }

        public string InsertarDatos(DataTable datos, string fechaCarga)
        {
            return conveniosUniversidadesInstitutosDAO.InsertarDatos(datos, fechaCarga);
        }


    }
}
