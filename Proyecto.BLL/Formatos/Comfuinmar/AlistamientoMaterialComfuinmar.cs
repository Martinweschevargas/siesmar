
using Marina.Siesmar.AccesoDatos.Formatos.Comfuinmar;
using Marina.Siesmar.Entidades.Formatos.Comfuinmar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuinmar
{
    public class AlistamientoMaterialComfuinmar
    {
        AlistamientoMaterialComfuinmarDAO alistamientoMaterialComfuinmarDAO = new();

        public List<AlistamientoMaterialComfuinmarDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoMaterialComfuinmarDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoMaterialComfuinmarDTO alistamientoMaterialComfuinmarDTO, string? fecha)
        {
            return alistamientoMaterialComfuinmarDAO.AgregarRegistro(alistamientoMaterialComfuinmarDTO, fecha);
        }

        public AlistamientoMaterialComfuinmarDTO EditarFormato(int Codigo)
        {
            return alistamientoMaterialComfuinmarDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialComfuinmarDTO alistamientoMaterialComfuinmarDTO)
        {
            return alistamientoMaterialComfuinmarDAO.ActualizaFormato(alistamientoMaterialComfuinmarDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialComfuinmarDTO alistamientoMaterialComfuinmarDTO)
        {
            return alistamientoMaterialComfuinmarDAO.EliminarFormato(alistamientoMaterialComfuinmarDTO);
        }

        public bool EliminarCarga(AlistamientoMaterialComfuinmarDTO alistamientoMaterialComfuinmarDTO)
        {
            return alistamientoMaterialComfuinmarDAO.EliminarCarga(alistamientoMaterialComfuinmarDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoMaterialComfuinmarDAO.InsertarDatos(datos, fecha);
        }
    }
}
