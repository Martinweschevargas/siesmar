
using Marina.Siesmar.AccesoDatos.Formatos.Comfoe;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfoe;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfoe
{
    public class AlistamientoMunicionComfoe
    {
        AlistamientoMunicionComfoeDAO alistamientoMunicionComfoeDAO = new();

        public List<AlistamientoMunicionComfoeDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoMunicionComfoeDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoMunicionComfoeDTO alistamientoMunicionComfoeDTO, string? fecha)
        {
            return alistamientoMunicionComfoeDAO.AgregarRegistro(alistamientoMunicionComfoeDTO, fecha);
        }

        public AlistamientoMunicionComfoeDTO EditarFormado(int Codigo)
        {
            return alistamientoMunicionComfoeDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMunicionComfoeDTO alistamientoMunicionComfoeDTO)
        {
            return alistamientoMunicionComfoeDAO.ActualizaFormato(alistamientoMunicionComfoeDTO);
        }

        public bool EliminarFormato(AlistamientoMunicionComfoeDTO alistamientoMunicionComfoeDTO)
        {
            return alistamientoMunicionComfoeDAO.EliminarFormato(alistamientoMunicionComfoeDTO);
        }

        public bool EliminarCarga(AlistamientoMunicionComfoeDTO alistamientoMunicionComfoeDTO)
        {
            return alistamientoMunicionComfoeDAO.EliminarCarga(alistamientoMunicionComfoeDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoMunicionComfoeDAO.InsertarDatos(datos, fecha);
        }

    }
}
