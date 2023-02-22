using ProiectMobil.Models;

namespace ProiectMobil;

public partial class Destinatii : ContentPage
{
	public Destinatii()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetCountryListsAsync();
    }
    async void OnCountryListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DestinatiePage
        {
            BindingContext = new CountryList()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new DestinatiePage
            {
                BindingContext = e.SelectedItem as CountryList
            });
        }
    }
}