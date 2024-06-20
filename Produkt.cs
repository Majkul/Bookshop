/// <summary>
/// Klasa reprezentująca sprzedawany produkt.
/// </summary>
abstract class Produkt{
    protected string nazwa, autor, kategoria;
    protected double cena;
    protected int id;

    /// <summary>
    /// Konstruktor klasy Produkt.
    /// </summary>
    /// <param name="nazwa">Nazwa produktu.</param>
    /// <param name="id">Unikalne ID produktu.</param>
    /// <param name="autor">Autor produktu.</param>
    /// <param name="kategoria">Kategoeia produktu.</param>
    /// <param name="cena">Cena produktu.</param>
    public Produkt(string nazwa, int id, string autor, string kategoria, double cena){
        this.nazwa = nazwa;
        this.id = id;
        this.autor = autor;
        this.kategoria = kategoria;
        this.cena = cena;
    }

    /// <summary>
    /// Właściwość Nazwa, umożliwiająca dostęp do nazwy produktu.
    /// </summary>
    public string Nazwa{ get => nazwa; set => nazwa = value; }
    /// <summary>
    /// Właściwość Id, umożliwiająca dostęp do ID produktu.
    /// </summary>
    public int Id{ get => id; set => id = value; }
    /// <summary>
    /// Właściwość Autor, umożliwiająca dostęp do autora produktu.
    /// </summary>
    public string Autor{ get => autor; set => autor = value; }
    /// <summary>
    /// Właściwość Kategoria, umożliwiająca dostęp do kategorii produktu.
    /// </summary>
    public string Kategoria{ get => kategoria; set => kategoria = value; }
    /// <summary>
    /// Właściwość Cena, umożliwiająca dostęp do ceny produktu.
    /// </summary>
    public double Cena{ get => cena; set => cena = value; }

    /// <summary>
    /// Porównuje dwa obiekty klasy Produkt po ID.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Produkt other = (Produkt)obj;
        return Id == other.Id;
    }
}

/// <summary>
/// Klasa reprezentująca produkt fizyczny.
/// </summary>
abstract class Fizyczne : Produkt{
    protected int stan;

    /// <summary>
    /// Konstruktor klasy Fizyczne.
    /// </summary>
    /// <param name="nazwa">Nazwa produktu fizycznego.</param>
    /// <param name="id">Unikalne ID produktu fizycznego.</param>
    /// <param name="autor">Autor produktu fizycznego.</param>
    /// <param name="kategoria">Kategoria produktu fizycznego.</param>
    /// <param name="cena">Cena produktu fizycznego.</param>
    /// <param name="stan">Stan produktu fizycznego.</param>
    public Fizyczne(string nazwa, int id, string autor, string kategoria, double cena, int stan) : base(nazwa, id, autor, kategoria, cena){
        this.stan = stan;
    }

    /// <summary>
    /// Właściwość Stan, umożliwiająca dostęp do stanu produktu fizycznego.
    /// </summary>
    public int Stan{ get => stan; set => stan = value; }
}

/// <summary>
/// Klasa reprezentująca produkt cyfrowy.
/// </summary>
abstract class Cyfrowe : Produkt{
    /// <summary>
    /// Konstruktor klasy Cyfrowe.
    /// </summary>
    /// <param name="nazwa">Nazwa produktu cyfrowego.</param>
    /// <param name="id">Unikalne ID produktu cyfrowego.</param>
    /// <param name="autor">Autor produktu cyfrowego.</param>
    /// <param name="kategoria">Kategoria produktu cyfrowego.</param>
    /// <param name="cena">Cena produktu cyfrowego.</param>
    public Cyfrowe(string nazwa, int id, string autor, string kategoria, double cena) : base(nazwa, id, autor, kategoria, cena) { }
}

/// <summary>
/// Klasa reprezentująca książkę z twardą okładką.
/// </summary>
class Twarda_okladka : Fizyczne{
    /// <summary>
    /// Konstruktor klasy Twarda_okladka.
    /// </summary>
    /// <param name="nazwa">Nazwa książki z twardą okładką.</param>
    /// <param name="id">Unikalne ID książki z twardą okładką.</param>
    /// <param name="autor">Autor książki z twardą okładką.</param>
    /// <param name="kategoria">Kategoria książki z twardą okładką.</param>
    /// <param name="cena">Cena książki z twardą okładką.</param>
    /// <param name="stan">Stan książki z twardą okładką.</param>
    public Twarda_okladka(string nazwa, int id, string autor, string kategoria, double cena, int stan) : base(nazwa, id, autor, kategoria, cena, stan) { }
}

/// <summary>
/// Klasa reprezentująca książkę z miękką okładką.
/// </summary>
class Miekka_okladka : Fizyczne{
    /// <summary>
    /// Konstruktor klasy Miekka_okladka.
    /// </summary>
    /// <param name="nazwa">Nazwa książki z miękką okładką.</param>
    /// <param name="id">Unikalne ID książki z miękką okładką.</param>
    /// <param name="autor">Autor książki z miękką okładką.</param>
    /// <param name="kategoria">Kategoria książki z miękką okładką.</param>
    /// <param name="cena">Cena książki z miękką okładką.</param>
    /// <param name="stan">Stan książki z miękką okładką.</param>
    public Miekka_okladka(string nazwa, int id, string autor, string kategoria, double cena, int stan) : base(nazwa, id, autor, kategoria, cena, stan) { }
}

/// <summary>
/// Klasa reprezentująca audiobook.
/// </summary>
class Audiobook : Cyfrowe{
    /// <summary>
    /// Konstruktor klasy Audiobook.
    /// </summary>
    /// <param name="nazwa">Nazwa audiobooka.</param>
    /// <param name="id">Unikalne ID audiobooka.</param>
    /// <param name="autor">Autor audiobooka.</param>
    /// <param name="kategoria">Kategoria audiobooka.</param>
    /// <param name="cena">Cena audiobooka.</param>
    public Audiobook(string nazwa, int id, string autor, string kategoria, double cena) : base(nazwa, id, autor, kategoria, cena) { }
}

/// <summary>
/// Klasa reprezentująca e-book.
/// </summary>
class E_book : Cyfrowe{
    /// <summary>
    /// Konstruktor klasy E_book.
    /// </summary>
    /// <param name="nazwa">Nazwa e-booka.</param>
    /// <param name="id">Unikalne ID e-booka.</param>
    /// <param name="autor">Autor e-booka.</param>
    /// <param name="kategoria">Kategoria e-booka.</param>
    /// <param name="cena">Cena e-booka.</param>
    public E_book(string nazwa, int id, string autor, string kategoria, double cena) : base(nazwa, id, autor, kategoria, cena) { }
}
