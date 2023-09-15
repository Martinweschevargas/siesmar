using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SecuenciaCargaDTO
    {
        public string? NOM_TABLA { get; set; }
        public int NUM_SECUENCIA { get; set; }
        public string? FEC_REGISTRO { get; set; }
        public int USR_REGISTRO { get; set; }
        public string? FEC_ACTUALIZO { get; set; }
        public int USR_ACTUALIZO { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
