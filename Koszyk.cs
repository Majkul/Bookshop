class Koszyk{
    private List<Produkt> listaProduktow;
    private double wartosc;

    public Koszyk(){
        listaProduktow = new List<Produkt>();
        wartosc = 0;
    }
    public List<Produkt> ListaProduktow{ get => listaProduktow; set => listaProduktow = value; }
    public double Wartosc{ get => wartosc; set => wartosc = value; }
}
