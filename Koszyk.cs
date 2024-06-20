/// <summary>
/// Klasa reprezentująca produkt.
/// </summary>
class Koszyk{
    private List<Produkt> listaProduktow;
    private double wartosc;

    /// <summary>
    /// Konstruktor klasy Koszyk.
    /// </summary>
    public Koszyk(){
        listaProduktow = new List<Produkt>();
        wartosc = 0;
    }

    /// <summary>
    /// Właściwość ListaProduktow, umożliwiająca dostęp do listy produktów w koszyku.
    /// </summary>
    public List<Produkt> ListaProduktow{ get => listaProduktow; set => listaProduktow = value; }

    /// <summary>
    /// Właściwość Wartosc, umożliwiająca dostęp do wartości koszyka.
    /// </summary>
    public double Wartosc{ get => wartosc; set => wartosc = value; }
}
