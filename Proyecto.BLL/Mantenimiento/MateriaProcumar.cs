using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MateriaProcumar
    {
        readonly MateriaProcumarDAO materiaProcumarDAO = new();

        public List<MateriaProcumarDTO> ObtenerMateriaProcumars()
        {
            return materiaProcumarDAO.ObtenerMateriaProcumars();
        }

        public string AgregarMateriaProcumar(MateriaProcumarDTO materiaProcumarDto)
        {
            return materiaProcumarDAO.AgregarMateriaProcumar(materiaProcumarDto);
        }

        public MateriaProcumarDTO BuscarMateriaProcumarID(int Codigo)
        {
            return materiaProcumarDAO.BuscarMateriaProcumarID(Codigo);
        }

        public string ActualizarMateriaProcumar(MateriaProcumarDTO materiaProcumarDTO)
        {
            return materiaProcumarDAO.ActualizarMateriaProcumar(materiaProcumarDTO);
        }

        public string EliminarMateriaProcumar(MateriaProcumarDTO materiaProcumarDTO)
        {
            return materiaProcumarDAO.EliminarMateriaProcumar(materiaProcumarDTO);
        }

    }
}
