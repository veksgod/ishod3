using bolnica_webapi.Models;

namespace bolnica_webapi.Services.Sucelja;

public interface IPacijentServis
{
    List<Pacijent> DohvatiSve();
    Pacijent? DohvatiPoId(int id);
    List<Pacijent> PretraziPoImenu(string ime);
    void Dodaj(Pacijent pacijent);
    void Azuriraj(Pacijent pacijent);
    void Obrisi(int id);
}