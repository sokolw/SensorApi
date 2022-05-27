using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Globalization;

namespace SensorApi.Controllers
{
    [ApiController]
    // убрать и переписать роутинг
    [Route("[controller]")]
    public class SensorController : ControllerBase
    {
        private static readonly string[] summaries = new[]{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<SensorController> _logger;

        public SensorController(ILogger<SensorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Random random = new Random();
            Sensor sensor = new Sensor
            {
                Id = random.Next(1, 1000),
                Name = $"Sensor-{random.Next(33, 66)}-V",
                OwnerName = $"{summaries[random.Next(0, 10)]}",
                Date = DateTime.Now,
                Glonass = $"не поддерживается",
                GPS = new double[] { random.Next(33, 66), random.Next(33, 66), random.Next(33, 66) },
                Сharge = random.Next(1, 101),
                Indication = random.Next(1, 4000),
            };

            string tempJSON = JsonSerializer.Serialize<Sensor>(sensor, new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            }).ToString(CultureInfo.CurrentCulture);

            return Content(tempJSON);
        }
    }
}
