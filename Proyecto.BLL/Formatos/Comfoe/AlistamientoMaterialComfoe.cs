
using Marina.Siesmar.AccesoDatos.Formatos.Comfoe;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfoe;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfoe
{
    public class AlistamientoMaterialComfoe
    {
        AlistamientoMaterialComfoeDAO alistamientoMaterialComfoeDAO = new();

        public List<AlistamientoMaterialComfoeDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoMaterialComfoeDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoMaterialComfoeDTO alistamientoMaterialComfoeDTO, string? fecha)
        {
            return alistamientoMaterialComfoeDAO.AgregarRegistro(alistamientoMaterialComfoeDTO, fecha);
        }

        public AlistamientoMaterialComfoeDTO EditarFormado(int Codigo)
        {
            return alistamientoMaterialComfoeDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialComfoeDTO alistamientoMaterialComfoeDTO)
        {
            return alistamientoMaterialComfoeDAO.ActualizaFormato(alistamientoMaterialComfoeDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialComfoeDTO alistamientoMaterialComfoeDTO)
        {
            return alistamientoMaterialComfoeDAO.EliminarFormato(alistamientoMaterialComfoeDTO);
        }

        public bool EliminarCarga(AlistamientoMaterialComfoeDTO alistamientoMaterialComfoeDTO)
        {
            return alistamientoMaterialComfoeDAO.EliminarCarga(alistamientoMaterialComfoeDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoMaterialComfoeDAO.InsertarDatos(datos, fecha);
        }

    }
}
