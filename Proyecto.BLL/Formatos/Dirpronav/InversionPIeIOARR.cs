using Marina.Siesmar.AccesoDatos.Formatos.Dirpronav;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirpronav;
using System.Data;
using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirpronav
{
    public class InversionPIeIOARR
    {
        InversionPIeIOARRDAO inversionPIeIOARRDAO = new();

        public List<InversionPIeIOARRDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return inversionPIeIOARRDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(InversionPIeIOARRDTO inversionPIeIOARRDTO, string? fecha)
        {
            return inversionPIeIOARRDAO.AgregarRegistro(inversionPIeIOARRDTO, fecha);
        }

        public InversionPIeIOARRDTO BuscarFormato(int Codigo)
        {
            return inversionPIeIOARRDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(InversionPIeIOARRDTO inversionPIeIOARRDTO)
        {
            return inversionPIeIOARRDAO.ActualizaFormato(inversionPIeIOARRDTO);
        }

        public bool EliminarFormato(InversionPIeIOARRDTO inversionPIeIOARRDTO)
        {
            return inversionPIeIOARRDAO.EliminarFormato(inversionPIeIOARRDTO);
        }

        public bool EliminarCarga(InversionPIeIOARRDTO inversionPIeIOARRDTO)
        {
            return inversionPIeIOARRDAO.EliminarCarga(inversionPIeIOARRDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return inversionPIeIOARRDAO.InsertarDatos(datos, fecha);
        }

    }
}
