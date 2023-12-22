using AddressBookApp.Models;
using Newtonsoft.Json;
namespace AddressBookApp.Services;

public class FileService
{
    private const string DirectoryPath = @"C:\code\C#\AddressBookApp\AddressBookApp\Contactlist";
    private const string FileName = "contacts.json";
    private static string FilePath = Path.Combine(DirectoryPath, FileName);

    public List<Contact> LoadContacts()
    {
        List<Contact> contacts = new List<Contact>();

        if (File.Exists(FilePath))          // Om sökvägen "FilePath" existerar läser den innehållet från filen som en JSON sträng. 
        {
            string json = File.ReadAllText(FilePath);
            contacts = JsonConvert.DeserializeObject<List<Contact>>(json)!; // Konverterar till en lista av "Contact" objekt
        }

        return contacts;
    }

    public void SaveContacts(List<Contact> contacts)
    {
        string json = JsonConvert.SerializeObject(contacts, Formatting.Indented);   // Tar listan "Contact" och konverterar den till en JSON sträng. 
        File.WriteAllText(FilePath, json);      // Sparar strängen till en fil
    }

}