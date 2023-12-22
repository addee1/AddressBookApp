using AddressBookApp.Models;
namespace AddressBookApp.Services;

public class ContactManager
{
    private List<Contact> contacts = new List<Contact>();
    private FileService fileService = new FileService();

    public ContactManager()
    {
        LoadContacts();
    }

    public void AddContact()
    {
        Contact contact = new Contact();

        Console.Clear();

        Console.WriteLine("Ange förnamn:");
        contact.FirstName = Console.ReadLine()!;

        Console.Clear();

        Console.WriteLine("Ange efternamn:");
        contact.LastName = Console.ReadLine()!;

        Console.Clear();

        Console.WriteLine("Ange telefonnummer:");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.Clear();

        Console.WriteLine("Ange e-post adress:");
        contact.Email = Console.ReadLine()!;

        Console.Clear();

        Console.WriteLine("Ange adressinformation:");
        contact.Address = Console.ReadLine()!;

        Console.Clear();

        contacts.Add(contact);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Kontakt tillagd.");
    }

    public void ListContacts()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("KONTAKT-LISTA:");
        Console.WriteLine("--------------");
        Console.ForegroundColor = ConsoleColor.White;
        foreach (var contact in contacts)  // Skriver ut alla kontakter i listan
        {
            Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName} Telefonnummer: {contact.PhoneNumber}, E-post: {contact.Email}, Adress: {contact.Address}");
        }

        Console.WriteLine("");
        Console.WriteLine("Tryck på valfri knapp för att gå tillbaka..");
        Console.ReadKey();
        Console.Clear();

    }

    public void ShowContactDetails()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("KONTAKT INFORMATION:");
        Console.WriteLine("--------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Ange en e-postadress för att se detaljerad information om kontakten: ");
        string email = Console.ReadLine()!;
        Console.Clear();

        var contact = contacts.Find(c => c.Email == email); // Söker efter en kontakt i listan "contacts" med epost-adressen.
        if (contact != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("KONTAKT INFORMATION:");
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Detaljer för kontakt med e-post: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(email);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"E-post: {contact.Email}");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Adress: {contact.Address}");
            Console.WriteLine("------------------------------");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Kontakten hittades inte.");
            Console.WriteLine("");
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("Tryck på valfri knapp för att gå tillbaka..");
        Console.ReadKey();
        Console.Clear();
    }

    public void RemoveContact()
    {
        Console.Clear();
        Console.WriteLine("Ange e-postadress för att ta bort kontakt:");
        string email = Console.ReadLine()!;
        Console.Clear();

        var contact = contacts.Find(c => c.Email == email);
        if (contact != null)
        {
            contacts.Remove(contact);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{contact.FirstName} {contact.LastName} har tagits bort från listan");
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Kontakten hittades inte.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Tryck på valfri knapp för att gå tillbaka..");
        Console.ReadKey();
        Console.Clear();
    }

    private void LoadContacts()
    {
        contacts = fileService.LoadContacts();
    }

    public void SaveContacts()
    {
        fileService.SaveContacts(contacts);
    }
}
