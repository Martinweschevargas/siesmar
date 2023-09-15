using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DptoProteccionMedioAmbiente
    {
        readonly DptoProteccionMedioAmbienteDAO dptoProteccionMedioAmbienteDAO = new();

        public List<DptoProteccionMedioAmbienteDTO> ObtenerDptoProteccionMedioAmbientes()
        {
            return dptoProteccionMedioAmbienteDAO.ObtenerDptoProteccionMedioAmbientes();
        }

        public string AgregarDptoProteccionMedioAmbiente(DptoProteccionMedioAmbienteDTO dptoProteccionMedioAmbienteDto)
        {
            return dptoProteccionMedioAmbienteDAO.AgregarDptoProteccionMedioAmbiente(dptoProteccionMedioAmbienteDto);
        }

        public DptoProteccionMedioAmbienteDTO BuscarDptoProteccionMedioAmbienteID(int Codigo)
        {
            return dptoProteccionMedioAmbienteDAO.BuscarDptoProteccionMedioAmbienteID(Codigo);
        }

        public string ActualizarDptoProteccionMedioAmbiente(DptoProteccionMedioAmbienteDTO dptoProteccionMedioAmbienteDto)
        {
            return dptoProteccionMedioAmbienteDAO.ActualizarDptoProteccionMedioAmbiente(dptoProteccionMedioAmbienteDto);
        }

        public string EliminarDptoProteccionMedioAmbiente(DptoProteccionMedioAmbienteDTO dptoProteccionMedioAmbienteDto)
        {
            return dptoProteccionMedioAmbienteDAO.EliminarDptoProteccionMedioAmbiente(dptoProteccionMedioAmbienteDto);
        }

    }
}
