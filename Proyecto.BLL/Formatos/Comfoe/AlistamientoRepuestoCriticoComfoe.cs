
using Marina.Siesmar.AccesoDatos.Formatos.Comfoe;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfoe;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfoe
{
    public class AlistamientoRepuestoCriticoComfoe
    {
        AlistamientoRepuestoCriticoComfoeDAO alistamientoRepuestoCriticoComfoeDAO = new();

        public List<AlistamientoRepuestoCriticoComfoeDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoRepuestoCriticoComfoeDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoRepuestoCriticoComfoeDTO alistamientoRepuestoCriticoComfoeDTO, string? fecha)
        {
            return alistamientoRepuestoCriticoComfoeDAO.AgregarRegistro(alistamientoRepuestoCriticoComfoeDTO, fecha);
        }

        public AlistamientoRepuestoCriticoComfoeDTO EditarFormado(int Codigo)
        {
            return alistamientoRepuestoCriticoComfoeDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoRepuestoCriticoComfoeDTO alistamientoRepuestoCriticoComfoeDTO)
        {
            return alistamientoRepuestoCriticoComfoeDAO.ActualizaFormato(alistamientoRepuestoCriticoComfoeDTO);
        }

        public bool EliminarFormato(AlistamientoRepuestoCriticoComfoeDTO alistamientoRepuestoCriticoComfoeDTO)
        {
            return alistamientoRepuestoCriticoComfoeDAO.EliminarFormato(alistamientoRepuestoCriticoComfoeDTO);
        }

        public bool EliminarCarga(AlistamientoRepuestoCriticoComfoeDTO alistamientoRepuestoCriticoComfoeDTO)
        {
            return alistamientoRepuestoCriticoComfoeDAO.EliminarCarga(alistamientoRepuestoCriticoComfoeDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoRepuestoCriticoComfoeDAO.InsertarDatos(datos, fecha);
        }

    }
}
