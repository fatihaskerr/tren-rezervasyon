using Microsoft.AspNetCore.Mvc;
using tren_rezervasyon.Modeller;
using tren_rezervasyon.Servisler;

namespace tren_rezervasyon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RezervasyonController : ControllerBase
    {
        private readonly IRezervasyonServisi _rezervasyonServisi;

        public RezervasyonController(
            IRezervasyonServisi rezervasyonServisi)
        {
            _rezervasyonServisi = rezervasyonServisi;
        }

        [HttpPost]
        public IActionResult RezervasyonYap(
            [FromBody] RezervasyonIstegi istek)
        {
            var sonuc =
                _rezervasyonServisi.RezervasyonKontrolEt(istek);

            return Ok(sonuc);
        }
    }
}