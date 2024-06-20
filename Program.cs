using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
class Program
{
    public List<Magazyn> import_magazyny(){
        string line;
        List<Magazyn> magazyny = new List<Magazyn>();
        System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\..\data\magazyny.txt");
        while((line = file.ReadLine()) != null)
        {
            string[] words = line.Split(';');
            Magazyn magazyn = new Magazyn(int.Parse(words[0]));
            magazyny.Add(magazyn);
        }
        file.Close();
        return magazyny;
    }
    public void import_zamowienia(List<Magazyn> magazyny){
        string line;
        System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\..\data\zamowienia.txt");
        while((line = file.ReadLine()) != null)
        {
            string[] words = line.Split(';');
            Zamowienie zamowienie = new Zamowienie(int.Parse(words[0]), int.Parse(words[1]), words[3], DateTime.Parse(words[3]), DateTime.Parse(words[4]));
            zamowienie.zmienStatus(words[5]);
            foreach(string produkt in words[2].Split(',')){
                zamowienie.dodajProdukt(magazyny.Find(x=>x.Produkty.Exists(y=>y.Id == int.Parse(produkt))).Produkty.Find(y=>y.Id == int.Parse(produkt)));
            }
        }
        file.Close();
    }
    public void import_pracownicy(List<Magazyn> magazyny){
        string line;
        System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\..\data\pracownicy.txt");
        while((line = file.ReadLine()) != null)
        {
            string[] words = line.Split(';');
            Pracownik pracownik = new Pracownik(words[0], words[1], int.Parse(words[2]), magazyny.Find(x=>x.Id == int.Parse(words[3])));
        }
        file.Close();
    }
    public List<Klient> import_klienci(){
        string line;
        List<Klient> klienci = new List<Klient>();
        System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\..\data\klienci.txt");
        while((line = file.ReadLine()) != null)
        {
            string[] words = line.Split(';');
            Klient klient = new Klient(words[0], words[1], words[2], int.Parse(words[3]));
            klienci.Add(klient);
        }
        file.Close();
        return klienci;
    }
    public void import_produkty(Pracownik pracownik){
        string line;

        System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\..\data\produkty.txt");
        while((line = file.ReadLine()) != null)
        {
            string[] words = line.Split(';');
            pracownik.dodajProdukt(words[0],int.Parse(words[1]),double.Parse(words[2]),words[3],words[4],int.Parse(words[5]),int.Parse(words[6]));
        }

        file.Close();
    }
    static public void render_prod(Magazyn magazyn, string autor="", string kategoria="", string tytul=""){
        Console.WriteLine("   ID | Tytuł                          | Autor                | Kategoria       | Typ             | Cena");
        Console.WriteLine("------|--------------------------------|----------------------|-----------------|-----------------|----------");
        foreach(Produkt produkt in magazyn.Produkty){
            if(produkt is Fizyczne && ((Fizyczne)produkt).Stan == 0){
                continue;
            }
            if(autor != "" && produkt.Autor != autor){
                continue;
            }
            if(kategoria != "" && produkt.Kategoria != kategoria){
                continue;
            }
            if(tytul != "" && produkt.Nazwa != tytul){
                continue;
            }
            string typ = produkt is Twarda_okladka ? "Twarda okładka" : produkt is Miekka_okladka ? "Miękka okładka" : produkt is Audiobook ? "Audiobook" : "E Book";
            Console.WriteLine(produkt.Id.ToString().PadLeft(5,' ') + " | " + produkt.Nazwa.PadRight(30, ' ') + " | " + produkt.Autor.PadRight(20, ' ') + " | " + produkt.Kategoria.PadRight(15, ' ') + " | " + typ.PadRight(15, ' ') + " | " + produkt.Cena.ToString("F").PadLeft(5,' ') + " zł");
        }
    }

    static void Main()
    {
        Magazyn magazyn = new Magazyn(1);
        Pracownik pracownik = new Pracownik("Jan", "Kowalski", 1, magazyn);

        

        Klient klient = new Klient("Adam", "Małysz", "Wisła", 1);
        Kurier kurier = new Kurier();
        string wybor = "";
        int i;
        string logowanie = "";
        int numer_zamowienia;
        string filtr, f_tytul, f_autor, f_kategoria;
        while(logowanie != "4"){
            Console.WriteLine("Witaj! Wybierz jako kto chcesz się zalogować:\n1. Klient\n2. Pracownik\n3. Kurier\n4. Wyjdź");
            logowanie = Console.ReadLine();
            switch(logowanie){
                case "1":
                    wybor = "";

                    while (wybor != "6"){
                        filtr = f_tytul = f_autor = f_kategoria = "";
                        Console.WriteLine("\nWybierz opcję:\n1. Przeglądaj produkty\n2. Wyświetl koszyk\n3. Złóż zamówienie\n4. Opłać zamówienie\n5. Sprawdź status zamówienia\n6. Wyjdź");
                        wybor = Console.ReadLine();
                        switch(wybor){
                            case "1":
                                while(filtr != "4"){
                                    Console.WriteLine("1. Ustaw filtr tytuł\n2. Ustaw filtr kategoria\n3. Ustaw filtr autor\n4. Zastosuj filtry");
                                    filtr = Console.ReadLine();
                                    switch(filtr){
                                        case "1":
                                            Console.WriteLine("Podaj tytuł:");
                                            f_tytul = Console.ReadLine();
                                            break;
                                        case "2":
                                            Console.WriteLine("Podaj kategorię:");
                                            f_kategoria = Console.ReadLine();
                                            break;
                                        case "3":
                                            Console.WriteLine("Podaj autora:");
                                            f_autor = Console.ReadLine();
                                            break;
                                        case "4":
                                            render_prod(magazyn, f_autor, f_kategoria, f_tytul);
                                            break;
                                    }
                                }

                                Console.WriteLine("Podaj numer produktu, który chcesz dodać do koszyka. Jeżeli chcesz wrócić do menu, wciśnij ENTER:");
                                string numer = Console.ReadLine();
                                if(numer == "") break;
                                try{
                                    klient.dodajDoKoszyka(magazyn.znajdzProdukt(int.Parse(numer)));
                                }
                                catch(Exception e){
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case "2":
                                Console.WriteLine("Koszyk:");
                                klient.przegladaj();
                                break;
                            case "3":
                                try{
                                    klient.zamow();
                                }
                                catch(Exception e){
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case "4":
                                if (klient.Zamowienia.Find(x => x.Status == "Oczekujace na zaplate") == null){
                                    Console.WriteLine("Brak zamówień do opłacenia");
                                    break;
                                }
                                Console.WriteLine("Wybierz id zamówienia do opłacenia:");
                                foreach(Zamowienie zamowienie in klient.Zamowienia){
                                    if(zamowienie.Status == "Oczekujace na zaplate"){
                                        Console.WriteLine(zamowienie+" ["+zamowienie.Numer + "] cena: "+zamowienie.Wartosc.ToString("F") + " zł");
                                    }
                                }
                                try{
                                    numer_zamowienia = int.Parse(Console.ReadLine());
                                    Zamowienie zamowienie_oplacone = klient.Zamowienia.Find(x => x.Numer == numer_zamowienia);
                                    klient.zaplac(zamowienie_oplacone);
                                    if (zamowienie_oplacone.ListaProduktow.Exists(p => p is Cyfrowe)){ //Jeżeli istnieje jakiś Cyfrowy to generuje link od razu
                                        zamowienie_oplacone.generujLink();
                                    }
                                    if (zamowienie_oplacone.ListaProduktow.Exists(p => p is Fizyczne)){ 
                                        magazyn.ZamowieniaDoRealizacji.Add(zamowienie_oplacone);
                                    }
                                    else{
                                        zamowienie_oplacone.zmienStatus("Zrealizowane");
                                    }
                                }
                                catch(NullReferenceException){
                                    Console.WriteLine("Nie ma takiego zamówienia");
                                }
                                catch(Exception e){
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case "5":
                                Console.WriteLine("Lista twoich zamówień:");
                                foreach(Zamowienie zamowienie in klient.Zamowienia){
                                    Console.WriteLine("Zamówienie numer "+zamowienie.Numer+":");
                                    foreach(Produkt produkt in zamowienie.ListaProduktow){
                                        Console.WriteLine(produkt.Nazwa + " " + produkt.Cena + " zł");
                                    }
                                    Console.Write(zamowienie.Link != "" ? "Link do cyfrowego produktu: "+zamowienie.Link+"\n": "");
                                    Console.WriteLine("Status: "+zamowienie.Status);
                                    Console.WriteLine("Data zamówienia: "+zamowienie.DzienZamowienia);
                                    Console.WriteLine("Data ostatniej aktualizacji statusu: "+zamowienie.OstatniaAktualizacja);
                                    Console.WriteLine();
                                }
                                break;
                        }
                    }
                    break;
                case "2":
                    int id;
                    wybor = "";
                    while(wybor != "6"){
                        Console.WriteLine("Wybierz opcję:\n1. Zrealizuj zamówienie\n2. Zamów kuriera\n3. Dodaj produkt\n4. Ustaw stan produktu\n5. Usuń produkt\n6. Wyjdź");
                        wybor = Console.ReadLine();
                        switch (wybor){
                            case "1":
                                i = 1;
                                Console.WriteLine("Wybierz id zamówienia do zrealizowania:");
                                foreach(Zamowienie zamowienie in magazyn.ZamowieniaDoRealizacji){
                                    Console.WriteLine(zamowienie+" numer: "+zamowienie.Numer);
                                }
                                try{
                                    numer_zamowienia = int.Parse(Console.ReadLine());
                                    pracownik.realizaZamowienie(numer_zamowienia);
                                }
                                catch(Exception e){
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case "2":
                                pracownik.zamowKuriera(kurier);
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
                    }
                    break;
                case "3":
                    Console.WriteLine("Lista zamówień do dostarczenia:");
                    foreach(Zamowienie zamowienie in kurier.Zamowienia){
                        Console.WriteLine(zamowienie+" numer: "+zamowienie.Numer);
                    }
                    try{
                        numer_zamowienia = int.Parse(Console.ReadLine());
                        kurier.dostarcz(kurier.Zamowienia.Find(x => x.Numer == numer_zamowienia));
                    }
                    catch(NullReferenceException){
                        Console.WriteLine("Nie ma takiego zamówienia");
                    }
                    catch(Exception e){
                        Console.WriteLine(e.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór");
                    break;
            }
        }
    }
}