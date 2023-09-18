using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dipermar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dipermar
{
    public class DesarrolloAccionesClimaLaboral
    {
        DesarrolloAccionesClimaLaboralDAO desarrolloAccionesClimaLaboralDAO = new();

        public List<DesarrolloAccionesClimaLaboralDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return desarrolloAccionesClimaLaboralDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(DesarrolloAccionesClimaLaboralDTO desarrolloAccionesClimaLaboralDTO, string? fecha)
        {
            return desarrolloAccionesClimaLaboralDAO.AgregarRegistro(desarrolloAccionesClimaLaboralDTO, fecha);
        }

        public DesarrolloAccionesClimaLaboralDTO BuscarFormato(int Codigo)
        {
            return desarrolloAccionesClimaLaboralDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(DesarrolloAccionesClimaLaboralDTO desarrolloAccionesClimaLaboralDTO)
        {
            return desarrolloAccionesClimaLaboralDAO.ActualizaFormato(desarrolloAccionesClimaLaboralDTO);
        }

        public bool EliminarFormato(DesarrolloAccionesClimaLaboralDTO desarrolloAccionesClimaLaboralDTO)
        {
            return desarrolloAccionesClimaLaboralDAO.EliminarFormato(desarrolloAccionesClimaLaboralDTO);
        }

        public bool EliminarCarga(DesarrolloAccionesClimaLaboralDTO desarrolloAccionesClimaLaboralDTO)
        {
            return desarrolloAccionesClimaLaboralDAO.EliminarCarga(desarrolloAccionesClimaLaboralDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return desarrolloAccionesClimaLaboralDAO.InsertarDatos(datos, fecha);
        }

    }
}
