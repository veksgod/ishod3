using Microsoft.AspNetCore.Mvc;
using bolnica_webapi.Models;
using bolnica_webapi.Services.Sucelja;

namespace bolnica_webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PacijentiController : ControllerBase
{
    private readonly IPacijentServis _pacijentServis;

    public PacijentiController(IPacijentServis pacijentServis)
    {
        _pacijentServis = pacijentServis;
    }

    [HttpGet]
    public ActionResult<List<Pacijent>> Get()
    {
        return Ok(_pacijentServis.DohvatiSve());
    }

    [HttpGet("pretraga")]
    public ActionResult<List<Pacijent>> Pretraga(string ime)
    {
        return Ok(_pacijentServis.PretraziPoImenu(ime));
    }

    [HttpGet("{id}")]
    public ActionResult<Pacijent> Get(int id)
    {
        var pacijent = _pacijentServis.DohvatiPoId(id);

        if (pacijent == null)
            return NotFound();

        return Ok(pacijent);
    }

    [HttpPost]
    public IActionResult Post(Pacijent pacijent)
    {
        _pacijentServis.Dodaj(pacijent);

        return CreatedAtAction(
            nameof(Get),
            new { id = pacijent.Id },
            pacijent);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Pacijent pacijent)
    {
        var postojeci = _pacijentServis.DohvatiPoId(id);

        if (postojeci == null)
            return NotFound();

        pacijent.Id = id;

        _pacijentServis.Azuriraj(pacijent);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var postojeci = _pacijentServis.DohvatiPoId(id);

        if (postojeci == null)
            return NotFound();

        _pacijentServis.Obrisi(id);

        return NoContent();
    }
}