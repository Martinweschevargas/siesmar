using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfasub
{
    public partial class PresupuestoComfasubDTO
    {

        public int PresupuestoComfasubId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoSistemaPropulsion { get; set; }
        public string? CodigoSubSistemaPropulsion { get; set; }
        public decimal? PresupuestoAsignado { get; set; }
        public string? CodigoFuenteFinanciamiento { get; set; }
        public string? CodigoSubUnidadEjecutora { get; set; }
        public string? CodigoCentroGasto { get; set; }
        public string? CodigoPartida { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? DescSistemaPropulsion { get; set; }
        public string? DescSubSistemaPropulsion { get; set; }
        public string? DescFuenteFinanciamiento { get; set; }
        public string? DescSubUnidadEjecutora { get; set; }
        public string? DescCentroGasto { get; set; }
        public string? DescPartida { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}