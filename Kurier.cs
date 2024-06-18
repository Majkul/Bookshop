class Kurier{
    private List<Zamowienie> zamowienia;
    public List<Zamowienie> Zamowienia{
        get{
            return this.zamowienia;
        }
    }

    public Kurier(List<Zamowienie> zamowienia){
        this.zamowienia = zamowienia;
    }

    public void odbior(){
        // Zrealizowane odbiera
    }

    public void dostarcz(Zamowienie zamowienie){
        // clearuje swoje zamowienia i oznacza jako dostarczone
    }
}