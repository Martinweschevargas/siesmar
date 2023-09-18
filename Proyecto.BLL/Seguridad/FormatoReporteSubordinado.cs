using Marina.Siesmar.AccesoDatos.Seguridad;
using Marina.Siesmar.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Marina.Siesmar.LogicaNegocios.Seguridad
{
    public class FormatoReporteSubordinado
    {
        FormatoReporteSubordinadoDAO formatoReporteSubordinadoDAO = new FormatoReporteSubordinadoDAO();

        public List<FormatoReporteSubordinadoDTO> ObtenerFormatoReporteSubordinados()
        {
            return formatoReporteSubordinadoDAO.ObtenerFormatoReporteSubordinados();
        }

        public bool AgregarFormatoReporteSubordinado(FormatoReporteSubordinadoDTO FormatoReporteSubordinadoDto)
        {
            return formatoReporteSubordinadoDAO.AgregarFormatoReporteSubordinado(FormatoReporteSubordinadoDto);
        }

        public FormatoReporteSubordinadoDTO EditarFormatoReporteSubordinado(int Codigo)
        {
            return formatoReporteSubordinadoDAO.BuscarFormatoReporteSubordinadoID(Codigo);
        }

        public bool ActualizaFormatoReporteSubordinado(FormatoReporteSubordinadoDTO FormatoReporteSubordinadoDto)
        {
            return formatoReporteSubordinadoDAO.ActualizarFormatoReporteSubordinado(FormatoReporteSubordinadoDto);
        }

        public bool EliminarFormatoReporteSubordinado(int Codigo)
        {
            return formatoReporteSubordinadoDAO.EliminarFormatoReporteSubordinado(Codigo);
        }



    }
}
