namespace AddressBookApp.Services;

public class MainMenu
{
    private ContactManager contactManager = new ContactManager();

    public void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green; // Ändrar färg på texten till grön
        Console.WriteLine("ADRESS-BOK AV ADAM OTTOSSON");
        Console.WriteLine("-----------------------------");

        bool exit = false;
        while (!exit) // När den inte är false "gör detta"
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Lägg till en kontakt");
            Console.WriteLine("2. Visa alla kontakter");
            Console.WriteLine("3. Visa information om en kontakt");
            Console.WriteLine("4. Radera en kontakt");
            Console.WriteLine("5. Avsluta");

            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        contactManager.AddContact();
                        break;
                    case 2:
                        contactManager.ListContacts();
                        break;
                    case 3:
                        contactManager.ShowContactDetails();
                        break;
                    case 4:
                        contactManager.RemoveContact();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ogiltigt val. Försök igen.");
            }
        }

        contactManager.SaveContacts();
    }
}
