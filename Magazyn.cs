class Magazyn{
    private int id;
    public int Id
    {
        get { return id; }
    }
    private List<Produkt> produkty;
    public List<Produkt> Produkty
    {
        get { return produkty; }
        set { produkty = value; }
    }
    private List<Zamowienie> zamowieniaDoRealizacji;
    public List<Zamowienie> ZamowieniaDoRealizacji
    {
        get { return zamowieniaDoRealizacji; }
    }
    private List<Zamowienie> zamowieniaZrealizowane;
    public List<Zamowienie> ZamowieniaZrealizowane
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
        Zamowienie zamowienie = zamowieniaDoRealizacji.Find(x => x.Numer == numer);
        if(zamowienie == null){
            throw new ZamowienieDoesNotExistException("Nie ma takiego zamowienia");
        }
        return zamowienie;
    }
    public Produkt znajdzProdukt(int id){
        Produkt produkt = produkty.Find(x => x.Id == id);
        if(produkt == null){
            throw new ProduktDoesNotExistException("Nie ma takiego produktu w magazynie");
        }
        return produkt;
    }
}
