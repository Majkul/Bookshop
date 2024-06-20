class Kurier{
    private List<Zamowienie> zamowienia;
    private string nazwa;
    ///<value> <c>Nazwa</c> kuriera.</value>
    public string Nazwa{
        get{
            return nazwa;
        }
    }
    /// <value> <c>Zamowienia</c>, jakie kurier dostarcza.</value>
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
    ///Konstruuje nowego kuriera z nazwie "Steve Jobs"
    ///</summary>
    public Kurier(){
        this.zamowienia = new List<Zamowienie>();
        this.nazwa = "Steve Jobs";
    }

    ///<summary>
    ///Oznacza zamowienie jako dostarczone,
    ///oraz usuwa z listy zamowien kuriera. 
    ///</summary>
    ///<param="zamowienie">
    ///Zamowienie, ktore zostalo dostarczone.
    ///</param>
    public void dostarcz(Zamowienie zamowienie){
        zamowienie.zmienStatus("Dostarczone");
        zamowienia.Remove(zamowienie);
    }
}
