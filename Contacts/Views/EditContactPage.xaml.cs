using Contacts.Models;
using Contact = Contacts.Models.Contact;

namespace Contacts.Views;

[QueryProperty(nameof(ContactId),"Id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;

	public EditContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
        Shell.Current.GoToAsync("..");
    }

    public string ContactId
    {
        set
        {
            contact = ContactRepository.GetContactById(int.Parse(value));
            lblName.Text = contact.Name;
        }
    }
}