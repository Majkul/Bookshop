class Magazyn{
    private int id;
    private List<Produkt> produkty;
    private List<Zamowienie> zamowieniaDoRealizacji;
    private List<Zamowienie> zamowieniaZrealizowane;
    public Magazyn(int id){
        this.id = id;
        produkty = new List<int>();
        zamowieniaDoRealizacji = new List<int>();
        zamowieniaZrealizowane = new List<int>();
    }

}