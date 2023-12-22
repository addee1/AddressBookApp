using AddressBookApp.Models;
namespace AddressBookApp.Services;

public class ContactService
{
    private List<Contact> contacts = new List<Contact>(); // Skapar en lista som är tillgänglig inom klassen. 


    public void AddContact(Contact contact) // Metod som lägger till en kontakt i listan.
    {
        contacts.Add(contact);
    }


    public void RemoveContact(string email) // Metod som tar bort en kontakt i listan baserat på e-postadress.
    {
        var contact = contacts.Find(c => c.Email == email); // Söker igenom listan för att hitta en kontakt som matchar en given e-postadress.
        if (contact != null)    // Om en kontakt med den angivna e-postadressen finns i listan, tas den bort från listan. (Om kontakten INTE = null => Ta bort)
        {
            contacts.Remove(contact);
        }
    }


    public Contact GetContactByEmail(string email)      //  Metod som söker efter en kontakt baserat på en e-postadress.
    {
        return contacts.Find(c => c.Email == email);    // Returnera den första kontakten som matchar den angivna e-postadressen.
    }


    public List<Contact> GetAllContacts()   // Metod som returnera alla kontakter från listan.
    {
        return contacts;
    }
}
