using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Diresna;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresna;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diresna
{
    public class DocenteEsna
    {
        DocenteEsnaDAO docenteEsnaDAO = new();

        public List<DocenteEsnaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return docenteEsnaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(DocenteEsnaDTO docenteEsnaDTO, string? fecha = null)
        {
            return docenteEsnaDAO.AgregarRegistro(docenteEsnaDTO, fecha);
        }

        public DocenteEsnaDTO EditarFormato(int Codigo)
        {
            return docenteEsnaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(DocenteEsnaDTO docenteEsnaDTO)
        {
            return docenteEsnaDAO.ActualizaFormato(docenteEsnaDTO);
        }

        public bool EliminarFormato(DocenteEsnaDTO docenteEsnaDTO)
        {
            return docenteEsnaDAO.EliminarFormato(docenteEsnaDTO);
        }

        public bool EliminarCarga(DocenteEsnaDTO docenteEsnaDTO)
        {
            return docenteEsnaDAO.EliminarCarga(docenteEsnaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return docenteEsnaDAO.InsertarDatos(datos, fecha);
        }

    }
}
