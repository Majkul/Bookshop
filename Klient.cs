/// <summary>
/// Klasa reprezentująca klienta sklepu.
/// </summary>
class Klient {
    private string imie, nazwisko, adres;
    private int id;
    private Koszyk koszyk;
    private List<Zamowienie> zamowienia;

    /// <summary>
    /// Konstruktor klasy Klient.
    /// </summary>
    /// <param name="imie">Imię klienta.</param>
    /// <param name="nazwisko">Nazwisko klienta.</param>
    /// <param name="adres">Adres klienta.</param>
    /// <param name="id">Unikalne ID klienta.</param>
    public Klient(string imie, string nazwisko, string adres, int id){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.adres = adres;
        this.id = id;
        koszyk = new Koszyk();
        zamowienia = new List<Zamowienie>();
    }

    /// <summary>
    /// Właściwość Imie, umożliwiająca dostęp do imienia klienta.
    /// </summary>
    public string Imie{ get => imie; set => imie = value; }

    /// <summary>
    /// Właściwość Nazwisko, umożliwiająca dostęp do nazwiska klienta.
    /// </summary>
    public string Nazwisko{ get => nazwisko; set => nazwisko = value; }

    /// <summary>
    /// Właściwość Adres, umożliwiająca dostęp do adresu klienta.
    /// </summary>
    public string Adres{ get => adres; set => adres = value; }

    /// <summary>
    /// Właściwość Id, umożliwiająca dostęp do ID klienta.
    /// </summary>
    public int Id{ get => id; set => id = value; }

    /// <summary>
    /// Właściwość Koszyk, umożliwiająca dostęp do koszyka klienta.
    /// </summary>
    public Koszyk Koszyk{ get => koszyk; set => koszyk = value; }

    /// <summary>
    /// Właściwość Zamowienia, umożliwiająca dostęp do listy zamówień klienta.
    /// </summary>
    public List<Zamowienie> Zamowienia{ get => zamowienia; set => zamowienia = value; }

    /// <summary>
    /// Metoda do zapłaty za zamówienie.
    /// </summary>
    /// <param name="zamowienie">Zamówienie, za które płacimy.</param>
    /// <exception cref="PlatnoscFailedException">Wyjątek rzucany, gdy płatność nieudana.</exception>
    /// <exception cref="ZamowienieIsOplaconeException">Wyjątek rzucany, gdy zamówienie zostało już opłacone.</exception>
    public void zaplac(Zamowienie zamowienie){
        if (zamowienie.Status == "Oczekujące na zapłatę"){
            Platnosc platnosc = new Platnosc();
            if (platnosc.potwierdzenie()){
                zamowienie.zmienStatus("Zapłacone");
            } else {
                throw new PlatnoscFailedException("Płatność nieudana");
            }
        } else {
            throw new ZamowienieIsOplaconeException("Zamówienie zostało już opłacone");
        }
    }

    /// <summary>
    /// Metoda do złożenia zamówienia.
    /// </summary>
    /// <exception cref="KoszykIsEmptyException">Wyjątek rzucany, gdy koszyk jest pusty.</exception>
    public void zamow(){
        if (koszyk.ListaProduktow.Count == 0){
            throw new KoszykIsEmptyException("Koszyk jest pusty");
        }
        Zamowienie zamowienie = new Zamowienie(koszyk, id, adres);
        zamowienie.zmienStatus("Oczekujące na zapłatę");
        zamowienia.Add(zamowienie);
        koszyk = new Koszyk();
        Console.WriteLine("Złożono zamówienie o numerze: "+zamowienie.Numer);
    }

    /// <summary>
    /// Metoda do dodania produktu do koszyka.
    /// </summary>
    /// <param name="produkt">Dodawany produkt.</param>
    /// <exception cref="ProduktIsNotAvailableException">Wyjątek rzucany, gdy produkt niedostępny.</exception>
    public void dodajDoKoszyka(Produkt produkt){
        if (produkt is Fizyczne && ((Fizyczne)produkt).Stan == 0){
            throw new ProduktIsNotAvailableException("Produkt niedostępny");
        }
        koszyk.ListaProduktow.Add(produkt);
        koszyk.Wartosc += produkt.Cena;
    }

    /// <summary>
    /// Metoda do usunięcia produktu z koszyka.
    /// </summary>
    /// <param name="id">ID produktu do usunięcia.</param>
    /// <exception cref="KoszykIsEmptyException">Wyjątek rzucany, gdy koszyk jest pusty.</exception>
    /// <exception cref="ProduktDoesNotExistException">Wyjątek rzucany, gdy produkt nie istnieje w koszyku.</exception>
    public void usunZKoszyka(int id){
        Produkt produkt = koszyk.ListaProduktow.Find(x => x.Id == id);
        if (koszyk.ListaProduktow.Count == 0){
            throw new KoszykIsEmptyException("Koszyk jest pusty");
        }
        if (produkt == null){
            throw new ProduktDoesNotExistException("Produkt nie istnieje w koszyku");
        }
        koszyk.Wartosc -= produkt.Cena;
        koszyk.ListaProduktow.Remove(produkt);
    }

    /// <summary>
    /// Metoda zwracająca status zamówienia o podanym numerze.
    /// </summary>
    /// <param name="numer">Numer zamówienia.</param>
    /// <returns>Status zamówienia.</returns>
    /// <exception cref="ZamowienieDoesNotExistException">Wyjątek rzucany, gdy nie ma takiego zamówienia.</exception>
    public string statusZamowienia(int numer){
        if (numer < 0 || numer >= zamowienia.Count){
            throw new ZamowienieDoesNotExistException("Nie ma takiego zamówienia");
        }
        return zamowienia[numer].Status;
    }

    /// <summary>
    /// Metoda do przeglądania zawartości koszyka.
    /// </summary>
    /// <exception cref="KoszykIsEmptyException">Wyjątek rzucany, gdy koszyk jest pusty.</exception>
    public void przegladaj(){
        if (koszyk.ListaProduktow.Count == 0){
            throw new KoszykIsEmptyException("Koszyk jest pusty");
        }
        foreach(Produkt produkt in koszyk.ListaProduktow){
            Console.WriteLine("[" + produkt.Id + "] " + produkt.Nazwa + ": " + produkt.Cena.ToString("F") + " zł");
        }
        Console.WriteLine("Wartość koszyka: " + koszyk.Wartosc.ToString("F") + " zł");
    }
}