using Marina.Siesmar.AccesoDatos.Formatos.Comfasub;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfasub
{
    public class PresupuestoComfasub
    {
        PresupuestoComfasubDAO presupuestoComfasubDAO = new();

        public List<PresupuestoComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return presupuestoComfasubDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(PresupuestoComfasubDTO presupuestoComfasub, string? fecha)
        {
            return presupuestoComfasubDAO.AgregarRegistro(presupuestoComfasub, fecha);
        }

        public PresupuestoComfasubDTO EditarFormado(int Codigo)
        {
            return presupuestoComfasubDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PresupuestoComfasubDTO presupuestoComfasubDTO)
        {
            return presupuestoComfasubDAO.ActualizaFormato(presupuestoComfasubDTO);
        }

        public bool EliminarFormato(PresupuestoComfasubDTO presupuestoComfasubDTO)
        {
            return presupuestoComfasubDAO.EliminarFormato( presupuestoComfasubDTO);
        }

        public bool EliminarCarga(PresupuestoComfasubDTO presupuestoComfasubDTO)
        {
            return presupuestoComfasubDAO.EliminarCarga(presupuestoComfasubDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return presupuestoComfasubDAO.InsertarDatos(datos, fecha);
        }

    }
}
