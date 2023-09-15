using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Direcomar
{
    public partial class RecaudacionSubunidadEjecturaDTO
    {

        public int? RecaudacionSubunidadEjecturaId { get; set; }
        public int? AnioRecaudacionSUE { get; set; }
        public string? NumeroMes { get; set; }
        public string? CodigoSubunidadEjecutora { get; set; }
        public decimal? ProyeccionRecaudacionSUE { get; set; }
        public decimal? RecaudadoRecaudacionSUE { get; set; }
        public int? MetaRecaudacionSUE { get; set; } 


        public string? DescMes { get; set; }
        public string? DescSubUnidadEjecutora { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
