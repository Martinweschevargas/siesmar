using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GradoRemunerativo
    {
        readonly GradoRemunerativoDAO gradoRemunerativoDAO = new();
        
        public List<GradoRemunerativoDTO> ObtenerGradoRemunerativos()
        {
            return gradoRemunerativoDAO.ObtenerGradoRemunerativos();
        }

        public string AgregarGradoRemunerativo(GradoRemunerativoDTO gradoRemunerativoDto)
        {
            return gradoRemunerativoDAO.AgregarGradoRemunerativo(gradoRemunerativoDto);
        }

        public GradoRemunerativoDTO BuscarGradoRemunerativoID(int Codigo)
        {
            return gradoRemunerativoDAO.BuscarGradoRemunerativoID(Codigo);
        }

        public string ActualizarGradoRemunerativo(GradoRemunerativoDTO gradoRemunerativoDTO)
        {
            return gradoRemunerativoDAO.ActualizarGradoRemunerativo(gradoRemunerativoDTO);
        }

        public string EliminarGradoRemunerativo(GradoRemunerativoDTO gradoRemunerativoDTO)
        {
            return gradoRemunerativoDAO.EliminarGradoRemunerativo(gradoRemunerativoDTO);
        }

    }
}
