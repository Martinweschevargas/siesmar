
using Marina.Siesmar.AccesoDatos.Formatos.Comfasub;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfasub
{
    public class AlistamientoCombustibleLubricanteComfasub
    {
        AlistamientoCombustibleLubricanteComfasubDAO alistamientoCombustibleLubricanteComfasubDAO = new();

        public List<AlistamientoCombustibleLubricanteComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoCombustibleLubricanteComfasubDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteComfasubDTO alistamientoCombustibleLubricanteComfasubDTO, string? fecha)
        {
            return alistamientoCombustibleLubricanteComfasubDAO.AgregarRegistro(alistamientoCombustibleLubricanteComfasubDTO, fecha);
        }

        public AlistamientoCombustibleLubricanteComfasubDTO EditarFormado(int Codigo)
        {
            return alistamientoCombustibleLubricanteComfasubDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoCombustibleLubricanteComfasubDTO alistamientoCombustibleLubricanteComfasubDTO)
        {
            return alistamientoCombustibleLubricanteComfasubDAO.ActualizaFormato(alistamientoCombustibleLubricanteComfasubDTO);
        }

        public bool EliminarFormato(AlistamientoCombustibleLubricanteComfasubDTO alistamientoCombustibleLubricanteComfasubDTO)
        {
            return alistamientoCombustibleLubricanteComfasubDAO.EliminarFormato(alistamientoCombustibleLubricanteComfasubDTO);
        }

        public bool EliminarCarga(AlistamientoCombustibleLubricanteComfasubDTO alistamientoCombustibleLubricanteComfasubDTO)
        {
            return alistamientoCombustibleLubricanteComfasubDAO.EliminarCarga(alistamientoCombustibleLubricanteComfasubDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoCombustibleLubricanteComfasubDAO.InsertarDatos(datos, fecha);
        }

    }
}
