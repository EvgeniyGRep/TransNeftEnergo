using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TransNeftEnergo.DTO;
using TransNeftEnergo.Models;

namespace TransNeftApp2.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddMeasuringPoint()
        {
            ViewBag.currentMeters = await GetListFromApi<IdNumber>($"{rootApiUrl}CurrentMeters");
            ViewBag.currentTransformers = await GetListFromApi<IdNumber>($"{rootApiUrl}CurrentTransformers");
            ViewBag.voltageTransformers = await GetListFromApi<IdNumber>($"{rootApiUrl}VoltageTransformers");
            ViewBag.consObjects = await GetListFromApi<IdName>($"{rootApiUrl}ConsumptionObjects");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMeasuringPoint(PostPowerMeasuringPointParam p)
        {
            var content = JsonContent.Create(p);
            var data = await client.PostAsync($"{rootApiUrl}PowerMeasuringPoints", content);
            ViewBag.NewEntity = await data.Content.ReadFromJsonAsync<PowerMeasuringPoint>();
            ViewBag.Message = "Точка добавлена";
            return View();
        }

        public async Task<IActionResult> CalculatingMeters(int? year)
        {
            ViewBag.year = year;
            if (year != null)
            {
                ViewBag.data = await GetListFromApi<CalculatingMeterDTO>($"{rootApiUrl}CalculatingMeters/{year}");
            }
            return View();
        }
    }
}
