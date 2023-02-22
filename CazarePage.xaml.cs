using Plugin.LocalNotification;
using ProiectMobil.Models;

namespace ProiectMobil;

public partial class CazarePage : ContentPage
{
	public CazarePage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var cazare = (Cazare)BindingContext;
        await App.Database.SaveCazareAsync(cazare);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var cazare = (Cazare)BindingContext;
        await App.Database.DeleteCazareAsync(cazare);
        await Navigation.PopAsync();
    }

    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var cazare = (Cazare)BindingContext;
        var address = cazare.Adress;
        var locations = await Geocoding.GetLocationsAsync(address);
        var options = new MapLaunchOptions
        {
            Name = "Cazarea mea preferata" };
        var location = locations?.FirstOrDefault();
        //var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(41.90828171283743, 12.568616889040975);
        var distance = myLocation.CalculateDistance(location, DistanceUnits.Kilometers);
        if (distance < 4)
        {
            var request = new NotificationRequest
            {
                Title = "Ai de facut cumparaturi in apropiere!",
                Description = address,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
        await Map.OpenAsync(location, options);
    }

}