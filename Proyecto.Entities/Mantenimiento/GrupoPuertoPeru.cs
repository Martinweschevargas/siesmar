using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class GrupoPuertoPeruDTO
    {
        public int GrupoPuertoPeruId { get; set; }
        public string? DescGrupoPuertoPeru { get; set; }
        public string? CodigoGrupoPuertoPeru { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
