using Marina.Siesmar.AccesoDatos.Seguridad;
using Marina.Siesmar.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Marina.Siesmar.LogicaNegocios.Seguridad
{
    public class Permiso
    {
        PermisoDAO permisoDAO = new PermisoDAO();

        public List<PermisoDTO> ObtenerPermisos()
        {
            return permisoDAO.ObtenerPermisos();
        }

        public bool AgregarPermiso(PermisoDTO permisoDto)
        {
            return permisoDAO.AgregarPermiso(permisoDto);
        }

        public PermisoDTO EditarPermiso(int Codigo)
        {
            return permisoDAO.BuscarPermisoID(Codigo);
        }

        public bool ActualizaPermiso(PermisoDTO PermisoDto)
        {
            return permisoDAO.ActualizarPermiso(PermisoDto);
        }

        public bool EliminarPermiso(int Codigo)
        {
            return permisoDAO.EliminarPermiso(Codigo);
        }



    }
}
