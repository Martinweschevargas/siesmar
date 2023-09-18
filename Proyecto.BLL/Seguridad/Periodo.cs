using Marina.Siesmar.AccesoDatos.Seguridad;
using Marina.Siesmar.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Marina.Siesmar.LogicaNegocios.Seguridad
{
    public class Periodo
    {
        PeriodoDAO periodoDAO = new PeriodoDAO();

        public List<PeriodoDTO> ObtenerPeriodos()
        {
            return periodoDAO.ObtenerPeriodos();
        }

        public string AgregarPeriodo(PeriodoDTO periodoDto)
        {
            return periodoDAO.AgregarPeriodo(periodoDto);
        }

        public PeriodoDTO EditarPeriodo(int Codigo)
        {
            return periodoDAO.BuscarPeriodoID(Codigo);
        }

        public string ActualizaPeriodo(PeriodoDTO PeriodoDto)
        {
            return periodoDAO.ActualizarPeriodo(PeriodoDto);
        }

        public bool EliminarPeriodo(int Codigo)
        {
            return periodoDAO.EliminarPeriodo(Codigo);
        }



    }
}
