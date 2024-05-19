using System.ComponentModel.DataAnnotations;

namespace ServicioNW.Models
{
    public class LoginUsuario
    {
        [Key]
        public int ID { get; set; }
        public int MyProperty { get; set; }
    }
}
