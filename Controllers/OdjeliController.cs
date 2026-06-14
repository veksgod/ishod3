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
        return _odjelServis.DohvatiSve();
    }

    [HttpGet("{id}")]
    public ActionResult<Odjel> Get(int id)
    {
        var odjel = _odjelServis.DohvatiPoId(id);

        if (odjel == null)
            return NotFound();

        return odjel;
    }

    [HttpPost]
    public IActionResult Post(Odjel odjel)
    {
        _odjelServis.Dodaj(odjel);

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Odjel odjel)
    {
        odjel.Id = id;

        _odjelServis.Azuriraj(odjel);

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _odjelServis.Obrisi(id);

        return Ok();
    }
}