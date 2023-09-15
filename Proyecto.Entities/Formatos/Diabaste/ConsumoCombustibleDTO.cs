using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diabaste
{
    public partial class ConsumoCombustibleDTO
    {
        public int? ConsumoCombustibleId { get; set; }
        public int? Anio { get; set; }
        public string? NumeroMes { get; set; }
        public string? CodigoClaseCombustible { get; set; }
        public string? CodigoVehiculoServicioGrupo { get; set; }
        public string? CodigoPuntoDistribucionCombustible { get; set; }
        public string? CodigoVehiculoServicioTipo { get; set; }
        public string? CodigoTipoPresupuesto { get; set; }
        public string? CodigoCombustibleEspecificacion { get; set; }
        public int? CantidadConsumidaGalon { get; set; }
        public int? ValorCantidadConsumida { get; set; }
        public int? CargaId { get; set; }
        public string? DescMes { get; set; }
        public string? DescClaseCombustible { get; set; }
        public string? DescVehiculoServicioGrupo { get; set; }
        public string? DescPuntoDistribucionCombustible { get; set; }
        public string? DescVehiculoServicioTipo { get; set; }
        public string? DescTipoPresupuesto { get; set; }
        public string? DescCombustibleEspecificacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}