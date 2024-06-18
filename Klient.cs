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
        if (zamowienie.Status == "Oczekujace na zaplate"){
            Platnosc platnosc = new Platnosc();
            if (platnosc.potwierdzenie()){
                zamowienie.Status = "Zaplacone";
            } else {
                throw new Exception("Platnosc nieudana");
            }
        } else {
            throw new Exception("Zamowienie nie jest gotowe lub zostalo juz zaplacone");
        }
    }

    public void zamow(Zamowienie zamowienie){
        zamowienie.Status = "Oczekujace na zaplate";
        zamowienia.Add(zamowienie);
    }

    public void dodajDoKoszyka(Produkt produkt){
        if (produkt is Fizyczne && ((Fizyczne)produkt).Stan == 0){
            throw new Exception("Produkt niedostepny");
        }
        koszyk.ListaProduktow.Add(produkt);
        koszyk.Wartosc += produkt.Cena;
    }

    // public void usunZKoszyka(Produkt produkt){
    //     koszyk.ListaProduktow.Remove(produkt);
    //     koszyk.Wartosc -= produkt.Cena;
    // }

    public void usunZKoszyka(int index){
        if (index < 0 || index >= koszyk.ListaProduktow.Count){
            throw new Exception("Nie ma takiego produktu w koszyku");
        }
        koszyk.Wartosc -= koszyk.ListaProduktow[index].Cena;
        koszyk.ListaProduktow.RemoveAt(index);
    }

    public string statusZamowienia(int numer){
        if (numer < 0 || numer >= zamowienia.Count){
            throw new Exception("Nie ma takiego zamowienia");
        }
        return zamowienia[numer].Status;
    }

    public void przegladaj(){
        if (koszyk.ListaProduktow.Count == 0){
            Console.WriteLine("Koszyk jest pusty");
            return;
        }
        foreach(Produkt produkt in koszyk.ListaProduktow){
            Console.WriteLine(produkt.Nazwa + ": " + produkt.Cena);
        }
    }
}