using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Siesmar.Entidades.Seguridad
{
    public class FormatoReporteDTO
    {
        public int FormatoReporteId { get; set; }
        public string? ControladorFormatoReporte { get; set; }
        public string? NombreFormatoReporte { get; set; }
        public int PeriodoId { get; set; }
        public string Periodo { get; set; }
        public char Activo { get; set; }
        public string? Flag { get; set; }
        public string? DependenciaId { get; set; }
        public string? DependenciaSubordinadaId { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescDependenciaSubordinada { get; set; }
        public string? NombrePeriodo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
