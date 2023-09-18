using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AlistamientoMaterialRequerido2N
    {
        readonly AlistamientoMaterialRequerido2NDAO alistamientoMaterialRequerido2NDAO = new();

        public List<AlistamientoMaterialRequerido2NDTO> ObtenerAlistamientoMaterialRequerido2Ns()
        {
            return alistamientoMaterialRequerido2NDAO.ObtenerAlistamientoMaterialRequerido2Ns();
        }

        public string AgregarAlistamientoMaterialRequerido2N(AlistamientoMaterialRequerido2NDTO alistamientoMaterialRequerido2NDto)
        {
            return alistamientoMaterialRequerido2NDAO.AgregarAlistamientoMaterialRequerido2N(alistamientoMaterialRequerido2NDto);
        }

        public AlistamientoMaterialRequerido2NDTO BuscarAlistamientoMaterialRequerido2NID(int Codigo)
        {
            return alistamientoMaterialRequerido2NDAO.BuscarAlistamientoMaterialRequerido2NID(Codigo);
        }

        public string ActualizarAlistamientoMaterialRequerido2N(AlistamientoMaterialRequerido2NDTO alistamientoMaterialRequerido2NDto)
        {
            return alistamientoMaterialRequerido2NDAO.ActualizarAlistamientoMaterialRequerido2N(alistamientoMaterialRequerido2NDto);
        }

        public string EliminarAlistamientoMaterialRequerido2N(AlistamientoMaterialRequerido2NDTO alistamientoMaterialRequerido2NDto)
        {
            return alistamientoMaterialRequerido2NDAO.EliminarAlistamientoMaterialRequerido2N(alistamientoMaterialRequerido2NDto);
        }

    }
}
