class Kurier{
    private List<Zamowienie> zamowienia;
    private string nazwa;
    public string Nazwa{
        get{
            return nazwa;
        }
    }
    public List<Zamowienie> Zamowienia{
        get{
            return this.zamowienia;
        }
        set{
            this.zamowienia = value;
        }
    }
    ///<summary>
    ///Konstruuje nowego kuriera z wlasna nazwa 
    ///<summary>
    ///<param name="nazwa"/></param>
    public Kurier(string nazwa){
        this.zamowienia = new List<Zamowienie>();
        this.nazwa = nazwa;
    }
    ///<summary>
    ///Konstruuje nowego kuriera z nawza "Steve Jobs"
    ///</summary>
    public Kurier(){
        this.zamowienia = new List<Zamowienie>();
        this.nazwa = "Steve Jobs";
    }

    ///<summary>
    ///Oznacza swoje zamowienie jako dostarczone
    ///</summary>
    public void dostarcz(Zamowienie zamowienie){
        zamowienie.zmienStatus("Dostarczone");
        zamowienia.Remove(zamowienie);
    }
}
