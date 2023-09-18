using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CalificativoAsignadoOperatividadMaterial
    {
        readonly CalificativoAsignadoOperatividadMaterialDAO calificativoAsignadoOperatividadMaterialDAO = new();

        public List<CalificativoAsignadoOperatividadMaterialDTO> ObtenerCalificativoAsignadoOperatividadMaterials()
        {
            return calificativoAsignadoOperatividadMaterialDAO.ObtenerCalificativoAsignadoOperatividadMaterials();
        }

        public string AgregarCalificativoAsignadoOperatividadMaterial(CalificativoAsignadoOperatividadMaterialDTO calificativoAsignadoOperatividadMaterialDto)
        {
            return calificativoAsignadoOperatividadMaterialDAO.AgregarCalificativoAsignadoOperatividadMaterial(calificativoAsignadoOperatividadMaterialDto);
        }

        public CalificativoAsignadoOperatividadMaterialDTO BuscarCalificativoAsignadoOperatividadMaterialID(int Codigo)
        {
            return calificativoAsignadoOperatividadMaterialDAO.BuscarCalificativoAsignadoOperatividadMaterialID(Codigo);
        }

        public string ActualizarCalificativoAsignadoOperatividadMaterial(CalificativoAsignadoOperatividadMaterialDTO calificativoAsignadoOperatividadMaterialDto)
        {
            return calificativoAsignadoOperatividadMaterialDAO.ActualizarCalificativoAsignadoOperatividadMaterial(calificativoAsignadoOperatividadMaterialDto);
        }

        public string EliminarCalificativoAsignadoOperatividadMaterial(CalificativoAsignadoOperatividadMaterialDTO calificativoAsignadoOperatividadMaterialDto)
        {
            return calificativoAsignadoOperatividadMaterialDAO.EliminarCalificativoAsignadoOperatividadMaterial(calificativoAsignadoOperatividadMaterialDto);
        }

    }
}
