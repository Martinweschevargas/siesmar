using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfasub
{
    public partial class AlistamientoMunicionComfasubDTO
    {

        public int AlistamientoMunicionComfasubId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoMunicion { get; set; }

        public string? DescUnidadNaval { get; set; }
        public string? DescSistemaMunicion { get; set; }
        public string? DescSubsistemaMunicion { get; set; }
        public string? Equipo { get; set; }
        public string? Municion { get; set; }
        public string? Existente { get; set; }
        public string? Necesaria { get; set; }
        public string? CoeficientePonderacion { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
