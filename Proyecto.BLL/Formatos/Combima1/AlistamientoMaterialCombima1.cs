using Marina.Siesmar.AccesoDatos.Formatos.Combima1;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Combima1;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combima1
{
    public class AlistamientoMaterialCombima1
    {
        AlistamientoMaterialCombima1DAO alistamientoMaterialCombima1DAO = new();

        public List<AlistamientoMaterialCombima1DTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoMaterialCombima1DAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoMaterialCombima1DTO alistamientoMaterialCombima1DTO, string? fecha)
        {
            return alistamientoMaterialCombima1DAO.AgregarRegistro(alistamientoMaterialCombima1DTO, fecha);
        }

        public AlistamientoMaterialCombima1DTO EditarFormato(int Codigo)
        {
            return alistamientoMaterialCombima1DAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialCombima1DTO alistamientoMaterialCombima1DTO)
        {
            return alistamientoMaterialCombima1DAO.ActualizaFormato(alistamientoMaterialCombima1DTO);
        }

        public bool EliminarFormato(AlistamientoMaterialCombima1DTO alistamientoMaterialCombima1DTO)
        {
            return alistamientoMaterialCombima1DAO.EliminarFormato(alistamientoMaterialCombima1DTO);
        }

        public bool EliminarCarga(AlistamientoMaterialCombima1DTO alistamientoMaterialCombima1DTO)
        {
            return alistamientoMaterialCombima1DAO.EliminarCarga(alistamientoMaterialCombima1DTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoMaterialCombima1DAO.InsertarDatos(datos, fecha);
        }

    }
}
