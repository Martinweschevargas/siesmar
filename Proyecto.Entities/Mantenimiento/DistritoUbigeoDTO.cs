using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DistritoUbigeoDTO
    { 
        public int DistritoUbigeoId { get; set; }
        public string? DescDistrito { get; set; }
        public string? DistritoUbigeo { get; set; }
        public int? ProvinciaUbigeoId { get; set; }


        public string? DescProvincia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
