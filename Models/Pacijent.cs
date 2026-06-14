namespace bolnica_webapi.Models;

public class Pacijent
{
    public int Id { get; set; }

    public string Ime { get; set; } = "";

    public string Prezime { get; set; } = "";

    public string Telefon { get; set; } = "";

    public DateTime DatumRodenja { get; set; }

    public bool Aktivan { get; set; }

    public int? OdjelId { get; set; }

    public Odjel? Odjel { get; set; }
}