using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClienteMVC.Models
{
    public class Shipper
    {
            private int shipperID;
            private string? companyName;
            private string? phone;

            // propiedades
            [Key]
            public int ShipperID
            {
                get { return shipperID; }
                set { shipperID = value; }
            }
            [Required(ErrorMessage = "El nombre es obligatorio")]
            [StringLength(40, ErrorMessage = "Solo permite hasta 40 caracteres")]
        [DisplayName("Empresa")]
            public string? CompanyName
            {
                get { return companyName; }
                set { companyName = value; }
            }
        [DisplayName("Teléfono")]
        public string? Phone
            {
                get { return phone; }
                set { phone = value; }
            }
        
    }
}
