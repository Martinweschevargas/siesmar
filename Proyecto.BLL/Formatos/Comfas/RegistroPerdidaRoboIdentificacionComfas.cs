using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class RegistroPerdidaRoboIdentificacionComfas
    {
        RegistroPerdidaRoboIdentificacionComfasDAO RegistroPerdidaRoboIdentificacionComfasDAO = new();

        public List<RegistroPerdidaRoboIdentificacionComfasDTO> ObtenerLista()
        {
            return RegistroPerdidaRoboIdentificacionComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(RegistroPerdidaRoboIdentificacionComfasDTO RegistroPerdidaRoboIdentificacionComfasDTO)
        {
            return RegistroPerdidaRoboIdentificacionComfasDAO.AgregarRegistro(RegistroPerdidaRoboIdentificacionComfasDTO);
        }

        public RegistroPerdidaRoboIdentificacionComfasDTO BuscarFormato(int Codigo)
        {
            return RegistroPerdidaRoboIdentificacionComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroPerdidaRoboIdentificacionComfasDTO RegistroPerdidaRoboIdentificacionComfasDTO)
        {
            return RegistroPerdidaRoboIdentificacionComfasDAO.ActualizaFormato(RegistroPerdidaRoboIdentificacionComfasDTO);
        }

        public bool EliminarFormato(RegistroPerdidaRoboIdentificacionComfasDTO RegistroPerdidaRoboIdentificacionComfasDTO)
        {
            return RegistroPerdidaRoboIdentificacionComfasDAO.EliminarFormato(RegistroPerdidaRoboIdentificacionComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<RegistroPerdidaRoboIdentificacionComfasDTO> RegistroPerdidaRoboIdentificacionComfasDTO)
        {
            return RegistroPerdidaRoboIdentificacionComfasDAO.InsercionMasiva(RegistroPerdidaRoboIdentificacionComfasDTO);
        }

    }
}
