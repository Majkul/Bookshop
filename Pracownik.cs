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
                if(fizycznyProdukt.get_set_stan == 0){
                    throw new Exception("Produkt nie jest dostepny");
                }
                zamowienie.kompletuj(produkt);  
            }
            zamowienie.generujLink(zamowienie.IdKlienta, produkt);
        }
        zamowienie.zmienStatus("Zrealizowane");
        magazyn.get_set_zamowieniaZrealizowane.Add(zamowienie);
        magazyn.get_set_zamowieniaDoRealizacji.Remove(zamowienie);
    }
    public void zamowKuriera(Kurier kurier){
        List<Zamowienie> zamowienia_do_wyslania = magazyn.get_set_zamowieniaZrealizowane;
        if(zamowienia_do_wyslania.Count == 0){
            throw new Exception("Brak zamowien do wyslania");
        }
        Kurier nowe_zamowienie_kuriera = new Kurier(zamowienia_do_wyslania);
        foreach(Zamowienie zamowienie in zamowienia_do_wyslania){
            zamowienie.zmienStatus("Wyslane");
        }
        //return nowe_zamowienie_kuriera;
    }
    public void dodajProdukt(string nazwa, int id, double cena, string autor, string kategoria){
        if(nazwa == null){
            throw new Exception("Nie podano nazwy");
        }
        if(cena < 0){
            throw new Exception("Cena nie moze byc ujemna");
        }
        if(magazyn.znajdzProdukt(id) != null){
            throw new Exception("Produkt o podanym id juz istnieje i jest w magazynie");
        }
        magazyn.get_set_produkty.Add(new Produkt(nazwa, id, cena, autor, kategoria));
    }
    public void usunProdukt(int id){
        Produkt szukany = magazyn.znajdzProdukt(id);
        if(szukany == null){
            throw new Exception("Produkt o podanym id nie istnieje");
        }
        magazyn.get_set_produkty.Remove(szukany);
    }
    public void ustawStan(int id, int stan){
        Produkt szukany = magazyn.znajdzProdukt(id);
        if(szukany == null){
            throw new Exception("Produkt o podanym id nie istnieje");
        }
        if(szukany is Fizyczne fizycznyProdukt){
            
            fizycznyProdukt.get_set_stan = stan;
            throw new Exception("Produkt nie jest fizyczny");
        }
    }
}