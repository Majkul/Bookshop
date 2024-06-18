abstract class Produkt{
    protected string nazwa, id, autor, kategoria;
    protected double cena;

    public Produkt(string nazwa, string id, string autor, string kategoria, double cena){
        this.nazwa = nazwa;
        this.id = id;
        this.autor = autor;
        this.kategoria = kategoria;
        this.cena = cena;
    }

    public string Nazwa{ get => nazwa; set => nazwa = value; }
    public string Id{ get => id; set => id = value; }
    public string Autor{ get => autor; set => autor = value; }
    public string Kategoria{ get => kategoria; set => kategoria = value; }
    public double Cena{ get => cena; set => cena = value; }
}

abstract class Fizyczne : Produkt{
    protected int stan;

    public Fizyczne(string nazwa, string id, string autor, string kategoria, double cena, int stan) : base(nazwa, id, autor, kategoria, cena){
        this.stan = 1;
    }

    public int Stan{ get => stan; set => stan = value; }
}

abstract class Cyfrowe : Produkt{
    public Cyfrowe(string nazwa, string id, string autor, string kategoria, double cena, string link) : base(nazwa, id, autor, kategoria, cena) { }
}

class Twarda_okladka : Fizyczne{
    public Twarda_okladka(string nazwa, string id, string autor, string kategoria, double cena, int stan) : base(nazwa, id, autor, kategoria, cena, stan) { }
}

class Miekka_okladka : Fizyczne{
    public Miekka_okladka(string nazwa, string id, string autor, string kategoria, double cena, int stan) : base(nazwa, id, autor, kategoria, cena, stan) { }
}

class Audiobook : Cyfrowe{
    public Audiobook(string nazwa, string id, string autor, string kategoria, double cena, string link) : base(nazwa, id, autor, kategoria, cena, link) { }
}

class E_book : Cyfrowe{
    public E_book(string nazwa, string id, string autor, string kategoria, double cena, string link) : base(nazwa, id, autor, kategoria, cena, link) { }
}
