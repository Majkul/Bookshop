using Xunit;
public class TestMagazyn
{
    [Fact]
    public void TestSzukaniaZamowieniaNiepowodzenie(){
        Magazyn magazyn = new Magazyn(1);
        Zamowienie zamowienie = new Zamowienie(1, 1, 1.11, DateTime.Parse("20.06.2024 11:11:11"), DateTime.Parse("20.06.2024 11:11:11"), "Zrealizowane", "none");
        magazyn.ZamowieniaDoRealizacji.Add(zamowienie);
        Assert.Throws<ZamowienieDoesNotExistException>(() => magazyn.znajdzZamowienie(0));
    }
    [Fact]
    public void TestSzukaniaZamowienia(){
        Magazyn magazyn = new Magazyn(1);
        Zamowienie zamowienie = new Zamowienie(1, 1, 1.11, DateTime.Parse("20.06.2024 11:11:11"), DateTime.Parse("20.06.2024 11:11:11"), "Zrealizowane", "none");
        magazyn.ZamowieniaDoRealizacji.Add(zamowienie);
        var ex = Record.Exception(() => magazyn.znajdzZamowienie(1));
        Assert.Null(ex);
    }
    [Fact]
    public void TestSzukaniaProduktuNiepowodzenie(){
        Magazyn magazyn = new Magazyn(1);
        Produkt produkt = new Twarda_okladka("prod", 1, "autor", "kategoria", 1.11, 1);
        magazyn.Produkty.Add(produkt);
        Assert.Throws<ProduktDoesNotExistException>(() => magazyn.znajdzProdukt(0));
    }
    [Fact]
    public void TestSzukaniaProduktu(){
        Magazyn magazyn = new Magazyn(1);
        Produkt produkt = new Twarda_okladka("prod", 1, "autor", "kategoria", 1.11, 1);
        magazyn.Produkty.Add(produkt);
        var ex = Record.Exception(() => magazyn.znajdzProdukt(1));
        Assert.Null(ex);
    }
    
}