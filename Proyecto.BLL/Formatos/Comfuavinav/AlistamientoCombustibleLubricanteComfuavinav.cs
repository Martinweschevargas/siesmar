using Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav
{
    public class AlistamientoCombustibleLubricanteComfuavinav
    {
        AlistamientoCombustibleLubricanteComfuavinavDAO alistamientoCombustibleLubricanteComfuavinavDAO = new();

        public List<AlistamientoCombustibleLubricanteComfuavinavDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoCombustibleLubricanteComfuavinavDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteComfuavinavDTO alistamientoCombustibleLubricanteComfuavinavDTO, string? fecha)
        {
            return alistamientoCombustibleLubricanteComfuavinavDAO.AgregarRegistro(alistamientoCombustibleLubricanteComfuavinavDTO, fecha);
        }

        public AlistamientoCombustibleLubricanteComfuavinavDTO EditarFormado(int Codigo)
        {
            return alistamientoCombustibleLubricanteComfuavinavDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoCombustibleLubricanteComfuavinavDTO alistamientoCombustibleLubricanteComfuavinavDTO)
        {
            return alistamientoCombustibleLubricanteComfuavinavDAO.ActualizaFormato(alistamientoCombustibleLubricanteComfuavinavDTO);
        }

        public bool EliminarFormato(AlistamientoCombustibleLubricanteComfuavinavDTO alistamientoCombustibleLubricanteComfuavinavDTO)
        {
            return alistamientoCombustibleLubricanteComfuavinavDAO.EliminarFormato(alistamientoCombustibleLubricanteComfuavinavDTO);
        }

        public bool EliminarCarga(AlistamientoCombustibleLubricanteComfuavinavDTO alistamientoCombustibleLubricanteComfuavinavDTO)
        {
            return alistamientoCombustibleLubricanteComfuavinavDAO.EliminarCarga(alistamientoCombustibleLubricanteComfuavinavDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoCombustibleLubricanteComfuavinavDAO.InsertarDatos(datos, fecha);
        }

    }
}
