using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class AlistamientoCombustibleLubricanteComfasDTO
    {

        public int? AlistamientoCombustibleLubricanteId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? SistemaCombustibleLubricanteId { get; set; }
        public int? SubsistemaCombustibleLubricanteId { get; set; }
        public int? Equipo { get; set; }
        public int? CombustibleLubricante { get; set; }
        public int? ExistenteGLS { get; set; }
        public int? NecesariasGLS { get; set; }
        public int? CoeficientePonderacion { get; set; }



        public string? DescUnidadNaval { get; set; }
        public string? DescSistemaCombustibleLubricante { get; set; }
        public string? DescSubsistemaCombustibleLubricante { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
