using Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav
{
    public class AlistamientoMunicionComfuavinav
    {
        AlistamientoMunicionComfuavinavDAO alistamientoMunicionComfuavinavDAO = new();

        public List<AlistamientoMunicionComfuavinavDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoMunicionComfuavinavDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoMunicionComfuavinavDTO alistamientoMunicionComfuavinavDTO, string? fecha)
        {
            return alistamientoMunicionComfuavinavDAO.AgregarRegistro(alistamientoMunicionComfuavinavDTO, fecha);
        }

        public AlistamientoMunicionComfuavinavDTO EditarFormado(int Codigo)
        {
            return alistamientoMunicionComfuavinavDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMunicionComfuavinavDTO alistamientoMunicionComfuavinavDTO)
        {
            return alistamientoMunicionComfuavinavDAO.ActualizaFormato(alistamientoMunicionComfuavinavDTO);
        }

        public bool EliminarFormato(AlistamientoMunicionComfuavinavDTO alistamientoMunicionComfuavinavDTO)
        {
            return alistamientoMunicionComfuavinavDAO.EliminarFormato(alistamientoMunicionComfuavinavDTO);
        }

        public bool EliminarCarga(AlistamientoMunicionComfuavinavDTO alistamientoMunicionComfuavinavDTO)
        {
            return alistamientoMunicionComfuavinavDAO.EliminarCarga(alistamientoMunicionComfuavinavDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoMunicionComfuavinavDAO.InsertarDatos(datos, fecha);
        }

    }
}