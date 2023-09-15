
using Marina.Siesmar.AccesoDatos.Formatos.Comfasub;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfasub
{
    public class AlistamientoMaterialComfasub
    {
        AlistamientoMaterialComfasubDAO alistamientoMaterialComfasubDAO = new();

        public List<AlistamientoMaterialComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoMaterialComfasubDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoMaterialComfasubDTO alistamientoMaterialComfasubDTO, string? fecha)
        {
            return alistamientoMaterialComfasubDAO.AgregarRegistro(alistamientoMaterialComfasubDTO, fecha);
        }

        public AlistamientoMaterialComfasubDTO EditarFormado(int Codigo)
        {
            return alistamientoMaterialComfasubDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialComfasubDTO alistamientoMaterialComfasubDTO)
        {
            return alistamientoMaterialComfasubDAO.ActualizaFormato(alistamientoMaterialComfasubDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialComfasubDTO alistamientoMaterialComfasubDTO)
        {
            return alistamientoMaterialComfasubDAO.EliminarFormato(alistamientoMaterialComfasubDTO);
        }

        public bool EliminarCarga(AlistamientoMaterialComfasubDTO alistamientoMaterialComfasubDTO)
        {
            return alistamientoMaterialComfasubDAO.EliminarCarga(alistamientoMaterialComfasubDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoMaterialComfasubDAO.InsertarDatos(datos, fecha);
        }

    }
}
