namespace ClienteMVC.Models
{
    public class VM_ListaPrecio
    {
        public int Id { get; set; }
        public string? Categoria { get; set; }
        public string? Proveedor { get; set; }
        public string? Nombre { get; set; }
        public decimal? Precio { get; set; }
    }
}
