using Microsoft.AspNetCore.Mvc;
using WebAppTest.Services.Actividades;

namespace WebAppTest.Controllers
{
    public class ActividadesController : Controller
    {
        private readonly IActividades _service;

        public ActividadesController(IActividades service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> ActividadesView()
        {
            var products = await _service.GetActividades();
            return View(products);
        }
    }
}
