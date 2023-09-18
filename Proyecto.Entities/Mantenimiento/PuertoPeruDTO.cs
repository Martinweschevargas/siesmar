using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PuertoPeruDTO
    {
        public int PuertoPeruId { get; set; }
        public string? DescPuertoPeru { get; set; }
        public string? CodigoPuertoPeru { get; set; }
        public int TipoPuertoPeruId { get; set; }
        public string? DescTipoPuertoPeru { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
