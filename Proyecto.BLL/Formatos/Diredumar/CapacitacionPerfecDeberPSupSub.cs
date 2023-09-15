using Marina.Siesmar.AccesoDatos.Formatos.Diredumar;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diredumar
{
    public class CapacitacionPerfecDeberPSupSub
    {
        CapacitacionPerfecDeberPSupSubDAO capacitacionPerfecDeberPSupSubDAO = new();

        public List<CapacitacionPerfecDeberPSupSubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return capacitacionPerfecDeberPSupSubDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(CapacitacionPerfecDeberPSupSubDTO capacitacionPerfecDeberPSupSub, string? fecha = null)
        {
            return capacitacionPerfecDeberPSupSubDAO.AgregarRegistro(capacitacionPerfecDeberPSupSub, fecha);
        }

        public CapacitacionPerfecDeberPSupSubDTO EditarFormado(int Codigo)
        {
            return capacitacionPerfecDeberPSupSubDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CapacitacionPerfecDeberPSupSubDTO capacitacionPerfecDeberPSupSubDTO)
        {
            return capacitacionPerfecDeberPSupSubDAO.ActualizaFormato(capacitacionPerfecDeberPSupSubDTO);
        }

        public bool EliminarFormato(CapacitacionPerfecDeberPSupSubDTO capacitacionPerfecDeberPSupSubDTO)
        {
            return capacitacionPerfecDeberPSupSubDAO.EliminarFormato(capacitacionPerfecDeberPSupSubDTO);
        }

        public bool EliminarCarga(CapacitacionPerfecDeberPSupSubDTO capacitacionPerfecDeberPSupSubDTO)
        {
            return capacitacionPerfecDeberPSupSubDAO.EliminarCarga(capacitacionPerfecDeberPSupSubDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return capacitacionPerfecDeberPSupSubDAO.InsertarDatos(datos, fecha);
        }
    }
}
