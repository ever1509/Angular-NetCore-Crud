using System.ComponentModel.DataAnnotations;

namespace FBTarjeta.Models
{
    public class TarjetaCredito
    {
        public int Id { get; set; }
        [Required]
        public string Titular { get; set; }
        [Required]
        public string NumeroTarjeta { get; set; }
        [Required]
        public string FechaExpiracion { get; set; }
        [Required]
        public string CVV { get; set; }
    }
}
