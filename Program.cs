using System;
class Magazyn{
    private int id;
    private List<int> produkty;
    //private List<Produkt> produkty;
    private List<int> zamowieniaDoRealizacji;
    //private List<Zamowienie> zamowieniaDoRealizacji;
    private List<int> zamowieniaZrealizowane;
    //private List<Zamowienie> zamowieniaZrealizowane;
    public Magazyn(int id){
        this.id = id;
        produkty = new List<int>();
        zamowieniaDoRealizacji = new List<int>();
        zamowieniaZrealizowane = new List<int>();
    }

}
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
        //zamowienie.kompletuj();
        //zamowienie.zmienStatus("Zrealizowane");
        //magazyn.zamowieniaZrealizowane.Add(zamowienie);
        //magazyn.zamowieniaDoRealizacji.Remove(zamowienie);
    }
    public void zamowKuriera(Kurier kurier){
        zamowienia_do_wyslania = magazyn.zamowieniaZrealizowane;
        nowe_zamowienie_kuriera = new Kurier(zamowienia_do_wyslania);
        foreach(zamowienie in zamowienia_do_wyslania){
            zamowienie.zmienStatus("Wyslane");
        }
    }
    public void dodajProdukt(string nazwa, int id, double cena){
        magazyn.produkty.Add(new Produkt(nazwa, id, cena));
    }
    public void dodajProdukt(Produkt produkt){
        magazyn.produkty.Add(new Produkt(produkt));
    }
    public void usunProdukt(int id){
        //magazyn.produkty.Remove(id);
    }
    public void ustawStan(int id, int stan){
        //magazyn.produkty[id].ustawStan(stan);
    }
}