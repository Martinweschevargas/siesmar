using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class UnidadBelica
    {
        readonly UnidadBelicaDAO unidadBelicaDAO = new();

        public List<UnidadBelicaDTO> ObtenerUnidadBelicas()
        {
            return unidadBelicaDAO.ObtenerUnidadBelicas();
        }

        public string AgregarUnidadBelica(UnidadBelicaDTO unidadBelicaDto)
        {
            return unidadBelicaDAO.AgregarUnidadBelica(unidadBelicaDto);
        }

        public UnidadBelicaDTO BuscarUnidadBelicaID(int Codigo)
        {
            return unidadBelicaDAO.BuscarUnidadBelicaID(Codigo);
        }

        public string ActualizarUnidadBelica(UnidadBelicaDTO unidadBelicaDto)
        {
            return unidadBelicaDAO.ActualizarUnidadBelica(unidadBelicaDto);
        }

        public string EliminarUnidadBelica(UnidadBelicaDTO unidadBelicaDto)
        {
            return unidadBelicaDAO.EliminarUnidadBelica(unidadBelicaDto);
        }

    }
}
