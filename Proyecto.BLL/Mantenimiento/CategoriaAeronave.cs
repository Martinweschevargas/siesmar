using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CategoriaAeronave
    {
        readonly CategoriaAeronaveDAO categoriaAeronaveDAO = new();

        public List<CategoriaAeronaveDTO> ObtenerCategoriaAeronaves()
        {
            return categoriaAeronaveDAO.ObtenerCategoriaAeronaves();
        }

        public string AgregarCategoriaAeronave(CategoriaAeronaveDTO categoriaAeronaveDto)
        {
            return categoriaAeronaveDAO.AgregarCategoriaAeronave(categoriaAeronaveDto);
        }

        public CategoriaAeronaveDTO BuscarCategoriaAeronaveID(int Codigo)
        {
            return categoriaAeronaveDAO.BuscarCategoriaAeronaveID(Codigo);
        }

        public string ActualizarCategoriaAeronave(CategoriaAeronaveDTO categoriaAeronaveDto)
        {
            return categoriaAeronaveDAO.ActualizarCategoriaAeronave(categoriaAeronaveDto);
        }

        public string EliminarCategoriaAeronave(CategoriaAeronaveDTO categoriaAeronaveDto)
        {
            return categoriaAeronaveDAO.EliminarCategoriaAeronave(categoriaAeronaveDto);
        }

    }
}
