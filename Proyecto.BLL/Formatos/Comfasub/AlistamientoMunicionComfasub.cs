
using Marina.Siesmar.AccesoDatos.Formatos.Comfasub;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfasub
{
    public class AlistamientoMunicionComfasub
    {
        AlistamientoMunicionComfasubDAO alistamientoMunicionComfasubDAO = new();

        public List<AlistamientoMunicionComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoMunicionComfasubDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoMunicionComfasubDTO alistamientoMunicionComfasubDTO, string? fecha)
        {
            return alistamientoMunicionComfasubDAO.AgregarRegistro(alistamientoMunicionComfasubDTO, fecha);
        }

        public AlistamientoMunicionComfasubDTO EditarFormado(int Codigo)
        {
            return alistamientoMunicionComfasubDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMunicionComfasubDTO alistamientoMunicionComfasubDTO)
        {
            return alistamientoMunicionComfasubDAO.ActualizaFormato(alistamientoMunicionComfasubDTO);
        }

        public bool EliminarFormato(AlistamientoMunicionComfasubDTO alistamientoMunicionComfasubDTO)
        {
            return alistamientoMunicionComfasubDAO.EliminarFormato(alistamientoMunicionComfasubDTO);
        }

        public bool EliminarCarga(AlistamientoMunicionComfasubDTO alistamientoMunicionComfasubDTO)
        {
            return alistamientoMunicionComfasubDAO.EliminarCarga(alistamientoMunicionComfasubDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoMunicionComfasubDAO.InsertarDatos(datos, fecha);
        }

    }
}
