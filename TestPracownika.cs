using Xunit;
public class TestPracownika
{
    [Fact]
    public void TestDodawanieProduktuBezNazwy(){
        Pracownik pracownik = new Pracownik("Jan", "Kowalski", 1, new Magazyn(1));
        Assert.Throws<WrongProductNameException>(() => pracownik.dodajProdukt("", 1, 1, "autor", "kategoria", 0, 1));
    }
    [Fact]
    public void TestDodawanieProduktuCenaUj(){
        Pracownik pracownik = new Pracownik("Jan", "Kowalski", 1, new Magazyn(1));
        Assert.Throws<WrongPriceException>(() => pracownik.dodajProdukt("prod", 1, -1, "autor", "kategoria", 0, 1));
    }
    [Fact]
    public void TestDodawanieProduktuZlyTyp(){
        Pracownik pracownik = new Pracownik("Jan", "Kowalski", 1, new Magazyn(1));
        Assert.Throws<WrongTypeException>(() => pracownik.dodajProdukt("prod", 1, 1, "autor", "kategoria", 8, 8));
    }
    [Fact]
    public void TestUstawStanProduktNieIstnieje(){
        Magazyn magazyn = new Magazyn(1);
        Pracownik pracownik = new Pracownik("Jan", "Kowalski", 1, magazyn);
        pracownik.dodajProdukt("prod", 1, 1, "autor", "kategoria", 0, 1);
        Assert.Throws<ProduktDoesNotExistException>(() => pracownik.ustawStan(2,1));
    }
    [Fact]
    public void TestUstawStanProduktNieJestFizyczny(){
        Magazyn magazyn = new Magazyn(1);
        Pracownik pracownik = new Pracownik("Jan", "Kowalski", 1, magazyn);
        pracownik.dodajProdukt("prod", 1, 1, "autor", "kategoria", 2, 1);
        Assert.Throws<ProduktIsNotPhysicalException>(() => pracownik.ustawStan(1,10));
    }
    [Fact]
    public void TestUstawStanProdukt(){
        Magazyn magazyn = new Magazyn(1);
        Pracownik pracownik = new Pracownik("Jan", "Kowalski", 1, magazyn);
        pracownik.dodajProdukt("prod", 1, 1, "autor", "kategoria", 1, 1);
        var ex = Record.Exception(() => pracownik.ustawStan(1,10));
        Assert.Null(ex);
    }
    [Fact]
    public void TestUsunProdukt(){
        Magazyn magazyn = new Magazyn(1);
        Pracownik pracownik = new Pracownik("Jan", "Kowalski", 1, magazyn);
        pracownik.dodajProdukt("prod", 1, 1, "autor", "kategoria", 1, 1);
        Assert.Throws<ProduktDoesNotExistException>(() => pracownik.usunProdukt(2));
    }
    
}