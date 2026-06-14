using bolnica_webapi.Data;
using bolnica_webapi.Models;
using bolnica_webapi.Services.Sucelja;
using Microsoft.EntityFrameworkCore;

namespace bolnica_webapi.Services.Implementacije;

public class OdjelServis : IOdjelServis
{
    private readonly ApplicationDbContext _context;

    public OdjelServis(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Odjel> DohvatiSve()
    {
        return _context.Odjeli
            .Include(o => o.Pacijenti)
            .ToList();
    }

    public Odjel? DohvatiPoId(int id)
    {
        return _context.Odjeli
            .Include(o => o.Pacijenti)
            .FirstOrDefault(o => o.Id == id);
    }

    public void Dodaj(Odjel odjel)
    {
        _context.Odjeli.Add(odjel);
        _context.SaveChanges();
    }

    public void Azuriraj(Odjel odjel)
    {
        _context.Odjeli.Update(odjel);
        _context.SaveChanges();
    }

    public void Obrisi(int id)
    {
        var odjel = _context.Odjeli.Find(id);

        if (odjel != null)
        {
            _context.Odjeli.Remove(odjel);
            _context.SaveChanges();
        }
    }
}