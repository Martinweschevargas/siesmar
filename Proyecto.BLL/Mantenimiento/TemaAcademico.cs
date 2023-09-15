using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TemaAcademico
    {
        readonly TemaAcademicoDAO temaAcademicoDAO = new();

        public List<TemaAcademicoDTO> ObtenerCapintanias()
        {
            return temaAcademicoDAO.ObtenerTemaAcademicos();
        }

        public string AgregarTemaAcademico(TemaAcademicoDTO temaAcademicoDto)
        {
            return temaAcademicoDAO.AgregarTemaAcademico(temaAcademicoDto);
        }

        public TemaAcademicoDTO BuscarTemaAcademicoID(int Codigo)
        {
            return temaAcademicoDAO.BuscarTemaAcademicoID(Codigo);
        }

        public string ActualizarTemaAcademico(TemaAcademicoDTO temaAcademicoDTO)
        {
            return temaAcademicoDAO.ActualizarTemaAcademico(temaAcademicoDTO);
        }

        public string EliminarTemaAcademico(TemaAcademicoDTO temaAcademicoDTO)
        {
            return temaAcademicoDAO.EliminarTemaAcademico(temaAcademicoDTO);
        }

    }
}
