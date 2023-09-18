using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AlistamientoMaterialRequerido3N
    {
        readonly AlistamientoMaterialRequerido3NDAO alistamientoMaterialRequerido3NDAO = new();

        public List<AlistamientoMaterialRequerido3NDTO> ObtenerAlistamientoMaterialRequerido3Ns()
        {
            return alistamientoMaterialRequerido3NDAO.ObtenerAlistamientoMaterialRequerido3Ns();
        }

        public string AgregarAlistamientoMaterialRequerido3N(AlistamientoMaterialRequerido3NDTO alistamientoMaterialRequerido3NDto)
        {
            return alistamientoMaterialRequerido3NDAO.AgregarAlistamientoMaterialRequerido3N(alistamientoMaterialRequerido3NDto);
        }

        public AlistamientoMaterialRequerido3NDTO BuscarAlistamientoMaterialRequerido3NID(int Codigo)
        {
            return alistamientoMaterialRequerido3NDAO.BuscarAlistamientoMaterialRequerido3NID(Codigo);
        }

        public string ActualizarAlistamientoMaterialRequerido3N(AlistamientoMaterialRequerido3NDTO alistamientoMaterialRequerido3NDto)
        {
            return alistamientoMaterialRequerido3NDAO.ActualizarAlistamientoMaterialRequerido3N(alistamientoMaterialRequerido3NDto);
        }

        public string EliminarAlistamientoMaterialRequerido3N(AlistamientoMaterialRequerido3NDTO alistamientoMaterialRequerido3NDto)
        {
            return alistamientoMaterialRequerido3NDAO.EliminarAlistamientoMaterialRequerido3N(alistamientoMaterialRequerido3NDto);
        }

    }
}
