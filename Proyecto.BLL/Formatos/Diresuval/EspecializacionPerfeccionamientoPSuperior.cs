using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Diresuval;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresuval;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diresuval
{
    public class EspecializacionPerfeccionamientoPSuperior
    {
        EspecializacionPerfeccionamientoPSuperiorDAO especializacionPerfecPSuperiorDAO = new();

        public List<EspecializacionPerfeccionamientoPSuperiorDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return especializacionPerfecPSuperiorDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EspecializacionPerfeccionamientoPSuperiorDTO especializacionPerfecPSuperiorDTO, string? fecha = null)
        {
            return especializacionPerfecPSuperiorDAO.AgregarRegistro(especializacionPerfecPSuperiorDTO, fecha);
        }

        public EspecializacionPerfeccionamientoPSuperiorDTO BuscarFormato(int Codigo)
        {
            return especializacionPerfecPSuperiorDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EspecializacionPerfeccionamientoPSuperiorDTO especializacionPerfecPSuperiorDTO)
        {
            return especializacionPerfecPSuperiorDAO.ActualizaFormato(especializacionPerfecPSuperiorDTO);
        }

        public bool EliminarFormato(EspecializacionPerfeccionamientoPSuperiorDTO especializacionPerfecPSuperiorDTO)
        {
            return especializacionPerfecPSuperiorDAO.EliminarFormato(especializacionPerfecPSuperiorDTO);
        }

        public bool EliminarCarga(EspecializacionPerfeccionamientoPSuperiorDTO especializacionPerfecPSuperiorDTO)
        {
            return especializacionPerfecPSuperiorDAO.EliminarCarga(especializacionPerfecPSuperiorDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return especializacionPerfecPSuperiorDAO.InsertarDatos(datos, fecha);
        }

    }
}
