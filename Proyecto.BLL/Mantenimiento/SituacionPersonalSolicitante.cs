
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SituacionPersonalSolicitante
    {
        readonly SituacionPersonalSolicitanteDAO situacionPersonalSolicitanteDAO = new();

        public List<SituacionPersonalSolicitanteDTO> ObtenerSituacionPersonalSolicitantes()
        {
            return situacionPersonalSolicitanteDAO.ObtenerSituacionPersonalSolicitantes();
        }

        public string AgregarSituacionPersonalSolicitante(SituacionPersonalSolicitanteDTO situacionPersonalSolicitanteDto)
        {
            return situacionPersonalSolicitanteDAO.AgregarSituacionPersonalSolicitante(situacionPersonalSolicitanteDto);
        }

        public SituacionPersonalSolicitanteDTO BuscarSituacionPersonalSolicitanteID(int Codigo)
        {
            return situacionPersonalSolicitanteDAO.BuscarSituacionPersonalSolicitanteID(Codigo);
        }

        public string ActualizarSituacionPersonalSolicitante(SituacionPersonalSolicitanteDTO situacionPersonalSolicitanteDTO)
        {
            return situacionPersonalSolicitanteDAO.ActualizarSituacionPersonalSolicitante(situacionPersonalSolicitanteDTO);
        }

        public bool EliminarSituacionPersonalSolicitante(SituacionPersonalSolicitanteDTO situacionPersonalSolicitanteDTO)
        {
            return situacionPersonalSolicitanteDAO.EliminarSituacionPersonalSolicitante(situacionPersonalSolicitanteDTO);
        }

    }
}