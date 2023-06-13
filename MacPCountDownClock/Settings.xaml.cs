using MacPCountDownClock.Helpers;
using MacPCountDownClock.Models;

namespace MacPCountDownClock;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
	}

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        DateTime eventDateTime = new DateTime(
            EventDtp.Date.Year,
            EventDtp.Date.Month,
            EventDtp.Date.Day,
            EventTmp.Time.Hours,
            EventTmp.Time.Minutes,
            EventTmp.Time.Seconds);

        IOUtils.SaveCountDownData(new CountDownData { CounterFor = CounterForTxt.Text, CountDownDateTime = eventDateTime });
        SettingsLyt.BackgroundColor = new Color(168, 230, 122);
        await Task.Delay(100);
        SettingsLyt.BackgroundColor = new Color(230, 223, 122);
        await Task.Delay(100);
        SettingsLyt.BackgroundColor = new Color(230, 162, 122);
        await Task.Delay(100);
        SettingsLyt.BackgroundColor = new Color(242, 203, 237);
        await Task.Delay(100);
        SettingsLyt.BackgroundColor = new Color(255, 255, 255);
    }

    private async void OnReturnClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}