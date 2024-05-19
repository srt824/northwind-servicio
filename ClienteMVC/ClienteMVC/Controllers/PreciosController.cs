using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ClienteMVC.Controllers
{
    public class PreciosController : Controller
    {
        string url = "https://localhost:7280/api/VM_Productos";
        HttpClient cliente = new HttpClient();

        public async Task<IActionResult> Index()
        {
            // llamo a la web api rest y convierto en una lista de precios.
            var lista = JsonConvert.DeserializeObject<List<Models.VM_ListaPrecio>>(await cliente.GetStringAsync(url)).ToList();

            return View("Index", lista);
        }
    }
}
