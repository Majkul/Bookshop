class Klient {
    private string imie, nazwisko, adres;
    private int id;
    private Koszyk koszyk;
    private List<Zamowienie> zamowienia;

    public Klient(string imie, string nazwisko, string adres, int id){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.adres = adres;
        this.id = id;
        koszyk = new Koszyk();
        zamowienia = new List<Zamowienie>();
    }

    public string Imie{ get => imie; set => imie = value; }
    public string Nazwisko{ get => nazwisko; set => nazwisko = value; }
    public string Adres{ get => adres; set => adres = value; }
    public int Id{ get => id; set => id = value; }
    public Koszyk Koszyk{ get => koszyk; set => koszyk = value; }
    public List<Zamowienie> Zamowienia{ get => zamowienia; set => zamowienia = value; }

    public void zaplac(Zamowienie zamowienie){
        if (zamowienie.Status == "Przyjete"){
            Platnosc platnosc = new Platnosc();
            if (platnosc.potwierdzenie()){
                zamowienie.Status = "Zaplacone";
            }
        }
    }

    public void zamow(Zamowienie zamowienie){
        zamowienie.Status = "Przyjete";
        zamowienia.Add(zamowienie);
    }

    public void dodajDoKoszyka(Produkt produkt){
        koszyk.ListaProduktow.Add(produkt);
        koszyk.Wartosc += produkt.Cena;
    }

    public void usunZKoszyka(Produkt produkt){
        koszyk.ListaProduktow.Remove(produkt);
        koszyk.Wartosc -= produkt.Cena;
    }

    public string statusZamowienia(int numer){
        return zamowienia[numer].Status;
    }

    public void przegladaj(){
        foreach(Produkt produkt in koszyk.ListaProduktow){
            Console.WriteLine(produkt.Nazwa + ": " + produkt.Cena);
        }
    }
}