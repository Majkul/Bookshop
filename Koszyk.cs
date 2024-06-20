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

    /// <value>
    /// Właściwość ListaProduktow, umożliwiająca dostęp do listy produktów w koszyku.
    /// </value>
    public List<Produkt> ListaProduktow{ get => listaProduktow; set => listaProduktow = value; }

    /// <value>
    /// Właściwość Wartosc, umożliwiająca dostęp do wartości koszyka.
    /// </value>
    public double Wartosc{ get => wartosc; set => wartosc = value; }
}
