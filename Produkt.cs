abstract class Produkt{
    protected string nazwa, autor, kategoria;
    protected double cena;
    protected int id;

    public Produkt(string nazwa, int id, string autor, string kategoria, double cena){
        this.nazwa = nazwa;
        this.id = id;
        this.autor = autor;
        this.kategoria = kategoria;
        this.cena = cena;
    }

    public string Nazwa{ get => nazwa; set => nazwa = value; }
    public int Id{ get => id; set => id = value; }
    public string Autor{ get => autor; set => autor = value; }
    public string Kategoria{ get => kategoria; set => kategoria = value; }
    public double Cena{ get => cena; set => cena = value; }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Produkt other = (Produkt)obj;
        return Id == other.Id;
    }
}

abstract class Fizyczne : Produkt{
    protected int stan;

    public Fizyczne(string nazwa, int id, string autor, string kategoria, double cena, int stan) : base(nazwa, id, autor, kategoria, cena){
        this.stan = 1;
    }

    public int Stan{ get => stan; set => stan = value; }
}

abstract class Cyfrowe : Produkt{
    public Cyfrowe(string nazwa, int id, string autor, string kategoria, double cena, string link) : base(nazwa, id, autor, kategoria, cena) { }
}

class Twarda_okladka : Fizyczne{
    public Twarda_okladka(string nazwa, int id, string autor, string kategoria, double cena, int stan) : base(nazwa, id, autor, kategoria, cena, stan) { }
}

class Miekka_okladka : Fizyczne{
    public Miekka_okladka(string nazwa, int id, string autor, string kategoria, double cena, int stan) : base(nazwa, id, autor, kategoria, cena, stan) { }
}

class Audiobook : Cyfrowe{
    public Audiobook(string nazwa, int id, string autor, string kategoria, double cena, string link) : base(nazwa, id, autor, kategoria, cena, link) { }
}

class E_book : Cyfrowe{
    public E_book(string nazwa, int id, string autor, string kategoria, double cena, string link) : base(nazwa, id, autor, kategoria, cena, link) { }
}
