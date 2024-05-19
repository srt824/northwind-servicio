using ClienteMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteMVC.Controllers
{
    public class EnviosController : Controller
    {
        // variable string que representa el endpoint
        string url = "https://localhost:7224/api/shipper";
        HttpClient cliente = new HttpClient();
        public async Task<IActionResult> Index()
        {
            var lista = JsonConvert.DeserializeObject<List<Shipper>> (await cliente.GetStringAsync(url)).ToList();
            return View("Index", lista);
        }
        [HttpGet]
        public IActionResult Agregar()
        {
            Shipper shipper = new Shipper();
            shipper.Phone = "(054)";
            return View(shipper);
        }
        [HttpPost]
        public async Task<IActionResult> Agregar(Shipper nuevo)
        {
            // consumir web API
            await cliente.PostAsJsonAsync(url, nuevo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Shipper shipper = null;
            string urlID = url + "/" + id;
            var respuesta = cliente.GetAsync(urlID);
            respuesta.Wait();
            var resultado = respuesta.Result;
            if (resultado.IsSuccessStatusCode)
            {
                var leoDes = resultado.Content.ReadAsAsync<Shipper>();
                leoDes.Wait();
                shipper = leoDes.Result;
            }
            return View(shipper);
        }
        [HttpPost]
        public IActionResult Edit(Shipper shipper)
        {
            string urlID = url + "/" + shipper.ShipperID;
            var put = cliente.PutAsJsonAsync<Shipper>(urlID, shipper);
            put.Wait();
            var resultadoPut = put.Result;
            if (resultadoPut.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(shipper);
        }
    }
}
