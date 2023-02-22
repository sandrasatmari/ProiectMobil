using ProiectMobil.Models;

namespace ProiectMobil;

public partial class DestinatiePage : ContentPage
{
	public DestinatiePage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (CountryList)BindingContext;
        slist.Date = DateTime.UtcNow;
        
        await App.Database.SaveCountryListAsync(slist);
        
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (CountryList)BindingContext;
        await App.Database.DeleteCountryListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Orase((CountryList)
        this.BindingContext)
        {
            BindingContext = new Oras()
        });
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (CountryList)BindingContext;
        listView.ItemsSource = await App.Database.GetListOraseAsync(shopl.ID);
    }
}

