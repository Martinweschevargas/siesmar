using Marina.Siesmar.AccesoDatos.Formatos.Comzodos;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comzodos;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzodos
{
    public class CantidadInspeccionTID
    {
        CantidadInspeccionTIDDAO cantidadInspeccionTIDDAO = new();

        public List<CantidadInspeccionTIDDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return cantidadInspeccionTIDDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(CantidadInspeccionTIDDTO cantidadInspeccionTID, string? fecha = null)
        {
            return cantidadInspeccionTIDDAO.AgregarRegistro(cantidadInspeccionTID, fecha);
        }

        public CantidadInspeccionTIDDTO BuscarFormato(int Codigo)
        {
            return cantidadInspeccionTIDDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CantidadInspeccionTIDDTO cantidadInspeccionTIDDTO)
        {
            return cantidadInspeccionTIDDAO.ActualizaFormato(cantidadInspeccionTIDDTO);
        }

        public bool EliminarFormato(CantidadInspeccionTIDDTO cantidadInspeccionTIDDTO)
        {
            return cantidadInspeccionTIDDAO.EliminarFormato( cantidadInspeccionTIDDTO);
        }

        public bool EliminarCarga(CantidadInspeccionTIDDTO cantidadInspeccionTIDDTO)
        {
            return cantidadInspeccionTIDDAO.EliminarCarga(cantidadInspeccionTIDDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return cantidadInspeccionTIDDAO.InsertarDatos(datos, fecha);
        }

    }
}
