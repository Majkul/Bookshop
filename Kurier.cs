class Kurier{
    private List<Zamowienie> zamowienia;
    public List<Zamowienie> Zamowienia{
        get{
            return this.zamowienia;
        }
    }



    <summary>
    Konstruktor
    </summary>
    <param name="zamowienie">Zamowienia, ktory kurier odbiera oraz dostarcza</param>
    <author>Dominik</author>
    public Kurier(List<Zamowienie> zamowienia){
        this.zamowienia = zamowienia;
    }


    <summary>
    Sygnalizuje, ze kurier odbiera produkty z magazynu
    Zmienia status zamowienia
    </summary>
    <author>Dominik</author>
    public void odbior(){
        // Zrealizowane odbiera
        if(zamowienia.Count <= 0){
           throw new Exception("Nie istnieja zamowienia do odebrania");
        }
        foreach(Zamowienie zamowienie in zamowienia){
            if(zamowienie.ListaProduktow.Count <= 0){
                throw new Exception("Zamowienie jest puste");
            }
            if(zamowienie.Status == "Zaplacone"){
                zamowienie.ZmienStatus("W Drodze");
            }
        }

    }

    public void dostarcz(Zamowienie zamowienie){
        // clearuje swoje zamowienia i oznacza jako dostarczone
    }
}