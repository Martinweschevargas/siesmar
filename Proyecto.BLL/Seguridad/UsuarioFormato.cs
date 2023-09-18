using Marina.Siesmar.AccesoDatos.Seguridad;
using Marina.Siesmar.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Marina.Siesmar.LogicaNegocios.Seguridad
{
    public class UsuarioFormato
    {
        UsuarioFormatoDAO UsuarioFormatoDAO = new UsuarioFormatoDAO();

        public List<UsuarioFormatoDTO> ObtenerUsuarioFormatos(int? usuario = null)
        {
            return UsuarioFormatoDAO.ObtenerUsuarioFormatos(usuario);
        }

        public string AgregarUsuarioFormato(UsuarioFormatoDTO UsuarioFormatoDto)
        {
            return UsuarioFormatoDAO.AgregarUsuarioFormato(UsuarioFormatoDto);
        }

        public UsuarioFormatoDTO EditarUsuarioFormato(int Codigo)
        {
            return UsuarioFormatoDAO.BuscarUsuarioFormatoID(Codigo);
        }

        public string ActualizaUsuarioFormato(UsuarioFormatoDTO usuarioFormatoDto)
        {
            return UsuarioFormatoDAO.ActualizarUsuarioFormato(usuarioFormatoDto);
        }

        public string EliminarUsuarioFormato(UsuarioFormatoDTO usuarioFormatoDto)
        {
            return UsuarioFormatoDAO.EliminarUsuarioFormato(usuarioFormatoDto);
        }



    }
}
