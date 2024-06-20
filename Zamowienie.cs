using System.Data.Common;
using System.Dynamic;


class Zamowienie{
    /// <value> Numer uzywany do stworzenia nowego id zamówienia </value>
    static int numerZamowienia = 10568;
    private int numer;
    /// <value> <c>Numer</c> zamówienia.</value>
    public int Numer{
        get{
            return this.numer;
        }
    }
    private int idKlienta;
    /// <value> <c>Id Klienta</c> zamówienia. </value>
    public int IdKlienta{
        get{
            return this.idKlienta;
        }
    }
    private string status;
    /// <value> <c>Status</c> zamówienia. </value>
    public string Status{
        get{
            return this.status;
        }
        set{
            this.status = value;
        }
    }
    private string adres;
    /// <value> <c>Adres</c>, do którego zamówienie będzie dostarczane.</value>
    public string Adres{
        get{
            return this.adres;
        }
    }

    private DateTime dzienZamowienia;
    /// <value> Dzień, w którym było składane zamówienie. </value>
    public DateTime DzienZamowienia{
        get{
            return this.dzienZamowienia;
        }
    }
    private DateTime ostatniaAktualizacja;
    /// <value> Dzień, w którym zamówienie było ostanio aktualizowane. </value>
    public DateTime OstatniaAktualizacja{
        get{
            return this.ostatniaAktualizacja;
        }
    }

    private List<Produkt> listaProduktow;
    /// <value> <c>Lista Prodktów</c>, zamówienia. </value>
    public List<Produkt> ListaProduktow{
        get{
            return this.listaProduktow;
        }
    }
    private double wartosc;
    /// <value> <c>Wartość</c>, całego zamówienia. </value>
    public double Wartosc{
        get{
            return this.wartosc;
        }
    }
    ///<summary>
    ///Override porównania 2 zamowień,
    ///porównoje numer zamowień.
    ///</summary>
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Zamowienie other = (Zamowienie)obj;
        return numer == other.Numer;
    }

    private string link = "";
    /// <value> <c>Link</c> do produktów cyfrowych </value>
    public string Link{
        get{
            return this.link;
        }
        set{
            this.link = value;
        }
    }

    //Alfabet oraz cyfry, nic wiecej
    private static string charget = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    /// <summary>
    /// Jeden z Konstruktorów
    /// </summary>
    /// <param name="koszyk"> Koszyk, z którego produkty sa zamawianie.</param>
    /// <param name="idKlienta"> Id Klienta, do którego należy zamówienie.</param>
    /// <param name="Adres"> Adres, gdzie dostarczyć zamówienie.</param>
    /// <exception cref="KoszykIsEmptyException">
    /// Wyrzucany jest gdy koszyk jest pusty.
    /// </exception>
    /// <exception cref="WrongAddressException">
    /// Wyrzucany jest gdy adres do dostawy nie istnieje czyt:
    /// adres jest "", albo zlozony jest tylko z "white spaces",
    /// to NIE wykrywa czy miejsce adresu nie istnieje, np Hogwarts.
    /// </exception>
    public Zamowienie(Koszyk koszyk,int idKlienta,string adres){
        
        if(koszyk.ListaProduktow.Count <= 0){
            throw new KoszykIsEmptyException("Koszyk jest pusty");
        }
        if(adres == "" || string.IsNullOrWhiteSpace(adres)){
            throw new WrongAddressException("Adres jest niepoprawy lub nie istnieje");
        }
        this.idKlienta = idKlienta;
        this.adres = adres;
        this.listaProduktow = koszyk.ListaProduktow;
        this.numer = numerZamowienia++;
        this.wartosc = koszyk.Wartosc;
        this.dzienZamowienia = this.ostatniaAktualizacja = DateTime.Now;
    }
    /// <summary>
    /// Konstruktor używany podczas wczytywania plików.
    /// </summary>
    /// <param name="numer">
    /// Numer zamówienia.
    /// </param>
    /// <param name="idKlienta">
    /// ID klienta, który zkładał te zamówienie.
    /// </param>
    /// <param name="wartosc">
    /// Wartość całego zamówienia.
    /// </param>
    /// <param name="dzienZamowienia">
    /// Czas, w którym było złozone zamówienie.
    /// </param>
    /// <param name="ostatniaAktualizacja">
    /// Czas, kiedy ostatnio zamówienie było aktualizowane.
    /// </param>
    /// <param name="status">
    /// Status, w jakim zamówienie sie aktualnie znajduje.
    /// </param>
    /// <param name="link">
    /// Link do produktow cyfrowych zamówienia.
    /// </param>
        public Zamowienie(int numer, int idKlienta, double wartosc, DateTime dzienZamowienia, DateTime ostatniaAktualizacja, string status, string link){
        this.numer = numer;
        this.idKlienta = idKlienta;
        this.wartosc = wartosc;
        this.dzienZamowienia = dzienZamowienia;
        this.ostatniaAktualizacja = ostatniaAktualizacja;
        this.status = status;
        this.link = link == "none"?"":link;
        this.listaProduktow = new List<Produkt>();
        numerZamowienia++;
    }

    /// <summary>
    /// Zmienia status zamówienia
    /// </summary>
    /// <param name="status">Nowy status zamówienia.</param>
    /// <exception cref="WrongStatusException">
    /// Wyrzucany jest gdy status jest niepoprawy czyt:
    /// status jest "" albo składa sie z "white spaces"
    /// </exception>
    public void zmienStatus(string status){
        if(status == "" || string.IsNullOrWhiteSpace(status)){
            throw new WrongStatusException("Niepoprawny status");
        }
        this.status = status;
        this.ostatniaAktualizacja = DateTime.Now;
        //debug
        //Console.WriteLine("[DEBUG] Status zostal zmieniony na: "+status);
    }



    /// <summary>
    /// Generuje link do cyfrowego produktu.
    /// </summary>
    /// <returns>Link do cyfrowego produktu.</returns>
    public string generujLink(){   
        
        if(link == ""){
            string tmp = "https://www.CoolBookShop.com/pobierz/";
            char[] chars = new char[16];
            Random random = new Random();
            
            for(int i = 0;i < chars.Count(); ++i ){
                chars[i] = charget[random.Next(charget.Count())];
            }

            tmp+= new string(chars);
            link += tmp;

            tmp = null;
            chars = null;
            random = null;
        }

        return link;
    }
}