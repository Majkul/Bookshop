/// <summary>
/// Klasa reprezentująca magazyn.
/// </summary>
class Magazyn{
    private int id;

    /// <value>
    /// Właściwość Id, umożliwiająca dostęp do ID magazynu.
    /// </value>
    public int Id
    {
        get { return id; }
    }
    private List<Produkt> produkty;
    /// <value>
    /// Właściwość Produkty, umożliwiająca dostęp do listy produktów w magazynie.
    /// </value>
    public List<Produkt> Produkty
    {
        get { return produkty; }
        set { produkty = value; }
    }
    private List<Zamowienie> zamowieniaDoRealizacji;
    
    /// <value>
    /// Właściwość ZamowieniaDoRealizacji, umożliwiająca dostęp do listy zamówień do realizacji.
    /// </value>
    public List<Zamowienie> ZamowieniaDoRealizacji
    {
        get { return zamowieniaDoRealizacji; }
    }

    private List<Zamowienie> zamowieniaZrealizowane;

    /// <value>
    /// Właściwość ZamowieniaZrealizowane, umożliwiająca dostęp do listy zamówień zrealizowanych.
    /// </value>
    public List<Zamowienie> ZamowieniaZrealizowane
    {
        get { return zamowieniaZrealizowane; }
    }

    /// <summary>
    /// Konstruktor klasy Magazyn.
    /// </summary>
    /// <param name="id">Unikalne ID magazynu.</param>
    /// <param name="produkty">Lista produktów w magazynie.</param>
    /// <param name="zamowieniaDoRealizacji">Lista zamówień do realizacji.</param>
    /// <param name="zamowieniaZrealizowane">Lista zamówień zrealizowanych.</param>
    public Magazyn(int id){
        this.id = id;
        produkty = new List<Produkt>();
        zamowieniaDoRealizacji = new List<Zamowienie>();
        zamowieniaZrealizowane = new List<Zamowienie>();
    }

    /// <summary>
    /// Metoda szukająca zamówienia niezrealizowanego o podanym numerze.
    /// </summary>
    /// <param name="numer">Numer zamówienia.</param>
    /// <returns>Zamówienie o podanym numerze.</returns>
    /// <exception cref="ZamowienieDoesNotExistException">Wyjątek rzucany, gdy zamówienie nie istnieje.</exception>
    public Zamowienie znajdzZamowienie(int numer){
        Zamowienie zamowienie = zamowieniaDoRealizacji.Find(x => x.Numer == numer);
        if(zamowienie == null){
            throw new ZamowienieDoesNotExistException("Nie ma takiego zamowienia");
        }
        return zamowienie;
    }

    /// <summary>
    /// Metoda szukająca produktu o podanym ID.
    /// </summary>
    /// <param name="id">ID produktu.</param>
    /// <returns></returns>
    /// <exception cref="ProduktDoesNotExistException">Wyjątek rzucany, gdy produkt nie istnieje w magazynie.</exception>
    public Produkt znajdzProdukt(int id){
        Produkt produkt = produkty.Find(x => x.Id == id);
        if(produkt == null){
            throw new ProduktDoesNotExistException("Nie ma takiego produktu w magazynie");
        }
        return produkt;
    }

    /// <summary>
    /// Metoda dodająca zamówienie do magazynu podczas wczytywania.
    /// </summary>
    /// <param name="zamowienie">Dodawane zamówienie.</param>
    public void dodajZamowienieDoMagazynu(Zamowienie zamowienie){
        if (zamowienie.Status == "Zaplacone"){
            zamowieniaDoRealizacji.Add(zamowienie);
        }
        else if (zamowienie.Status == "Zrealizowane" || zamowienie.Status == "Wysłane" || zamowienie.Status == "Dostarczone"){
            zamowieniaZrealizowane.Add(zamowienie);
        }
    }
}
