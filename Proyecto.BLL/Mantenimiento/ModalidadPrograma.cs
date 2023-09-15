using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ModalidadPrograma
    {
        readonly ModalidadProgramaDAO modalidadProgramaDAO = new();

        public List<ModalidadProgramaDTO> ObtenerModalidadProgramas()
        {
            return modalidadProgramaDAO.ObtenerModalidadProgramas();
        }

        public string AgregarModalidadPrograma(ModalidadProgramaDTO modalidadProgramaDto)
        {
            return modalidadProgramaDAO.AgregarModalidadPrograma(modalidadProgramaDto);
        }

        public ModalidadProgramaDTO BuscarModalidadProgramaID(int Codigo)
        {
            return modalidadProgramaDAO.BuscarModalidadProgramaID(Codigo);
        }

        public string ActualizarModalidadPrograma(ModalidadProgramaDTO modalidadProgramaDto)
        {
            return modalidadProgramaDAO.ActualizarModalidadPrograma(modalidadProgramaDto);
        }

        public string EliminarModalidadPrograma(ModalidadProgramaDTO modalidadProgramaDto)
        {
            return modalidadProgramaDAO.EliminarModalidadPrograma(modalidadProgramaDto);
        }

    }
}
