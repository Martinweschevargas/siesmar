using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Contacto
    {
        readonly ContactoDAO contactoDAO = new();

        public List<ContactoDTO> ObtenerContactos()
        {
            return contactoDAO.ObtenerContactos();
        }

        public string AgregarContacto(ContactoDTO contactoDto)
        {
            return contactoDAO.AgregarContacto(contactoDto);
        }

        public ContactoDTO BuscarContactoID(int Codigo)
        {
            return contactoDAO.BuscarContactoID(Codigo);
        }

        public string ActualizarContacto(ContactoDTO contactoDTO)
        {
            return contactoDAO.ActualizarContacto(contactoDTO);
        }

        public bool EliminarContacto(ContactoDTO contactoDTO)
        {
            return contactoDAO.EliminarContacto(contactoDTO);
        }

    }
}
