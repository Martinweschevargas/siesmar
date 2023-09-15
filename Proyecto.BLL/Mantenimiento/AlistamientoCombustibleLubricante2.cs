using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AlistamientoCombustibleLubricante2
    {
        readonly AlistamientoCombustibleLubricante2DAO alistamientoCombustibleLubricante2DAO = new();

        public List<AlistamientoCombustibleLubricante2DTO> ObtenerAlistamientoCombustibleLubricante2s()
        {
            return alistamientoCombustibleLubricante2DAO.ObtenerAlistamientoCombustibleLubricante2s();
        }

        public string AgregarAlistamientoCombustibleLubricante2(AlistamientoCombustibleLubricante2DTO alistamientoCombustibleLubricante2Dto)
        {
            return alistamientoCombustibleLubricante2DAO.AgregarAlistamientoCombustibleLubricante2(alistamientoCombustibleLubricante2Dto);
        }

        public AlistamientoCombustibleLubricante2DTO BuscarAlistamientoCombustibleLubricante2ID(int Codigo)
        {
            return alistamientoCombustibleLubricante2DAO.BuscarAlistamientoCombustibleLubricante2ID(Codigo);
        }

        public string ActualizarAlistamientoCombustibleLubricante2(AlistamientoCombustibleLubricante2DTO alistamientoCombustibleLubricante2Dto)
        {
            return alistamientoCombustibleLubricante2DAO.ActualizarAlistamientoCombustibleLubricante2(alistamientoCombustibleLubricante2Dto);
        }

        public string EliminarAlistamientoCombustibleLubricante2(AlistamientoCombustibleLubricante2DTO alistamientoCombustibleLubricante2Dto)
        {
            return alistamientoCombustibleLubricante2DAO.EliminarAlistamientoCombustibleLubricante2(alistamientoCombustibleLubricante2Dto);
        }

    }
}
