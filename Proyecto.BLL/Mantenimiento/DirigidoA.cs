using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DirigidoA
    {
        readonly DirigidoADAO dirigidoADAO = new();

        public List<DirigidoADTO> ObtenerDirigidoAs()
        {
            return dirigidoADAO.ObtenerDirigidoAs();
        }

        public string AgregarDirigidoA(DirigidoADTO dirigidoADto)
        {
            return dirigidoADAO.AgregarDirigidoA(dirigidoADto);
        }

        public DirigidoADTO BuscarDirigidoAID(int Codigo)
        {
            return dirigidoADAO.BuscarDirigidoAID(Codigo);
        }

        public string ActualizarDirigidoA(DirigidoADTO dirigidoADto)
        {
            return dirigidoADAO.ActualizarDirigidoA(dirigidoADto);
        }

        public string EliminarDirigidoA(DirigidoADTO dirigidoADto)
        {
            return dirigidoADAO.EliminarDirigidoA(dirigidoADto);
        }

    }
}