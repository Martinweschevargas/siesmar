
using Marina.Siesmar.AccesoDatos.Formatos.Comfuinmar;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfuinmar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuinmar
{
    public class AlistamientoRepuestoCriticoComfuinmar
    {
        AlistamientoRepuestoCriticoComfuinmarDAO alistamientoRepuestoCriticoComfuinmarDAO = new();

        public List<AlistamientoRepuestoCriticoComfuinmarDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoRepuestoCriticoComfuinmarDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoRepuestoCriticoComfuinmarDTO alistamientoRepuestoCriticoComfuinmarDTO, string? fecha)
        {
            return alistamientoRepuestoCriticoComfuinmarDAO.AgregarRegistro(alistamientoRepuestoCriticoComfuinmarDTO, fecha);
        }

        public AlistamientoRepuestoCriticoComfuinmarDTO EditarFormato(int Codigo)
        {
            return alistamientoRepuestoCriticoComfuinmarDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoRepuestoCriticoComfuinmarDTO alistamientoRepuestoCriticoComfuinmarDTO)
        {
            return alistamientoRepuestoCriticoComfuinmarDAO.ActualizaFormato(alistamientoRepuestoCriticoComfuinmarDTO);
        }

        public bool EliminarFormato(AlistamientoRepuestoCriticoComfuinmarDTO alistamientoRepuestoCriticoComfuinmarDTO)
        {
            return alistamientoRepuestoCriticoComfuinmarDAO.EliminarFormato(alistamientoRepuestoCriticoComfuinmarDTO);
        }

        public bool EliminarCarga(AlistamientoRepuestoCriticoComfuinmarDTO alistamientoRepuestoCriticoComfuinmarDTO)
        {
            return alistamientoRepuestoCriticoComfuinmarDAO.EliminarCarga(alistamientoRepuestoCriticoComfuinmarDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoRepuestoCriticoComfuinmarDAO.InsertarDatos(datos, fecha);
        }

    }
}
