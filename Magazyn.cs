class Magazyn{
    private int id;
    private List<Produkt> produkty;
    public List<Produkt> get_set_produkty
    {
        get { return produkty; }
        set { produkty = value; }
    }
    private List<Zamowienie> zamowieniaDoRealizacji;
    public List<Zamowienie> get_set_zamowieniaDoRealizacji
    {
        get { return zamowieniaDoRealizacji; }
    }
    private List<Zamowienie> zamowieniaZrealizowane;
    public List<Zamowienie> get_set_zamowieniaZrealizowane
    {
        get { return zamowieniaZrealizowane; }
    }
    public Magazyn(int id){
        this.id = id;
        produkty = new List<Produkt>();
        zamowieniaDoRealizacji = new List<Zamowienie>();
        zamowieniaZrealizowane = new List<Zamowienie>();
    }
    public Zamowienie znajdzZamowienie(int numer){
        foreach(Zamowienie zamowienie in zamowieniaDoRealizacji){
            if(zamowienie.Numer == numer){
                return zamowienie;
            }
        }
        return null;
    }
    public Produkt znajdzProdukt(int id){
        foreach(Produkt produkt in produkty){
            if(produkt.get_id == id){
                return produkt;
            }
        }
        return null;
    }
}