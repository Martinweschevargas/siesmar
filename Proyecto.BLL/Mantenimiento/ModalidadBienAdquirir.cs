using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ModalidadBienAdquirir
    {
        readonly ModalidadBienAdquirirDAO modalidadBienAdquirirDAO = new();

        public List<ModalidadBienAdquirirDTO> ObtenerModalidadBienAdquirirs()
        {
            return modalidadBienAdquirirDAO.ObtenerModalidadBienAdquirirs();
        }

        public string AgregarModalidadBienAdquirir(ModalidadBienAdquirirDTO modalidadBienAdquirirDto)
        {
            return modalidadBienAdquirirDAO.AgregarModalidadBienAdquirir(modalidadBienAdquirirDto);
        }

        public ModalidadBienAdquirirDTO BuscarModalidadBienAdquirirID(int Codigo)
        {
            return modalidadBienAdquirirDAO.BuscarModalidadBienAdquirirID(Codigo);
        }

        public string ActualizarModalidadBienAdquirir(ModalidadBienAdquirirDTO modalidadBienAdquirirDTO)
        {
            return modalidadBienAdquirirDAO.ActualizarModalidadBienAdquirir(modalidadBienAdquirirDTO);
        }

        public bool EliminarModalidadBienAdquirir(int Codigo)
        {
            return modalidadBienAdquirirDAO.EliminarModalidadBienAdquirir(Codigo);
        }

    }
}
