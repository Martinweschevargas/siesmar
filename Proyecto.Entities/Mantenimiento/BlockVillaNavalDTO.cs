using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class BlockVillaNavalDTO
    {
        public int BlockVillaNavalId { get; set; }
        public string? CodigoBlockVillaNaval { get; set; }
        public string? DescBlockVillaNaval { get; set; }
        public string? CodigoVillaNaval { get; set; }
        public string? DescVillaNaval { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
