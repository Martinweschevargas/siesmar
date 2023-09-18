using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Combasnai
{
    public partial class AlistCombustibleLubricanteCombasnaiDTO
    {

        public int? AlistamientoCombustibleLubricanteId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? AlistamientoCombustibleLubricante2Id { get; set; }
        public string? Articulo { get; set; }
        public string? Equipo { get; set; }
        public string? UnidadMedida { get; set; }
        public int? Cargo { get; set; }
        public int? Aumento { get; set; }
        public int? Consuo { get; set; }
        public int? Existencia { get; set; }


        public string? DescUnidadNaval { get; set; }





        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
