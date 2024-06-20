class Kurier{
    private List<Zamowienie> zamowienia;
    public List<Zamowienie> Zamowienia{
        get{
            return this.zamowienia;
        }
        set{
            this.zamowienia = value;
        }
    }

    public Kurier(){
        this.zamowienia = new List<Zamowienie>();
    }

    public void dostarcz(Zamowienie zamowienie){
        zamowienie.zmienStatus("Dostarczone");
        zamowienia.Remove(zamowienie);
    }
}
