using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Witaj! Wybierz jako kto chcesz się zalogować:\n1. Klient\n2. Pracownik");
        string logowanie = Console.ReadLine();
        switch(logowanie){
            case "1":
                Console.WriteLine("Wybierz opcję:\n1. Przeglądaj produkty\n2. Wyświetl koszyk\n3. Złóż zamówienie\n4. Opłać zamówienie\n5.Sprawdź status zamówienia\n6. Wyjdź");
                break;
            case "2":
                break;
            default:
                Console.WriteLine("Niepoprawny wybór");
                
        }
    }
}