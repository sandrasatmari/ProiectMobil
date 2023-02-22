using ProiectMobil.Models;

namespace ProiectMobil;

public partial class Orase : ContentPage
{
    CountryList sl;
    public Orase(CountryList slist)
    {
        InitializeComponent();
        sl = slist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var oras = (Oras)BindingContext;
        await App.Database.SaveOrasAsync(oras);
        listView.ItemsSource = await App.Database.GetOraseAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        Oras p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Oras;
            var lp = new ListOras()
            {
                CountryListID = sl.ID,
                OrasID = p.ID
            };
            await App.Database.DeleteOrasAsync(p);
            p.ListOrase = new List<ListOras> { lp };
            await Navigation.PopAsync();
        }
        
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetOraseAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Oras p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Oras;
            var lp = new ListOras()
            {
                CountryListID = sl.ID,
                OrasID = p.ID
            };
            await App.Database.SaveListOrasAsync(lp);
            p.ListOrase = new List<ListOras> { lp };
            await Navigation.PopAsync();
        }

    }
}