using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comescla
{
    public partial class AlistamientoCombustibleLubricanteComesclaDTO
    {

        public int? AlistamientoCombustibleLubricanteId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? AlistamientoCombustibleLubricante2Id { get; set; }



        public string? DescUnidadNaval { get; set; }
        public string? Articulo { get; set; }
        public string? Equipo { get; set; }
        public string? DescUnidadMedidad { get; set; }
        public int? Cargo { get; set; }
        public int? Aumento { get; set; }
        public int? Consumo { get; set; }
        public int? Existencia { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
