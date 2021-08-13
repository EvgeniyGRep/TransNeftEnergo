using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TransNeftEnergo.DTO;

namespace TransNeftApp2.Controllers
{
    public class ExpiredEntityController : BaseController
    {
        public ExpiredEntityController(ILogger<ExpiredEntityController> logger) : base(logger)
        {
        }

        public async Task<IActionResult> Index(string entityType, int? consObjId)
        {
            if (consObjId != null)
            {
                ViewBag.data = await GetListFromApi<ExpiredEntityDTO>($"{rootApiUrl}{entityType}/{consObjId}");
            }
            ViewBag.consObjects = await GetListFromApi<IdName>($"{rootApiUrl}ConsumptionObjects");
            ViewBag.entityType = entityType;
            var rusName = "";
            switch (entityType)
            {
                case "CurrentMeters":
                    rusName = "Счетчики электроэнергии c закончившимся сроком поверки";
                    break;

                case "CurrentTransformers":
                    rusName = "Трансформаторы тока c закончившимся сроком поверки";
                    break;

                case "VoltageTransformers":
                    rusName = "Трансформаторы напряжения c закончившимся сроком поверки";
                    break;
            }
            ViewBag.entityRusName = rusName;
            return View();
        }
    }
}
