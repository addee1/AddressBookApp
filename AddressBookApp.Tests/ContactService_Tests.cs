using AddressBookApp.Models;
using AddressBookApp.Services;

namespace AddressBookApp.Tests;

public class ContactService_Tests
{
    [Fact]
    public void AddContact_ShouldAddContactToList()
    {
        // Arrange                                                                // Skapar en instans av "ContactService" och lägger till en ny kontakt i listan
        ContactService contactService = new ContactService();
        Contact newContact = new Contact
        {
            FirstName = "Adam",
            LastName = "Ottosson",
            PhoneNumber = "123456789",
            Email = "adam@domain.com",
            Address = "Nyby 313B"
        };

        // Act                                                                    // Anropar "AddContact" och lägger till en kontakt i listan
        contactService.AddContact(newContact);

        // Assert                                                                 // Kontrollerar att "newContact" finns i listan som returneras av "GetAllContacts" metoden
        Assert.Contains(newContact, contactService.GetAllContacts());
    }



    [Fact]
    public void RemoveContact_ShouldRemoveContactFromList()
    {
        // Arrange                                                                // Skapar en instans av "ContactService" och lägger till en ny kontakt i listan
        ContactService contactService = new ContactService();
        Contact contactToRemove = new Contact
        {
            FirstName = "Adam",
            LastName = "Ottosson",
            PhoneNumber = "123456789",
            Email = "adam@domain.com",
            Address = "Nyby 313B"
        };

        contactService.AddContact(contactToRemove);

        // Act                                                                    // Anropar "RemoveContact" metoden och använder den angivna e-post adressen
        contactService.RemoveContact("adam@domain.com");

        // Assert                                                                 // Kontrollerar att kontakten som är borttagen inte längre finns i listan
        Assert.DoesNotContain(contactToRemove, contactService.GetAllContacts());
    }



    [Fact]
    public void GetContactByEmail_ShouldReturnContactIfExists()
    {
        // Arrange                                                                // Skapar en instans av "ContactService" och lägger till en ny kontakt i listan
        ContactService contactService = new ContactService();
        Contact newContact = new Contact
        {
            FirstName = "Adam",
            LastName = "Ottosson",
            PhoneNumber = "123456789",
            Email = "adam@domain.com",
            Address = "Nyby 313B"
        };

        contactService.AddContact(newContact);

        // Act                                                                    // Anropar "GetContactByEmail" metoden och använder den angivna e-post adressen
        Contact retrievedContact = contactService.GetContactByEmail("adam@domain.com");

        // Assert                                                                 // Kontrollerar att en kontakt returneras och att uppgifterna matchar
        Assert.NotNull(retrievedContact);
        Assert.Equal("Adam", retrievedContact.FirstName);
        Assert.Equal("Ottosson", retrievedContact.LastName);
        Assert.Equal("123456789", retrievedContact.PhoneNumber);
        Assert.Equal("adam@domain.com", retrievedContact.Email);
        Assert.Equal("Nyby 313B", retrievedContact.Address);
    }



    [Fact]
    public void GetContactByEmail_ShouldReturnNullIfNotExists()
    {
        // Arrange                                                                // Finns inga kontakter i listan
        ContactService contactService = new ContactService();

        // Act                                                                    // Anropar "GetContactByEmail" metoden och använder den angivna e-post adressen
        Contact retrievedContact = contactService.GetContactByEmail("test-email-som-inte-finns@domain.com");

        // Assert                                                                 // Kontrollerar att "null" returneras eftersom kontakten inte finns i listan
        Assert.Null(retrievedContact);
    }
}

