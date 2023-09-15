using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DenominacionLenguajeProgramacion
    {
        readonly DenominacionLenguajeProgramacionDAO denominacionLenguajeProgramacionDAO = new();

        public List<DenominacionLenguajeProgramacionDTO> ObtenerDenominacionLenguajeProgramacions()
        {
            return denominacionLenguajeProgramacionDAO.ObtenerDenominacionLenguajeProgramacions();
        }

        public string AgregarDenominacionLenguajeProgramacion(DenominacionLenguajeProgramacionDTO denominacionLenguajeProgramacionDto)
        {
            return denominacionLenguajeProgramacionDAO.AgregarDenominacionLenguajeProgramacion(denominacionLenguajeProgramacionDto);
        }

        public DenominacionLenguajeProgramacionDTO BuscarDenominacionLenguajeProgramacionID(int Codigo)
        {
            return denominacionLenguajeProgramacionDAO.BuscarDenominacionLenguajeProgramacionID(Codigo);
        }

        public string ActualizarDenominacionLenguajeProgramacion(DenominacionLenguajeProgramacionDTO denominacionLenguajeProgramacionDTO)
        {
            return denominacionLenguajeProgramacionDAO.ActualizarDenominacionLenguajeProgramacion(denominacionLenguajeProgramacionDTO);
        }

        public string EliminarDenominacionLenguajeProgramacion(DenominacionLenguajeProgramacionDTO denominacionLenguajeProgramacionDTO)
        {
            return denominacionLenguajeProgramacionDAO.EliminarDenominacionLenguajeProgramacion(denominacionLenguajeProgramacionDTO);
        }

    }
}
