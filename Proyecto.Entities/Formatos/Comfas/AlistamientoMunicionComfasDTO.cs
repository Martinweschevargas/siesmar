using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class AlistamientoMunicionComfasDTO
    {

        public int? AlistamientoMunicionComfasId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? SistemaMunicionId { get; set; }
        public int? SubsistemaMunicionId { get; set; }
        public int? Equipo { get; set; }
        public int? Municion { get; set; }
        public int? Existente { get; set; }
        public int? Necesaria { get; set; }
        public int? CoeficientePonderacion { get; set; }



        public string? DescUnidadNaval { get; set; }
        public string? DescSistemaMunicion { get; set; }
        public string? DescSubsistemaMunicion { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    

    }
}
