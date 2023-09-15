using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AlistamientoMaterialRequerido1N
    {
        readonly AlistamientoMaterialRequerido1NDAO alistamientoMaterialRequerido1NDAO = new();

        public List<AlistamientoMaterialRequerido1NDTO> ObtenerAlistamientoMaterialRequerido1Ns()
        {
            return alistamientoMaterialRequerido1NDAO.ObtenerAlistamientoMaterialRequerido1Ns();
        }

        public string AgregarAlistamientoMaterialRequerido1N(AlistamientoMaterialRequerido1NDTO alistamientoMaterialRequerido1NDto)
        {
            return alistamientoMaterialRequerido1NDAO.AgregarAlistamientoMaterialRequerido1N(alistamientoMaterialRequerido1NDto);
        }

        public AlistamientoMaterialRequerido1NDTO BuscarAlistamientoMaterialRequerido1NID(int Codigo)
        {
            return alistamientoMaterialRequerido1NDAO.BuscarAlistamientoMaterialRequerido1NID(Codigo);
        }

        public string ActualizarAlistamientoMaterialRequerido1N(AlistamientoMaterialRequerido1NDTO alistamientoMaterialRequerido1NDto)
        {
            return alistamientoMaterialRequerido1NDAO.ActualizarAlistamientoMaterialRequerido1N(alistamientoMaterialRequerido1NDto);
        }

        public string EliminarAlistamientoMaterialRequerido1N(AlistamientoMaterialRequerido1NDTO alistamientoMaterialRequerido1NDto)
        {
            return alistamientoMaterialRequerido1NDAO.EliminarAlistamientoMaterialRequerido1N(alistamientoMaterialRequerido1NDto);
        }

    }
}
