using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class ZarpeRetornoNavePeruanaDTO
    {

        public int? ZarpeRetornoNavePeruanaId { get; set; }
        public int? Numero { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public string? HoraCaptura { get; set; }
        public int? DiaCaptura { get; set; }
        public int? MesId { get; set; }
        public int? AnioCaptura { get; set; }
        public string? NombreNavePeruana { get; set; }
        public string? MatriculaNavePeruana { get; set; }
        public int? TipoNaveId { get; set; }
        public int? AutoridadEmiteZarpeId { get; set; }
        public string? HoraArribo { get; set; }
        public int? DiaArribo { get; set; }
        public int? MesArribo { get; set; }
        public int? AnioArribo { get; set; }
        public int? PuertoPeruId { get; set; }
        public int? JefaturaCapitaniaId { get; set; }
        public string? Observaciones { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? DescMes { get; set; }
        public string? DescTipoNave { get; set; }
        public string? DescAutoridadEmiteZarpe { get; set; }
        public string? DescPuertoPeru { get; set; }
        public string? DescJefaturaCapitania { get; set; }
        public string? DescMesArribo { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
