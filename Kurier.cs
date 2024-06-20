class Kurier{
    private List<Zamowienie> zamowienia;
    private string nazwa;
    public List<Zamowienie> Zamowienia{
        get{
            return this.zamowienia;
        }
        set{
            this.zamowienia = value;
        }
    }

    public Kurier(string nazwa){
        this.zamowienia = new List<Zamowienie>();
    }

    public void dostarcz(Zamowienie zamowienie){
        zamowienie.zmienStatus("Dostarczone");
        zamowienia.Remove(zamowienie);
    }
}
