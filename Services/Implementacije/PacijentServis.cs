using bolnica_webapi.Data;
using bolnica_webapi.Models;
using bolnica_webapi.Services.Sucelja;

namespace bolnica_webapi.Services.Implementacije;

public class PacijentServis : IPacijentServis
{
    private readonly ApplicationDbContext _context;

    public PacijentServis(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Pacijent> DohvatiSve()
    {
        return _context.Pacijenti.ToList();
    }

    public Pacijent? DohvatiPoId(int id)
    {
        return _context.Pacijenti.FirstOrDefault(p => p.Id == id);
    }

    public List<Pacijent> PretraziPoImenu(string ime)
    {
        return _context.Pacijenti
            .Where(p => p.Ime.Contains(ime))
            .ToList();
    }

    public void Dodaj(Pacijent pacijent)
    {
        _context.Pacijenti.Add(pacijent);
        _context.SaveChanges();
    }

    public void Azuriraj(Pacijent pacijent)
    {
        _context.Pacijenti.Update(pacijent);
        _context.SaveChanges();
    }

    public void Obrisi(int id)
    {
        var pacijent = _context.Pacijenti.Find(id);

        if (pacijent != null)
        {
            _context.Pacijenti.Remove(pacijent);
            _context.SaveChanges();
        }
    }
}