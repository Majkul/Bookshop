class Produkt{
    protected string nazwa, autor, kategoria;
    protected double cena;
    protected int id;
    public int get_id{
        get { return id; }
    }
    public Produkt(string nazwa, int id, double cena, string autor, string kategoria){
        this.nazwa = nazwa;
        this.id = id;
        this.cena = cena;
    }
}
abstract class Fizyczne : Produkt{
    protected int stan;
    public int get_set_stan{
        get { return stan; }
        set { stan = value; }
    }

    public Fizyczne(string nazwa, int id, double cena, string autor, string kategoria) : base(nazwa, id, cena, autor, kategoria)
    {
    }
}
