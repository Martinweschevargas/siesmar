using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzocuatro
{
    public partial class AlistCombustibleLubricanteComzocuatroDTO
    {

        public int? AlistamientoCombustibleLubricanteId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoCombustibleLubricante2 { get; set; }



        public string? DescUnidadNaval { get; set; }
        public string? Articulo { get; set; }
        public string? Equipo { get; set; }
        public string? DescUnidadMedidad { get; set; }
        public int? Cargo { get; set; }
        public int? Aumento { get; set; }
        public int? Consumo { get; set; }
        public int? Existencia { get; set; }

        public decimal? PromedioPonderado { get; set; }
        public decimal? SubPromedioParcial { get; set; }

        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
