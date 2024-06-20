using System;
/// <summary>
/// Klasa reprezentująca pracownika.
/// </summary>
class Pracownik{
    private string imie;
    private string nazwisko;
    private int id;
    private Magazyn magazyn;

    /// <summary>
    /// Konstruktor klasy Pracownik.
    /// </summary>
    /// <param name="imie">Imię pracownika.</param>
    /// <param name="nazwisko">Nazwisko pracownika.</param>
    /// <param name="id">Unikalne ID pracownika.</param>
    /// <param name="magazyn">Magazyn, w którym pracuje pracownik.</param>
    public Pracownik(string imie, string nazwisko, int id, Magazyn magazyn){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.id = id;
        this.magazyn = magazyn;
    }

    /// <summary>
    /// Metoda realizująca zamówienie o podanym numerze.
    /// </summary>
    /// <param name="numer">Numer zamówienia.</param>
    /// <exception cref="ProduktIsNotAvailableException">Wyjątek rzucany, gdy produkt nie jest dostępny.</exception>
    public void realizaZamowienie(int numer){
        Zamowienie zamowienie = magazyn.znajdzZamowienie(numer);
        //Kompletowanie zamówienia produktami, które zostały zamówione, można dodać exception jak się okazuje jednak że nie ma produktu na stanie
        foreach(Produkt produkt in zamowienie.ListaProduktow){
            if (produkt is Fizyczne fizycznyProdukt){
                if(fizycznyProdukt.Stan == 0){
                    throw new ProduktIsNotAvailableException("Produkt niedostepny");
                }
                ustawStan(fizycznyProdukt.Id, fizycznyProdukt.Stan - 1);
            }
        }
        zamowienie.zmienStatus("Zrealizowane");
        magazyn.ZamowieniaZrealizowane.Add(zamowienie);
        magazyn.ZamowieniaDoRealizacji.Remove(zamowienie);
    }

    /// <summary>
    /// Metoda zwracająca informacje o zamówieniach do realizacji.
    /// </summary>
    /// <param name="kurier">Kurier, który ma dostarczyć zamówienia.</param>
    /// <exception cref="BrakZamowienDoWyslaniaException">Wyjątek rzucany, gdy nie ma zamówień do wysłania.</exception>
    public void zamowKuriera(Kurier kurier){
        if(magazyn.ZamowieniaZrealizowane.Count == 0){
            throw new BrakZamowienDoWyslaniaException("Brak zamowien do wyslania");
        }
        foreach(Zamowienie zamowienie in magazyn.ZamowieniaZrealizowane){
            zamowienie.zmienStatus("Wyslane");
            kurier.Zamowienia.Add(zamowienie);
        }
        magazyn.ZamowieniaZrealizowane.Clear();
    }

    /// <summary>
    /// Metoda dodająca produkt do magazynu.
    /// </summary>
    /// <param name="nazwa">Nazwa produktu.</param>
    /// <param name="id">Unikalne ID produktu.</param>
    /// <param name="cena">Cena produktu.</param>
    /// <param name="autor">Autor produktu.</param>
    /// <param name="kategoria">Kategoria produktu.</param>
    /// <param name="type">Typ produktu.</param>
    /// <param name="stan">Stan produktu.</param>
    /// <exception cref="WrongProductNameException">Wyjątek rzucany, gdy nie podano nazwy produktu.</exception>
    /// <exception cref="WrongPriceException">Wyjątek rzucany, gdy cena produktu jest ujemna.</exception>
    /// <exception cref="WrongTypeException">Wyjątek rzucany, gdy podano niepoprawny typ produktu.</exception>
    public void dodajProdukt(string nazwa, int id, double cena, string autor, string kategoria, int type, int stan){
        if(nazwa == null){
            throw new WrongProductNameException("Nie podano nazwy");
        }
        if(cena < 0){
            throw new WrongPriceException("Cena nie moze byc ujemna");
        }
        try{
            magazyn.znajdzProdukt(id);
        }
        catch(ProduktDoesNotExistException){
            switch(type){
            case 0:
                magazyn.Produkty.Add(new Twarda_okladka(nazwa, id, autor, kategoria, cena, stan));
                break;
            case 1:
                magazyn.Produkty.Add(new Miekka_okladka(nazwa, id, autor, kategoria, cena, stan));
                break;
            case 2:
                magazyn.Produkty.Add(new Audiobook(nazwa, id, autor, kategoria, cena));
                break;
            case 3:
                magazyn.Produkty.Add(new E_book(nazwa, id, autor, kategoria, cena));
                break;
            default:
                throw new WrongTypeException("Niepoprawny typ produktu");
            }
        }
    }

    /// <summary>
    /// Metoda usuwająca produkt o podanym ID.
    /// </summary>
    /// <param name="id">ID produktu.</param>
    /// <exception cref="ProduktDoesNotExistException">Wyjątek rzucany, gdy produkt o podanym ID nie istnieje.</exception>
    public void usunProdukt(int id){
        Produkt szukany = magazyn.znajdzProdukt(id);
        if(szukany == null){
            throw new ProduktDoesNotExistException("Produkt o podanym id nie istnieje");
        }
        magazyn.Produkty.Remove(szukany);
    }

    /// <summary>
    /// Metoda zmieniająca stan produktu o podanym ID.
    /// </summary>
    /// <param name="id">ID produktu.</param>
    /// <param name="stan">Nowy stan produktu.</param>
    /// <exception cref="ProduktDoesNotExistException">Wyjątek rzucany, gdy produkt o podanym ID nie istnieje.</exception>
    /// <exception cref="ProduktIsNotPhysicalException">Wyjątek rzucany, gdy produkt nie jest fizyczny.</exception>
    public void ustawStan(int id, int stan){
        Produkt szukany = magazyn.znajdzProdukt(id);
        if(szukany == null){
            throw new ProduktDoesNotExistException("Produkt o podanym id nie istnieje");
        }
        if(szukany is Fizyczne fizycznyProdukt){
            fizycznyProdukt.Stan = stan;
        }
        else{
            throw new ProduktIsNotPhysicalException("Produkt nie jest fizyczny");
        }
    }
}