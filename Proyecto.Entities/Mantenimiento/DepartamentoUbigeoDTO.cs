using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DepartamentoUbigeoDTO
    {
        public int DepartamentoUbigeoId { get; set; }
        public string? DescDepartamento { get; set; }
        public string? Ubigeo { get; set; }
        public string? NombrePais { get; set; }
        public int? PaisUbigeoId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
