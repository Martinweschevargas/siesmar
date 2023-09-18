using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CursoProfesionalXCargoDTO
    {
        public int CursoProfesionalXCargoId { get; set; }
        public int TipoPersonalMilitarId { get; set; }
        public string? DescTipoPersonalMilitar { get; set; }
        public int CargoId { get; set; }
        public string? DescCargo { get; set; }
        public string? DescCursoCapacitacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
