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
        zamowienie = magazyn.zamowieniaDoRealizacji[idZamowienia];
        if(!zamowinie){
            throw new Exception("Nie ma takiego zamowienia");
        }
        //zamowienie.kompletuj();
        //zamowienie.zmienStatus("Zrealizowane");
        //magazyn.zamowieniaZrealizowane.Add(zamowienie);
        //magazyn.zamowieniaDoRealizacji.Remove(zamowienie);
    }
    public void zamowKuriera(Kurier kurier){
        zamowienia_do_wyslania = magazyn.zamowieniaZrealizowane;
        if(zamowienia_do_wyslania.Count == 0){
            throw new Exception("Brak zamowien do wyslania");
        }
        nowe_zamowienie_kuriera = new Kurier(zamowienia_do_wyslania);
        foreach(zamowienie in zamowienia_do_wyslania){
            zamowienie.zmienStatus("Wyslane");
        }
    }
    public void dodajProdukt(string nazwa, int id, double cena){
        if(nazwa == null){
            throw new Exception("Nie podano nazwy");
        }
        if(cena < 0){
            throw new Exception("Cena nie moze byc ujemna");
        }
        if(magazyn.produkty.Contains(id)){
            throw new Exception("Produkt o podanym id juz istnieje i jest w magazynie");
        }
        magazyn.produkty.Add(new Produkt(nazwa, id, cena));
    }
    public void usunProdukt(int id){
        if(!magazyn.produkty.Contains(id)){
            throw new Exception("Produkt o podanym id nie istnieje");
        }
        //magazyn.produkty.Remove(id);
    }
    public void ustawStan(int id, int stan){
        if(!magazyn.produkty.Contains(id)){
            throw new Exception("Produkt o podanym id nie istnieje");
        }
        //magazyn.produkty[id].ustawStan(stan);
    }
}