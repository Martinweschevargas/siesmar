using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class JefaturaDistritoCapitania
    {
        readonly JefaturaDistritoCapitaniaDAO jefaturaDistritoCapitaniaDAO = new();

        public List<JefaturaDistritoCapitaniaDTO> ObtenerJefaturaDistritoCapitanias()
        {
            return jefaturaDistritoCapitaniaDAO.ObtenerJefaturaDistritoCapitanias();
        }

        public string AgregarJefaturaDistritoCapitania(JefaturaDistritoCapitaniaDTO jefaturaDistritoCapitaniaDto)
        {
            return jefaturaDistritoCapitaniaDAO.AgregarJefaturaDistritoCapitania(jefaturaDistritoCapitaniaDto);
        }

        public JefaturaDistritoCapitaniaDTO BuscarJefaturaDistritoCapitaniaID(int Codigo)
        {
            return jefaturaDistritoCapitaniaDAO.BuscarJefaturaDistritoCapitaniaID(Codigo);
        }

        public string ActualizarJefaturaDistritoCapitania(JefaturaDistritoCapitaniaDTO jefaturaDistritoCapitaniaDTO)
        {
            return jefaturaDistritoCapitaniaDAO.ActualizarJefaturaDistritoCapitania(jefaturaDistritoCapitaniaDTO);
        }

        public string EliminarJefaturaDistritoCapitania(JefaturaDistritoCapitaniaDTO jefaturaDistritoCapitaniaDTO)
        {
            return jefaturaDistritoCapitaniaDAO.EliminarJefaturaDistritoCapitania(jefaturaDistritoCapitaniaDTO);
        }

    }
}
