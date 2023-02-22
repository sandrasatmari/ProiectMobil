using System;
using ProiectMobil.Data;
using System.IO;
namespace ProiectMobil;

public partial class App : Application
{
    static ClujFlyDatabase database; 
	public static ClujFlyDatabase Database 
	{ 
		get 
		{ 
			if (database == null) 
			{ 
				database = new ClujFlyDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ClujFly.db3")); 
			} return database; 
		} 
	}
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
