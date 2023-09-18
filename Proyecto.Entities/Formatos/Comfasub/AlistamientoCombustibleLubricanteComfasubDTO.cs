using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfasub
{
    public partial class AlistamientoCombustibleLubricanteComfasubDTO
    {

        public int AlistamientoCombustibleLubricanteComfasubId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public int? SistemaCombustibleLubricanteId { get; set; }
        public string? CodigoAlistamientoCombustibleLubricante { get; set; }

        public string? DescUnidadNaval { get; set; }
        public string? DescSistemaCombustibleLubricante { get; set; }
        public string? DescSubsistemaCombustibleLubricante { get; set; }
        public string? Equipo { get; set; }
        public string? CombustibleLubricante { get; set; }
        public string? Existente { get; set; }
        public string? NecesariasGLS { get; set; }
        public int? CoeficientePonderacion { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
