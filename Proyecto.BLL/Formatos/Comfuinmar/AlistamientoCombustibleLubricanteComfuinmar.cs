
using Marina.Siesmar.AccesoDatos.Formatos.Comfuinmar;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfuinmar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuinmar
{
    public class AlistamientoCombustibleLubricanteComfuinmar
    {
        AlistamientoCombustibleLubricanteComfuinmarDAO alistamientoCombustibleLubricanteComfuinmarDAO = new();

        public List<AlistamientoCombustibleLubricanteComfuinmarDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoCombustibleLubricanteComfuinmarDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteComfuinmarDTO alistamientoCombustibleLubricanteComfuinmarDTO, string? fecha)
        {
            return alistamientoCombustibleLubricanteComfuinmarDAO.AgregarRegistro(alistamientoCombustibleLubricanteComfuinmarDTO, fecha);
        }

        public AlistamientoCombustibleLubricanteComfuinmarDTO EditarFormato(int Codigo)
        {
            return alistamientoCombustibleLubricanteComfuinmarDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoCombustibleLubricanteComfuinmarDTO alistamientoCombustibleLubricanteComfuinmarDTO)
        {
            return alistamientoCombustibleLubricanteComfuinmarDAO.ActualizaFormato(alistamientoCombustibleLubricanteComfuinmarDTO);
        }

        public bool EliminarFormato(AlistamientoCombustibleLubricanteComfuinmarDTO alistamientoCombustibleLubricanteComfuinmarDTO)
        {
            return alistamientoCombustibleLubricanteComfuinmarDAO.EliminarFormato(alistamientoCombustibleLubricanteComfuinmarDTO);
        }

        public bool EliminarCarga(AlistamientoCombustibleLubricanteComfuinmarDTO alistamientoCombustibleLubricanteComfuinmarDTO)
        {
            return alistamientoCombustibleLubricanteComfuinmarDAO.EliminarCarga(alistamientoCombustibleLubricanteComfuinmarDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoCombustibleLubricanteComfuinmarDAO.InsertarDatos(datos, fecha);
        }

    }
}
