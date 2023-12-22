using AddressBookApp.Models;
using AddressBookApp.Services;
namespace AddressBookApp.Tests;

public class FileService_Tests
{
    [Fact]
    public void LoadContacts_ReturnsListOfContacts()
    {
        // Arrange                                              // Skapar en instans av FileService-klassen
        FileService fileService = new FileService();
        string testFilePath = @"C:\code\C#\AddressBookApp\AddressBookApp\AddressBookApp.Tests\Contactlist\contacts.json";

        // Act                                                  // Anropar metoden "LoadContacts()" för att ladda kontakterna från filen
        List<Contact> contacts = fileService.LoadContacts();

        // Assert                                               // Kontrollerar om listan med kontakter inte är null
        Assert.NotNull(contacts);
    }



    [Fact]
    public void SaveContacts_WritesContactsToFile()
    {
        // Arrange                                              // Skapar tre test-kontakter
        FileService fileService = new FileService();
        List<Contact> testContacts = new List<Contact>
            {
                new Contact { FirstName = "Adam", LastName = "Ottosson", Email = "adam@domain.com" },
                new Contact { FirstName = "Hampus", LastName = "Jensen", Email = "hampus@domain.com" },
                new Contact { FirstName = "Johannes", LastName = "Jensen", Email = "johannes@domain.com" }
            };
        string testFilePath = @"C:\code\C#\AddressBookApp\AddressBookApp\AddressBookApp.Tests\Contactlist\contacts.json";

        // Act                                                  // Sparar dom till filen
        fileService.SaveContacts(testContacts);

        // Assert                                               // Kollar om filen existerar efter den sparats
        Assert.True(File.Exists(testFilePath));
    }
}
