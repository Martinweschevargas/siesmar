
using Marina.Siesmar.AccesoDatos.Formatos.Comzouno;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzouno
{
    public class AlistamientoCombustibleLubricanteComzouno
    {
        AlistamientoCombustibleLubricanteComzounoDAO alistamientoCombustibleLubricanteComzounoDAO = new();

        public List<AlistamientoCombustibleLubricanteComzounoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoCombustibleLubricanteComzounoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteComzounoDTO alistamientoCombustibleLubricanteComzounoDTO, string? fecha=null)
        {
            return alistamientoCombustibleLubricanteComzounoDAO.AgregarRegistro(alistamientoCombustibleLubricanteComzounoDTO, fecha);
        }

        public AlistamientoCombustibleLubricanteComzounoDTO EditarFormado(int Codigo)
        {
            return alistamientoCombustibleLubricanteComzounoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoCombustibleLubricanteComzounoDTO alistamientoCombustibleLubricanteComzounoDTO)
        {
            return alistamientoCombustibleLubricanteComzounoDAO.ActualizaFormato(alistamientoCombustibleLubricanteComzounoDTO);
        }

        public bool EliminarFormato(AlistamientoCombustibleLubricanteComzounoDTO alistamientoCombustibleLubricanteComzounoDTO)
        {
            return alistamientoCombustibleLubricanteComzounoDAO.EliminarFormato(alistamientoCombustibleLubricanteComzounoDTO);
        }

        public bool EliminarCarga(AlistamientoCombustibleLubricanteComzounoDTO alistamientoCombustibleLubricanteComzounoDTO)
        {
            return alistamientoCombustibleLubricanteComzounoDAO.EliminarCarga(alistamientoCombustibleLubricanteComzounoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoCombustibleLubricanteComzounoDAO.InsertarDatos(datos, fecha);
        }

    }
}
