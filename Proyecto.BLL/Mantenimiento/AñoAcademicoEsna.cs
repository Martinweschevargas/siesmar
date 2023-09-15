using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AñoAcademicoEsna
    {
        readonly AñoAcademicoEsnaDAO añoAcademicoEsnaDAO = new();

        public List<AñoAcademicoEsnaDTO> ObtenerAñoAcademicoEsnas()
        {
            return añoAcademicoEsnaDAO.ObtenerAñoAcademicoEsnas();
        }

        public string AgregarAñoAcademicoEsna(AñoAcademicoEsnaDTO añoAcademicoEsnaDto)
        {
            return añoAcademicoEsnaDAO.AgregarAñoAcademicoEsna(añoAcademicoEsnaDto);
        }

        public AñoAcademicoEsnaDTO BuscarAñoAcademicoEsnaID(int Codigo)
        {
            return añoAcademicoEsnaDAO.BuscarAñoAcademicoEsnaID(Codigo);
        }

        public string ActualizarAñoAcademicoEsna(AñoAcademicoEsnaDTO añoAcademicoEsnaDTO)
        {
            return añoAcademicoEsnaDAO.ActualizarAñoAcademicoEsna(añoAcademicoEsnaDTO);
        }

        public string EliminarAñoAcademicoEsna(AñoAcademicoEsnaDTO añoAcademicoEsnaDTO)
        {
            return añoAcademicoEsnaDAO.EliminarAñoAcademicoEsna(añoAcademicoEsnaDTO);
        }

    }
}
