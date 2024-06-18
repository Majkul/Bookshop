using System;
class Program
{
    static void Main()
    {
        Magazyn magazyn = new Magazyn(1);
        Pracownik pracownik = new Pracownik("Jan", "Kowalski", 1, magazyn);
        //----------------------
        string line;

        System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\micha\OneDrive\Desktop\codin\PO\Bookshop_proj\produkty.txt");
        while((line = file.ReadLine()) != null)
        {
            string[] words = line.Split(';');
            pracownik.dodajProdukt(words[0],int.Parse(words[1]),double.Parse(words[2]),words[3],words[4],int.Parse(words[5]),int.Parse(words[6]));
        }

        file.Close();
        //----------------------
        Console.WriteLine("Witaj! Wybierz jako kto chcesz się zalogować:\n1. Klient\n2. Pracownik");
        string logowanie = Console.ReadLine();
        string wybor = "";
        switch(logowanie){
            case "1":
                Klient klient = new Klient("Adam", "Małysz", "Wisła", 1);
                while (wybor != "6"){
                    Console.WriteLine("Wybierz opcję:\n1. Przeglądaj produkty\n2. Wyświetl koszyk\n3. Złóż zamówienie\n4. Opłać zamówienie\n5.Sprawdź status zamówienia\n6. Wyjdź");
                    wybor = Console.ReadLine();
                    switch(wybor){
                        case "1":
                        int i = 1;
                            Console.WriteLine("Produkty:");
                            foreach(Produkt produkt in magazyn.Produkty){
                                Console.WriteLine(i+". "+produkt.Nazwa + " " + produkt.Cena);
                                i++;
                            }
                            Console.WriteLine("Podaj numer produktu, który chcesz dodać do koszyka:");
                            int numer = int.Parse(Console.ReadLine());
                            try{
                                klient.dodajDoKoszyka(magazyn.Produkty[numer-1]);
                            }
                            catch(Exception e){
                                Console.WriteLine(e.Message);
                            }
                        break;
                    }
                }
                break;
            case "2":
            
            Kurier kurier;
                int id;
                Console.WriteLine("Wybierz opcję:\n1. Zrealizuj zamówienie\n2. Zamów kuriera\n3. Dodaj produkt\n4. Ustaw stan produktu\n5. Usuń produkt\n6. Wyjdź");
                wybor = Console.ReadLine();
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
                        kurier = pracownik.zamowKuriera();
                        break;
                    case "3":
                        int stan_p;
                        Console.WriteLine("Wybierz jaki produkt chcesz dodać:\n1. Książkę z twardą okładką\n2. Książkę z miękką okładką\n3. Audiobook\n4. E_Book\n");
                        int type = int.Parse(Console.ReadLine())-1;
                        Console.WriteLine("Podaj nazwę produktu:");
                        string nazwa = Console.ReadLine();
                        Console.WriteLine("Podaj id produktu:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Podaj cenę produktu:");
                        double cena = double.Parse(Console.ReadLine());
                        Console.WriteLine("Podaj autora produktu:");
                        string autor = Console.ReadLine();
                        Console.WriteLine("Podaj kategorię do której zalicza się produkt:");
                        string kategoria = Console.ReadLine();
                        if (type < 2){
                            Console.WriteLine("Podaj stan produktu:");
                            stan_p = int.Parse(Console.ReadLine());
                        }
                        else{
                            stan_p = 1;
                        }
                        try{
                            pracownik.dodajProdukt(nazwa, id, cena, autor, kategoria, type, stan_p);
                        }
                        catch(Exception e){
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Podaj ID produktu, którego stan chcesz zmienić:");
                        id = int.Parse(Console.ReadLine());
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
                        id = int.Parse(Console.ReadLine());
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