namespace Assessment.Models
{
  public class TimelogTypeAPI
  {
    // Ruft die eindeutige ID für den TimelogType ab oder legt sie fest.
    public int TimelogTypeId { get; set; }

    // Ruft den Namen des TimelogType ab oder legt ihn fest.
    public string TimelogType { get; set; }

    // Ruft das Budget (die Menge an Zeit) für den TimelogType ab oder legt es fest.
    public float Budget { get; set; }
  }
}
