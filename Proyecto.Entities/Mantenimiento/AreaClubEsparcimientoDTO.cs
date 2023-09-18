using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AreaClubEsparcimientoDTO
    {
        public int AreaClubEsparcimientoId { get; set; }
        public string? DescAreaClubEsparcimiento { get; set; }
        public int ClubEsparcimientoId { get; set; }
        public string? DescClubEsparcimiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
