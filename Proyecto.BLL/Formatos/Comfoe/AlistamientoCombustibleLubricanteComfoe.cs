
using Marina.Siesmar.AccesoDatos.Formatos.Comfoe;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfoe;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfoe
{
    public class AlistamientoCombustibleLubricanteComfoe
    {
        AlistamientoCombustibleLubricanteComfoeDAO alistamientoCombustibleLubricanteComfoeDAO = new();

        public List<AlistamientoCombustibleLubricanteComfoeDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoCombustibleLubricanteComfoeDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteComfoeDTO alistamientoCombustibleLubricanteComfoeDTO, string? fecha)
        {
            return alistamientoCombustibleLubricanteComfoeDAO.AgregarRegistro(alistamientoCombustibleLubricanteComfoeDTO, fecha);
        }

        public AlistamientoCombustibleLubricanteComfoeDTO EditarFormado(int Codigo)
        {
            return alistamientoCombustibleLubricanteComfoeDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoCombustibleLubricanteComfoeDTO alistamientoCombustibleLubricanteComfoeDTO)
        {
            return alistamientoCombustibleLubricanteComfoeDAO.ActualizaFormato(alistamientoCombustibleLubricanteComfoeDTO);
        }

        public bool EliminarFormato(AlistamientoCombustibleLubricanteComfoeDTO alistamientoCombustibleLubricanteComfoeDTO)
        {
            return alistamientoCombustibleLubricanteComfoeDAO.EliminarFormato(alistamientoCombustibleLubricanteComfoeDTO);
        }

        public bool EliminarCarga(AlistamientoCombustibleLubricanteComfoeDTO alistamientoCombustibleLubricanteComfoeDTO)
        {
            return alistamientoCombustibleLubricanteComfoeDAO.EliminarCarga(alistamientoCombustibleLubricanteComfoeDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoCombustibleLubricanteComfoeDAO.InsertarDatos(datos, fecha);
        }

    }
}
