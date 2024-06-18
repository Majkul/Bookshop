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
        if(zamowienie == null){
            throw new Exception("Nie ma takiego zamowienia");
        }
        //Kompletowanie zamówienia produktami, które zostały zamówione, można dodać exception jak się okazuje jednak że nie ma produktu na stanie
        foreach(Produkt produkt in zamowienie.ListaProduktow){
            if (produkt is Fizyczne fizycznyProdukt){
                if(fizycznyProdukt.Stan == 0){
                    throw new Exception("Produkt nie jest dostepny");
                }
                zamowienie.kompletuj(produkt);  
            }
            zamowienie.generujLink(zamowienie.IdKlienta, produkt);
        }
        zamowienie.zmienStatus("Zrealizowane");
        magazyn.ZamowieniaZrealizowane.Add(zamowienie);
        magazyn.ZamowieniaDoRealizacji.Remove(zamowienie);
    }
    public Kurier zamowKuriera(){
        List<Zamowienie> zamowienia_do_wyslania = magazyn.ZamowieniaZrealizowane;
        if(zamowienia_do_wyslania.Count == 0){
            throw new Exception("Brak zamowien do wyslania");
        }
        Kurier nowe_zamowienie_kuriera = new Kurier(zamowienia_do_wyslania);
        foreach(Zamowienie zamowienie in zamowienia_do_wyslania){
            zamowienie.zmienStatus("Wyslane");
        }
        return nowe_zamowienie_kuriera;
    }
    public void dodajProdukt(string nazwa, int id, double cena, string autor, string kategoria, int type, int stan){
        if(nazwa == null){
            throw new Exception("Nie podano nazwy");
        }
        if(cena < 0){
            throw new Exception("Cena nie moze byc ujemna");
        }
        if(magazyn.znajdzProdukt(id) != null){
            throw new Exception("Produkt o podanym id juz istnieje i jest w magazynie");
        }
        switch(type){
            case 0:
                magazyn.Produkty.Add(new Twarda_okladka(nazwa, id, autor, kategoria, cena, stan));
                break;
            case 1:
                magazyn.Produkty.Add(new Miekka_okladka(nazwa, id, autor, kategoria, cena, stan));
                break;
            case 2:
                magazyn.Produkty.Add(new Audiobook(nazwa, id, autor, kategoria, cena, "blablabla")); //link do audiobooka
                break;
            case 3:
                magazyn.Produkty.Add(new E_book(nazwa, id, autor, kategoria, cena, "blablabla"));
                break;
        }
    }
    public void usunProdukt(int id){
        Produkt szukany = magazyn.znajdzProdukt(id);
        if(szukany == null){
            throw new Exception("Produkt o podanym id nie istnieje");
        }
        magazyn.Produkty.Remove(szukany);
    }
    public void ustawStan(int id, int stan){
        Produkt szukany = magazyn.znajdzProdukt(id);
        if(szukany == null){
            throw new Exception("Produkt o podanym id nie istnieje");
        }
        if(szukany is Fizyczne fizycznyProdukt){
            
            fizycznyProdukt.Stan = stan;
            throw new Exception("Produkt nie jest fizyczny");
        }
    }
}