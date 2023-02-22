using ProiectMobil.Models;

namespace ProiectMobil;

public partial class Cazari : ContentPage
{
	public Cazari()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetCazariAsync();
    }
    async void OnCazareAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CazarePage
        {
            BindingContext = new Cazare()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new CazarePage
            {
                BindingContext = e.SelectedItem as Cazare
            });
        }
    }
}