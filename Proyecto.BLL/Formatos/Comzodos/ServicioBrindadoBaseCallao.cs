using Marina.Siesmar.AccesoDatos.Formatos.Comzodos;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comzodos;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzodos
{
    public class ServicioBrindadoBaseCallao
    {
        ServicioBrindadoBaseCallaoDAO servicioBrindadoBaseCallaoDAO = new();

        public List<ServicioBrindadoBaseCallaoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return servicioBrindadoBaseCallaoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ServicioBrindadoBaseCallaoDTO servicioBrindadoBaseCallao, string? fecha = null)
        {
            return servicioBrindadoBaseCallaoDAO.AgregarRegistro(servicioBrindadoBaseCallao, fecha);
        }

        public ServicioBrindadoBaseCallaoDTO EditarFormato(int Codigo)
        {
            return servicioBrindadoBaseCallaoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioBrindadoBaseCallaoDTO servicioBrindadoBaseCallaoDTO)
        {
            return servicioBrindadoBaseCallaoDAO.ActualizaFormato(servicioBrindadoBaseCallaoDTO);
        }

        public bool EliminarFormato(ServicioBrindadoBaseCallaoDTO servicioBrindadoBaseCallaoDTO)
        {
            return servicioBrindadoBaseCallaoDAO.EliminarFormato( servicioBrindadoBaseCallaoDTO);
        }

        public bool EliminarCarga(ServicioBrindadoBaseCallaoDTO servicioBrindadoBaseCallaoDTO)
        {
            return servicioBrindadoBaseCallaoDAO.EliminarCarga(servicioBrindadoBaseCallaoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return servicioBrindadoBaseCallaoDAO.InsertarDatos(datos, fecha);
        }
    }
}