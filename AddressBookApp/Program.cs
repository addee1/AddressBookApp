using AddressBookApp.Services;
namespace AddressBookApp;

class Program
{
    static void Main(string[] args)
    {
        var adressBook = new MainMenu();  // När vi startar applikationen körs "MainMenu"
        adressBook.Run();

        Console.Clear();
        Console.WriteLine("Tryck på valfri knapp för att avsluta...");
        Console.ReadKey();
    }
}
