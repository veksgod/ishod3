using bolnica_webapi.Models;

namespace bolnica_webapi.Services.Sucelja;

public interface IOdjelServis
{
    List<Odjel> DohvatiSve();
    Odjel? DohvatiPoId(int id);
    void Dodaj(Odjel odjel);
    void Azuriraj(Odjel odjel);
    void Obrisi(int id);
}