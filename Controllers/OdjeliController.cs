using Microsoft.AspNetCore.Mvc;
using bolnica_webapi.Models;
using bolnica_webapi.Services.Sucelja;

namespace bolnica_webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OdjeliController : ControllerBase
{
    private readonly IOdjelServis _odjelServis;

    public OdjeliController(IOdjelServis odjelServis)
    {
        _odjelServis = odjelServis;
    }

    [HttpGet]
    public ActionResult<List<Odjel>> Get()
    {
        var odjeli = _odjelServis.DohvatiSve();
        return Ok(odjeli);
    }

    [HttpGet("{id}")]
    public ActionResult<Odjel> Get(int id)
    {
        var odjel = _odjelServis.DohvatiPoId(id);

        if (odjel == null)
            return NotFound();

        return Ok(odjel);
    }

    [HttpPost]
    public IActionResult Post(Odjel odjel)
    {
        _odjelServis.Dodaj(odjel);

        return CreatedAtAction(nameof(Get), new { id = odjel.Id }, odjel);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Odjel odjel)
    {
        var postojeci = _odjelServis.DohvatiPoId(id);

        if (postojeci == null)
            return NotFound();

        odjel.Id = id;

        _odjelServis.Azuriraj(odjel);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var postojeci = _odjelServis.DohvatiPoId(id);

        if (postojeci == null)
            return NotFound();

        _odjelServis.Obrisi(id);

        return NoContent();
    }
}