using System.Data.Common;
using System.Dynamic;

class Zamowienie{
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

    private DateOnly dzienZamowienia;
    public DateOnly DzienZamowienia{
        get{
            return this.dzienRealizacji;
        }
    }
    private DateOnly dzienRealizacji;
    public DateOnly DzienRealizacji{
        get{
            return this.dzienRealizacji;
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
    private string link = "";
    public string Link{
        get{
            return this.link;
        }
    }

    private static string charget = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";



    <summary>
    Jedyny Konstruktor
    </summary>
    <param name="koszyk">Koszyk, z ktorego produkty sa zamawianie</param>
    <param name="idKlienta">Id Klienta, do ktorego nalezy zamowienie</param>
    <param name="Adres">Adres, gdize dostarczyc zamowienie</param>
    <author>Dominik</author>
    public Zamowienie(Koszyk koszyk,int idKlienta,string adres){
        
        if(koszyk.ListaProduktow.Count <= 0){
            throw new Exception("Koszyk jest pusty");
        }
        if(adres == "" || string.IsNullOrWhiteSpace(status)){
            throw new Exception("Adres jest niepoprawy / nie istnieje");
        }


        this.idKlienta = idKlienta;
        this.adres = adres;
        this.listaProduktow = koszyk.ListaProduktow;
    }

    <summary>
    Kompletuje
    </summary>
    <param name="produkt">produkt</param>
    <returns> Nic / bez returna </returns>
    <author>Dominik</author>
    //TODO zmienic to
    //Czy to ma sens?
    public void Kompletuj(Produkt produkt){
        _ = this.listaProduktow.Append<Produkt>(produkt);
        // _ = [...] discarduje returny
        // pewnie mozna bez tego
    }


    <summary>
    Zmienia status zamowienia
    </summary>
    <param name="status">Nowy status zamowienia</param>
    <returns>Nothing / No returns </returns>
    <author>Dominik</author>
    public void zmienStatus(string status){
        if(status = "" || string.IsNullOrWhiteSpace(status)){
            throw new Exception("Nowy status jest pusty");
        }
        this.status = status;
        
        //debug
        Console.WriteLine("[DEBUG] Status zostal zmieniony na: "+status);
    }



    <summary>
    Generuje link do cyfrowego produktu
    </summary>
    <returns>Link do cyfrowego produktu</returns>
    <author>Dominik</author>
    public string generujLink(){   
        
        if(link == ""){
            string tmp = "https://www.CoolBookShop.com/pobierz/";
            char[] chars = new char[16];
            Random random = new Random();
            
            for(int i = 0,i < chars.Lenght, ++i ){
                chars[i] = charget[random.Next(charget.Lenght)];
            }

            tmp+= new string(chars);
            link += tmp;

            tmp = null;
            chars = null;
            random = null;
        }

        return link;

        // Hiper zaawansowane generowanie linku za
        // pomoca sztucznej inteligencji CHATGPT
        // ORACLE COPILOT
        //return "hahha get scammed";
        // ayy Carumba
    }

}