using Xunit;
public class TestKoszyka_Klienta
{
    [Fact]
    public void TestDodajDoKoszyka()
    {
        // Arrange
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Produkt produkt = new Twarda_okladka("Ksiazka", 20, "Mickiewicz", "Epopeja", 24.99, 1);
        // Act
        klient.dodajDoKoszyka(produkt);
        // Assert
        Assert.Equal(1, klient.Koszyk.ListaProduktow.Count);
    }
    [Fact]
    public void TestDodajDoKoszykaKilkaTychSamych()
    {
        // Arrange
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Produkt produkt1 = new Twarda_okladka("Ksiazka", 20, "Mickiewicz", "Epopeja", 24.99, 1);
        Produkt produkt2 = new Twarda_okladka("Ksiazka", 20, "Mickiewicz", "Epopeja", 24.99, 1);
        Produkt produkt3 = new Twarda_okladka("Ksiazka2", 21, "Mickiewicz2", "Epopeja2", 24.99, 1);
        // Act
        klient.dodajDoKoszyka(produkt1);
        klient.dodajDoKoszyka(produkt2);
        klient.dodajDoKoszyka(produkt3);
        // Assert
        Assert.Equal(3, klient.Koszyk.ListaProduktow.Count);
    }
    [Fact]
    public void TestDodajDoKoszykaNiepowodzenie()
    {
        // Arrange
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Produkt produkt = new Twarda_okladka("Ksiazka", 20, "Mickiewicz", "Epopeja", 24.99, 0);
        // Assert
        Assert.Throws<ProduktIsNotAvailableException>(() => klient.dodajDoKoszyka(produkt));
    }
    [Fact]
    public void TestUsunZKoszyka1()
    {
        // Arrange
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        // Assert
        Assert.Throws<KoszykIsEmptyException>(() => klient.usunZKoszyka(1));
    }

    [Fact]
    public void TestUsunZKoszyka2()
    {
        // Arrange
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Produkt produkt = new Twarda_okladka("Ksiazka", 20, "Mickiewicz", "Epopeja", 24.99, 1);
        klient.dodajDoKoszyka(produkt);
        // Assert
        Assert.Throws<ProduktDoesNotExistException>(() => klient.usunZKoszyka(1));
    }
    [Fact]
    public void TestUsunZKoszykaPowodzenie()
    {
        // Arrange
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Produkt produkt = new Twarda_okladka("Ksiazka", 20, "Mickiewicz", "Epopeja", 24.99, 1);
        klient.dodajDoKoszyka(produkt);
        // Assert
        var ex = Record.Exception(() => klient.usunZKoszyka(20));

        Assert.Null(ex);
    }
    [Fact]
    public void TestKoszykPrzegladaj(){
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Assert.Throws<KoszykIsEmptyException>(() => klient.przegladaj());
    }
    [Fact]
    public void TestStatusZamowienia(){
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Assert.Throws<ZamowienieDoesNotExistException>(() => klient.statusZamowienia(-1));
    }
    [Fact]
    public void TestZamowWhenKoszykIsEmpyt(){
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Assert.Throws<KoszykIsEmptyException>(() => klient.zamow());
    }
    [Fact]
    public void TestZamow(){
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Produkt produkt = new Twarda_okladka("Ksiazka", 20, "Mickiewicz", "Epopeja", 24.99, 1);
        klient.dodajDoKoszyka(produkt);
        var ex = Record.Exception(() => klient.zamow());

        Assert.Null(ex);

    }
}