using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class MaterialRecreacionEntretenamiento
    {
        MaterialRecreacionEntretenamientoDAO materialRecreacionEntretenamientoDAO = new();

        public List<MaterialRecreacionEntretenamientoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return materialRecreacionEntretenamientoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public List<MaterialRecreacionEntretenamientoDTO> BienestarVisualizacionMaterialRecreacionEntretenmiento(int? CargaId=null, string? fechaInicio= null, string? fechaFin=null)
        {
            return materialRecreacionEntretenamientoDAO.BienestarVisualizacionMaterialRecreacionEntretenmiento(CargaId, fechaInicio, fechaFin);
        }

        public string AgregarRegistro(MaterialRecreacionEntretenamientoDTO materialRecreacionEntretenamientoDTO, string fecha)
        {
            return materialRecreacionEntretenamientoDAO.AgregarRegistro(materialRecreacionEntretenamientoDTO, fecha);
        }

        public MaterialRecreacionEntretenamientoDTO EditarFormato(int Codigo)
        {
            return materialRecreacionEntretenamientoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(MaterialRecreacionEntretenamientoDTO materialRecreacionEntretenamientoDTO)
        {
            return materialRecreacionEntretenamientoDAO.ActualizaFormato(materialRecreacionEntretenamientoDTO);
        }

        public bool EliminarFormato(MaterialRecreacionEntretenamientoDTO materialRecreacionEntretenamientoDTO)
        {
            return materialRecreacionEntretenamientoDAO.EliminarFormato(materialRecreacionEntretenamientoDTO);
        }

        public bool EliminarCarga(MaterialRecreacionEntretenamientoDTO materialRecreacionEntretenamientoDTO)
        {
            return materialRecreacionEntretenamientoDAO.EliminarCarga(materialRecreacionEntretenamientoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return materialRecreacionEntretenamientoDAO.InsertarDatos(datos, fecha);
        }

    }
}
