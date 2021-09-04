using APICase.Models;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace APICase.Controllers
{
    [ApiController]
    [Route("afstand")]
    public class GeolocationController : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> GetAfstand([FromQuery] AdresAfstandDTO adresAfstand)
        {

            Location l1 = GetLatandLon(adresAfstand.adres1);
            Location l2 = GetLatandLon(adresAfstand.adres2);

            if (String.IsNullOrEmpty(l1.lat) || String.IsNullOrEmpty(l1.lon) || String.IsNullOrEmpty(l2.lat) || String.IsNullOrEmpty(l2.lon))
            {
                return BadRequest();
            }
            string afstand = $"afstand: { CalculateAfstand(l1, l2) } KM";

            return Ok(afstand);
        }

        private Location GetLatandLon(AdresDTO adres)
        {
            var webClient = new WebClient();

            webClient.Headers.Add("user-agent", "Mozilla/4.0(compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            byte[] adresData = webClient.DownloadData("http://nominatim.openstreetmap.org/search?q=" + adres.Huisnummer + "+" + adres.Straat + ",+" + adres.Plaats + "&format=json");

            string adresDataString = Encoding.UTF8.GetString(adresData);

            List<Location> locationList = JsonConvert.DeserializeObject<List<Location>>(adresDataString);

            webClient.Dispose();

            return locationList[0];
        }

        private double CalculateAfstand(Location l1, Location l2)
        {
            int meterToKilometer = 1000;

            var cord1 = new GeoCoordinate(Convert.ToDouble(l1.lat) , Convert.ToDouble(l1.lon));

            var cord2 = new GeoCoordinate(Convert.ToDouble(l2.lat), Convert.ToDouble(l2.lon));

            return cord1.GetDistanceTo(cord2) / meterToKilometer;
        }
    }
}
