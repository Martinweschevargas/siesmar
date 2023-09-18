using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CapacidadOperativa
    {
        readonly CapacidadOperativaDAO capacidadOperativaDAO = new();

        public List<CapacidadOperativaDTO> ObtenerCapacidadOperativas()
        {
            return capacidadOperativaDAO.ObtenerCapacidadOperativas();
        }

        public string AgregarCapacidadOperativa(CapacidadOperativaDTO capacidadOperativaDto)
        {
            return capacidadOperativaDAO.AgregarCapacidadOperativa(capacidadOperativaDto);
        }

        public CapacidadOperativaDTO BuscarCapacidadOperativaID(int Codigo)
        {
            return capacidadOperativaDAO.BuscarCapacidadOperativaID(Codigo);
        }

        public string ActualizarCapacidadOperativa(CapacidadOperativaDTO capacidadOperativaDto)
        {
            return capacidadOperativaDAO.ActualizarCapacidadOperativa(capacidadOperativaDto);
        }

        public string EliminarCapacidadOperativa(CapacidadOperativaDTO capacidadOperativaDto)
        {
            return capacidadOperativaDAO.EliminarCapacidadOperativa(capacidadOperativaDto);
        }

    }
}
