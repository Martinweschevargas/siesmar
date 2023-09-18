using Marina.Siesmar.AccesoDatos.Formatos.Comzotres;
using Marina.Siesmar.Entidades.Formatos.Comzotres;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzotres
{
    public class AlistamientoMaterialComzotres
    {
        AlistamientoMaterialComzotresDAO alistamientoMaterialComzotresDAO = new();

        public List<AlistamientoMaterialComzotresDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoMaterialComzotresDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoMaterialComzotresDTO alistamientoMaterialComzotresDTO, string? fecha)
        {
            return alistamientoMaterialComzotresDAO.AgregarRegistro(alistamientoMaterialComzotresDTO, fecha);
        }

        public AlistamientoMaterialComzotresDTO EditarFormato(int Codigo)
        {
            return alistamientoMaterialComzotresDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialComzotresDTO alistamientoMaterialComzotresDTO)
        {
            return alistamientoMaterialComzotresDAO.ActualizaFormato(alistamientoMaterialComzotresDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialComzotresDTO alistamientoMaterialComzotresDTO)
        {
            return alistamientoMaterialComzotresDAO.EliminarFormato(alistamientoMaterialComzotresDTO);
        }

        public bool EliminarCarga(AlistamientoMaterialComzotresDTO alistamientoMaterialComzotresDTO)
        {
            return alistamientoMaterialComzotresDAO.EliminarCarga(alistamientoMaterialComzotresDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoMaterialComzotresDAO.InsertarDatos(datos, fecha);
        }

    }
}
