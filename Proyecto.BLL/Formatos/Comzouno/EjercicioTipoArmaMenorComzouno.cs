using Marina.Siesmar.AccesoDatos.Formatos.Comzouno;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzouno
{
    public class EjercicioTipoArmaMenorComzouno
    {
        EjercicioTipoArmaMenorComzounoDAO ejercicioTipoArmaMenorComzounoDAO = new();

        public List<EjercicioTipoArmaMenorComzounoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return ejercicioTipoArmaMenorComzounoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EjercicioTipoArmaMenorComzounoDTO ejercicioTipoArmaMenorComzouno, string? fecha = null)
        {
            return ejercicioTipoArmaMenorComzounoDAO.AgregarRegistro(ejercicioTipoArmaMenorComzouno, fecha);
        }

        public EjercicioTipoArmaMenorComzounoDTO EditarFormado(int Codigo)
        {
            return ejercicioTipoArmaMenorComzounoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EjercicioTipoArmaMenorComzounoDTO ejercicioTipoArmaMenorComzounoDTO)
        {
            return ejercicioTipoArmaMenorComzounoDAO.ActualizaFormato(ejercicioTipoArmaMenorComzounoDTO);
        }

        public bool EliminarFormato(EjercicioTipoArmaMenorComzounoDTO ejercicioTipoArmaMenorComzounoDTO)
        {
            return ejercicioTipoArmaMenorComzounoDAO.EliminarFormato( ejercicioTipoArmaMenorComzounoDTO);
        }

        public bool EliminarCarga(EjercicioTipoArmaMenorComzounoDTO ejercicioTipoArmaMenorComzounoDTO)
        {
            return ejercicioTipoArmaMenorComzounoDAO.EliminarCarga(ejercicioTipoArmaMenorComzounoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return ejercicioTipoArmaMenorComzounoDAO.InsertarDatos(datos, fecha);
        }
    }
}
