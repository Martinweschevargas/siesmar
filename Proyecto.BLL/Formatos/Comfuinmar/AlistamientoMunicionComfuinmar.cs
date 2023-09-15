
using Marina.Siesmar.AccesoDatos.Formatos.Comfuinmar;
using Marina.Siesmar.Entidades.Formatos.Comfuinmar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuinmar
{
    public class AlistamientoMunicionComfuinmar
    {
        AlistamientoMunicionComfuinmarDAO alistamientoMunicionComfuinmarDAO = new();

        public List<AlistamientoMunicionComfuinmarDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoMunicionComfuinmarDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoMunicionComfuinmarDTO alistamientoMunicionComfuinmarDTO, string? fecha)
        {
            return alistamientoMunicionComfuinmarDAO.AgregarRegistro(alistamientoMunicionComfuinmarDTO, fecha);
        }

        public AlistamientoMunicionComfuinmarDTO EditarFormato(int Codigo)
        {
            return alistamientoMunicionComfuinmarDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMunicionComfuinmarDTO alistamientoMunicionComfuinmarDTO)
        {
            return alistamientoMunicionComfuinmarDAO.ActualizaFormato(alistamientoMunicionComfuinmarDTO);
        }

        public bool EliminarFormato(AlistamientoMunicionComfuinmarDTO alistamientoMunicionComfuinmarDTO)
        {
            return alistamientoMunicionComfuinmarDAO.EliminarFormato(alistamientoMunicionComfuinmarDTO);
        }

        public bool EliminarCarga(AlistamientoMunicionComfuinmarDTO alistamientoMunicionComfuinmarDTO)
        {
            return alistamientoMunicionComfuinmarDAO.EliminarCarga(alistamientoMunicionComfuinmarDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoMunicionComfuinmarDAO.InsertarDatos(datos, fecha);
        }
    }
}
