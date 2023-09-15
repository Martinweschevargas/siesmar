using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EntidadConvocante
    {
        readonly EntidadConvocanteDAO entidadConvocanteDAO = new();

        public List<EntidadConvocanteDTO> ObtenerEntidadConvocantes()
        {
            return entidadConvocanteDAO.ObtenerEntidadConvocantes();
        }

        public string AgregarEntidadConvocante(EntidadConvocanteDTO entidadConvocanteDto)
        {
            return entidadConvocanteDAO.AgregarEntidadConvocante(entidadConvocanteDto);
        }

        public EntidadConvocanteDTO BuscarEntidadConvocanteID(int Codigo)
        {
            return entidadConvocanteDAO.BuscarEntidadConvocanteID(Codigo);
        }

        public string ActualizarEntidadConvocante(EntidadConvocanteDTO entidadConvocanteDTO)
        {
            return entidadConvocanteDAO.ActualizarEntidadConvocante(entidadConvocanteDTO);
        }

        public bool EliminarEntidadConvocante(EntidadConvocanteDTO entidadConvocanteDTO)
        {
            return entidadConvocanteDAO.EliminarEntidadConvocante(entidadConvocanteDTO);
        }

    }
}
