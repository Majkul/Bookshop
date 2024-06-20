using System.Data.Common;
using System.Dynamic;

class Zamowienie{
    static int numerZamowienia = 10568;
    private int numer;
    public int Numer{
        get{
            return this.numer;
        }
    }
    private int idKlienta;
    public int IdKlienta{
        get{
            return this.idKlienta;
        }
    }
    private string status;
    public string Status{
        get{
            return this.status;
        }
        set{
            this.status = value;
        }
    }
    private string adres;
    public string Adres{
        get{
            return this.adres;
        }
    }

    private DateTime dzienZamowienia;
    public DateTime DzienZamowienia{
        get{
            return this.dzienZamowienia;
        }
    }
    private DateTime ostatniaAktualizacja;
    public DateTime OstatniaAktualizacja{
        get{
            return this.ostatniaAktualizacja;
        }
    }

    private List<Produkt> listaProduktow;
    public List<Produkt> ListaProduktow{
        get{
            return this.listaProduktow;
        }
    }
    private double wartosc;
    public double Wartosc{
        get{
            return this.wartosc;
        }
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Zamowienie other = (Zamowienie)obj;
        return numer == other.Numer;
    }
     private static string charget = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    private string link = "";
        public string Link{
            get{
                return this.link;
            }
            set{
                this.link = value;
            }
        }

    // <summary>
    // Jedyny Konstruktor
    // </summary>
    // <param name="koszyk">Koszyk, z ktorego produkty sa zamawianie</param>
    // <param name="idKlienta">Id Klienta, do ktorego nalezy zamowienie</param>
    // <param name="Adres">Adres, gdize dostarczyc zamowienie</param>
    // <author>Dominik</author>
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

    // <summary>
    // Zmienia status zamowienia
    // </summary>
    // <param name="status">Nowy status zamowienia</param>
    // <returns>Nothing / No returns </returns>
    // <author>Dominik</author>
    public void zmienStatus(string status){
        if(status == "" || string.IsNullOrWhiteSpace(status)){
            throw new WrongStatusException("Niepoprawny status");
        }
        this.status = status;
        this.ostatniaAktualizacja = DateTime.Now;
        //debug
        //Console.WriteLine("[DEBUG] Status zostal zmieniony na: "+status);
    }



    // <summary>
    // Generuje link do cyfrowego produktu
    // </summary>
    // <returns>Link do cyfrowego produktu</returns>
    // <author>Dominik</author>
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