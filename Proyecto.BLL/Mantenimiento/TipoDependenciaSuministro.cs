using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoDependenciaSuministro
    {
        readonly TipoDependenciaSuministroDAO tipoDependenciaSuministroDAO = new();

        public List<TipoDependenciaSuministroDTO> ObtenerTipoDependenciaSuministros()
        {
            return tipoDependenciaSuministroDAO.ObtenerTipoDependenciaSuministros();
        }

        public string AgregarTipoDependenciaSuministro(TipoDependenciaSuministroDTO TipoDependenciaSuministroDto)
        {
            return tipoDependenciaSuministroDAO.AgregarTipoDependenciaSuministro(TipoDependenciaSuministroDto);
        }

        public TipoDependenciaSuministroDTO BuscarTipoDependenciaSuministroID(int Codigo)
        {
            return tipoDependenciaSuministroDAO.BuscarTipoDependenciaSuministroID(Codigo);
        }

        public string ActualizarTipoDependenciaSuministro(TipoDependenciaSuministroDTO tipoDependenciaSuministroDTO)
        {
            return tipoDependenciaSuministroDAO.ActualizarTipoDependenciaSuministro(tipoDependenciaSuministroDTO);
        }

        public bool EliminarTipoDependenciaSuministro(TipoDependenciaSuministroDTO tipoDependenciaSuministroDTO)
        {
            return tipoDependenciaSuministroDAO.EliminarTipoDependenciaSuministro(tipoDependenciaSuministroDTO);
        }

    }
}
