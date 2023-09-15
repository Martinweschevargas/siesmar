using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ProvinciaUbigeoDTO
    {
        public int ProvinciaUbigeoId { get; set; }
        public string? DescProvincia { get; set; }
        public string? Ubigeo { get; set; }
        public int? DepartamentoUbigeoId { get; set; }

        public string? DescDepartamentoUbigeo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
