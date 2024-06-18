using System;
class Program
{
    static void Main()
    {
        Magazyn magazyn = new Magazyn(1);
        Pracownik pracownik = new Pracownik("Jan", "Kowalski", 1, magazyn);
        Console.WriteLine("Witaj! Wybierz jako kto chcesz się zalogować:\n1. Klient\n2. Pracownik");
        string logowanie = Console.ReadLine();
        switch(logowanie){
            case "1":
                Console.WriteLine("Wybierz opcję:\n1. Przeglądaj produkty\n2. Wyświetl koszyk\n3. Złóż zamówienie\n4. Opłać zamówienie\n5.Sprawdź status zamówienia\n6. Wyjdź");
                break;
            case "2":
                Console.WriteLine("Wybierz opcję:\n1. Zrealizuj zamówienie\n2. Zamów kuriera\n3. Dodaj produkt\n4. Ustaw stan produktu\n5. Usuń produkt\n6. Wyjdź");
                string wybor = Console.ReadLine();
                switch (wybor){
                    case "1":
                        Console.WriteLine("Podaj numer zamówienia do realizacji:");
                        try{
                            pracownik.realizaZamowienie(int.Parse(Console.ReadLine()));
                        }
                        catch(Exception e){
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Zamów kuriera");
                        break;
                    case "3":
                        Console.WriteLine("Wybierz jaki produkt chcesz dodać:\n1. Książkę z twardą okładką\n2. Książkę z miękką okładką\n3. Audiobook\n4. E_Book\n");
                        int type = int.Parse(Console.ReadLine())-1;
                        Console.WriteLine("Podaj nazwę produktu:");
                        string nazwa = Console.ReadLine();
                        Console.WriteLine("Podaj id produktu:");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Podaj cenę produktu:");
                        double cena = double.Parse(Console.ReadLine());
                        try{
                            pracownik.dodajProdukt(nazwa, id, cena);
                        }
                        catch(Exception e){
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Podaj ID produktu, którego stan chcesz zmienić:");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Podaj nowy stan produktu:");
                        int stan = int.Parse(Console.ReadLine());
                        try{
                            pracownik.ustawStan(id, stan);
                        }
                        catch(Exception e){
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "5":
                        Console.WriteLine("Podaj ID produktu, który chcesz usunąć:");
                        int id = int.Parse(Console.ReadLine());
                        try{
                            pracownik.usunProdukt(id);
                        }
                        catch(Exception e){
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "6":
                        Console.WriteLine("Wyjdź");
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór");
                        break;
                }
                break;
            default:
                Console.WriteLine("Niepoprawny wybór");
                break;
        }
    }
}