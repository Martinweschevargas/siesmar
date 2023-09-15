using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Jefatura
    {
        readonly JefaturaDAO jefaturaDAO = new();

        public List<JefaturaDTO> ObtenerJefaturas()
        {
            return jefaturaDAO.ObtenerJefaturas();
        }

        public string AgregarJefatura(JefaturaDTO jefaturaDto)
        {
            return jefaturaDAO.AgregarJefatura(jefaturaDto);
        }

        public JefaturaDTO BuscarJefaturaID(int Codigo)
        {
            return jefaturaDAO.BuscarJefaturaID(Codigo);
        }

        public string ActualizarJefatura(JefaturaDTO jefaturaDto)
        {
            return jefaturaDAO.ActualizarJefatura(jefaturaDto);
        }

        public string EliminarJefatura(JefaturaDTO jefaturaDto)
        {
            return jefaturaDAO.EliminarJefatura(jefaturaDto);
        }

    }
}
