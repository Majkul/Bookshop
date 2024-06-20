using System;
class Pracownik{
    private string imie;
    private string nazwisko;
    private int id;
    private Magazyn magazyn;
    public Pracownik(string imie, string nazwisko, int id, Magazyn magazyn){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.id = id;
        this.magazyn = magazyn;
    }
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
    public void usunProdukt(int id){
        Produkt szukany = magazyn.znajdzProdukt(id);
        if(szukany == null){
            throw new ProduktDoesNotExistException("Produkt o podanym id nie istnieje");
        }
        magazyn.Produkty.Remove(szukany);
    }
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