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
    public Zamowienie(Koszyk koszyk,int idKlienta,string adres){
        this.idKlienta = idKlienta;
        this.adres = adres;
        this.listaProduktow = koszyk.ListaProduktow;
        Console.WriteLine(koszyk);
    }
    public void kompletuj(Produkt produkt){
        this.listaProduktow.Append<Produkt>(produkt);
    }
    public void zmienStatus(string status){
        this.status = status;
        Console.WriteLine("Status updated to"+status);
    }
    public string generujLink(int idKlienta,Produkt produkt){   //tutaj chyba można usunąć idKlienta bo ono się nie zmienia w trakcie życia zamówienia 
        // Hiper zaawansowane generowanie linku za
        // pomoca sztucznej inteligencji CHATGPT
        // ORACLE COPILOT
        return "hahha get scammed";
        // ayy Carumba
    }

      

}