namespace bolnica_webapi.Models;

public class Odjel
{
    public int Id { get; set; }

    public string Naziv { get; set; } = "";

    public string Opis { get; set; } = "";

    public int BrojPacijenata { get; set; }

    public List<Pacijent> Pacijenti { get; set; } = new();
}