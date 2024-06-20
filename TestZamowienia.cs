using Xunit;
public class TestZamowienia
{
    [Fact]
    public void TestKonstruktorKoszykNiepowodzenie(){
        Koszyk koszyk = new Koszyk();
        Assert.Throws<KoszykIsEmptyException>(() => new Zamowienie(koszyk, 1, "adres"));
    }
    [Fact]
    public void TestKonstruktorKoszyk(){
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Produkt produkt = new Twarda_okladka("Ksiazka", 20, "Mickiewicz", "Epopeja", 24.99, 1);
        klient.dodajDoKoszyka(produkt);
        var ex = Record.Exception(() => new Zamowienie(klient.Koszyk, 1, "adres"));
        Assert.Null(ex);
    }
    [Fact]
    public void TestKonstruktorAdresNiepowodzenie(){
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Produkt produkt = new Twarda_okladka("Ksiazka", 20, "Mickiewicz", "Epopeja", 24.99, 1);
        klient.dodajDoKoszyka(produkt);
        Assert.Throws<WrongAddressException>(() => new Zamowienie(klient.Koszyk, 1, ""));
    }
    [Fact]
    public void TestKonstruktorAdres(){
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Produkt produkt = new Twarda_okladka("Ksiazka", 20, "Mickiewicz", "Epopeja", 24.99, 1);
        klient.dodajDoKoszyka(produkt);
        var ex = Record.Exception(() => new Zamowienie(klient.Koszyk, 1, "adres"));
        Assert.Null(ex);
    }
    [Fact]
    public void TestZmienStatusNiepowodzenie(){
        Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Produkt produkt = new Twarda_okladka("Ksiazka", 20, "Mickiewicz", "Epopeja", 24.99, 1);
        klient.dodajDoKoszyka(produkt);
        Zamowienie zamowienie = new Zamowienie(klient.Koszyk, 1, "adres");
        Assert.Throws<WrongStatusException>(() => zamowienie.zmienStatus(""));
    }
    [Fact]
    public void TestZmienStatus(){
         Klient klient = new Klient("Jan", "Kowalski", "Białystok",1);
        Produkt produkt = new Twarda_okladka("Ksiazka", 20, "Mickiewicz", "Epopeja", 24.99, 1);
        klient.dodajDoKoszyka(produkt);
        Zamowienie zamowienie = new Zamowienie(klient.Koszyk, 1, "adres");
        var ex = Record.Exception(() => zamowienie.zmienStatus("Zrealizowane"));
        Assert.Null(ex);
    }
    
}