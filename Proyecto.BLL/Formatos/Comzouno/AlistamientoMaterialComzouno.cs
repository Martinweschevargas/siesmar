
using Marina.Siesmar.AccesoDatos.Formatos.Comzouno;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzouno
{
    public class AlistamientoMaterialComzouno
    {
        AlistamientoMaterialComzounoDAO alistamientoMaterialComzounoDAO = new();

        public List<AlistamientoMaterialComzounoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoMaterialComzounoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoMaterialComzounoDTO alistamientoMaterialComzounoDTO, string? fecha = null)
        {
            return alistamientoMaterialComzounoDAO.AgregarRegistro(alistamientoMaterialComzounoDTO, fecha);
        }

        public AlistamientoMaterialComzounoDTO EditarFormado(int Codigo)
        {
            return alistamientoMaterialComzounoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialComzounoDTO alistamientoMaterialComzounoDTO)
        {
            return alistamientoMaterialComzounoDAO.ActualizaFormato(alistamientoMaterialComzounoDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialComzounoDTO alistamientoMaterialComzounoDTO)
        {
            return alistamientoMaterialComzounoDAO.EliminarFormato(alistamientoMaterialComzounoDTO);
        }

        public bool EliminarCarga(AlistamientoMaterialComzounoDTO alistamientoMaterialComzounoDTO)
        {
            return alistamientoMaterialComzounoDAO.EliminarCarga(alistamientoMaterialComzounoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoMaterialComzounoDAO.InsertarDatos(datos, fecha);
        }

    }
}
