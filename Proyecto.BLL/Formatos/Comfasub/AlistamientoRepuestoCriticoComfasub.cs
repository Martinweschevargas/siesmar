
using Marina.Siesmar.AccesoDatos.Formatos.Comfasub;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfasub
{
    public class AlistamientoRepuestoCriticoComfasub
    {
        AlistamientoRepuestoCriticoComfasubDAO alistamientoRepuestoCriticoComfasubDAO = new();

        public List<AlistamientoRepuestoCriticoComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoRepuestoCriticoComfasubDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoRepuestoCriticoComfasubDTO alistamientoRepuestoCriticoComfasubDTO, string? fecha)
        {
            return alistamientoRepuestoCriticoComfasubDAO.AgregarRegistro(alistamientoRepuestoCriticoComfasubDTO, fecha);
        }

        public AlistamientoRepuestoCriticoComfasubDTO EditarFormado(int Codigo)
        {
            return alistamientoRepuestoCriticoComfasubDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoRepuestoCriticoComfasubDTO alistamientoRepuestoCriticoComfasubDTO)
        {
            return alistamientoRepuestoCriticoComfasubDAO.ActualizaFormato(alistamientoRepuestoCriticoComfasubDTO);
        }

        public bool EliminarFormato(AlistamientoRepuestoCriticoComfasubDTO alistamientoRepuestoCriticoComfasubDTO)
        {
            return alistamientoRepuestoCriticoComfasubDAO.EliminarFormato(alistamientoRepuestoCriticoComfasubDTO);
        }

        public bool EliminarCarga(AlistamientoRepuestoCriticoComfasubDTO alistamientoRepuestoCriticoComfasubDTO)
        {
            return alistamientoRepuestoCriticoComfasubDAO.EliminarCarga(alistamientoRepuestoCriticoComfasubDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoRepuestoCriticoComfasubDAO.InsertarDatos(datos, fecha);
        }

    }
}
