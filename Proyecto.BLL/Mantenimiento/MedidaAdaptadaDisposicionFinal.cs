using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MedidaAdaptadaDisposicionFinal
    {
        readonly MedidaAdaptadaDisposicionFinalDAO MedidaAdaptadaDisposicionFinalDAO = new();

        public List<MedidaAdaptadaDisposicionFinalDTO> ObtenerMedidaAdaptadaDisposicionFinals()
        {
            return MedidaAdaptadaDisposicionFinalDAO.ObtenerMedidaAdaptadaDisposicionFinals();
        }

        public string AgregarMedidaAdaptadaDisposicionFinal(MedidaAdaptadaDisposicionFinalDTO medidaAdaptadaDisposicionFinalDto)
        {
            return MedidaAdaptadaDisposicionFinalDAO.AgregarMedidaAdaptadaDisposicionFinal(medidaAdaptadaDisposicionFinalDto);
        }

        public MedidaAdaptadaDisposicionFinalDTO BuscarMedidaAdaptadaDisposicionFinalID(int Codigo)
        {
            return MedidaAdaptadaDisposicionFinalDAO.BuscarMedidaAdaptadaDisposicionFinalID(Codigo);
        }

        public string ActualizarMedidaAdaptadaDisposicionFinal(MedidaAdaptadaDisposicionFinalDTO medidaAdaptadaDisposicionFinalDto)
        {
            return MedidaAdaptadaDisposicionFinalDAO.ActualizarMedidaAdaptadaDisposicionFinal(medidaAdaptadaDisposicionFinalDto);
        }

        public string EliminarMedidaAdaptadaDisposicionFinal(MedidaAdaptadaDisposicionFinalDTO medidaAdaptadaDisposicionFinalDto)
        {
            return MedidaAdaptadaDisposicionFinalDAO.EliminarMedidaAdaptadaDisposicionFinal(medidaAdaptadaDisposicionFinalDto);
        }

    }
}
