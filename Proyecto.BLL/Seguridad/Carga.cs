using Marina.Siesmar.AccesoDatos.Seguridad;
using Marina.Siesmar.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Marina.Siesmar.LogicaNegocios.Seguridad
{
    public class Carga
    {
        CargaDAO cargaDAO = new CargaDAO();

        public List<CargaDTO> ObtenerListaCargas(string descripcion)
        {
            return cargaDAO.ObtenerLista(descripcion);
        }
    }
}
