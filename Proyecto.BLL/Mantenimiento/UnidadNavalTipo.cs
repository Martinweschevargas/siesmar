using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class UnidadNavalTipo
    {
        readonly UnidadNavalTipoDAO unidadNavalTipoDAO = new();

        public List<UnidadNavalTipoDTO> ObtenerUnidadNavalTipos()
        {
            return unidadNavalTipoDAO.ObtenerUnidadNavalTipos();
        }

        public string AgregarUnidadNavalTipo(UnidadNavalTipoDTO unidadNavalTipoDto)
        {
            return unidadNavalTipoDAO.AgregarUnidadNavalTipo(unidadNavalTipoDto);
        }

        public UnidadNavalTipoDTO BuscarUnidadNavalTipoID(int Codigo)
        {
            return unidadNavalTipoDAO.BuscarUnidadNavalTipoID(Codigo);
        }

        public string ActualizarUnidadNavalTipo(UnidadNavalTipoDTO unidadNavalTipoDTO)
        {
            return unidadNavalTipoDAO.ActualizarUnidadNavalTipo(unidadNavalTipoDTO);
        }

        public bool EliminarUnidadNavalTipo(UnidadNavalTipoDTO unidadNavalTipoDTO)
        {
            return unidadNavalTipoDAO.EliminarUnidadNavalTipo(unidadNavalTipoDTO);
        }

    }
}
