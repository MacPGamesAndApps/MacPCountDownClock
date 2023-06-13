using MacPCountDownClock.Helpers;
using MacPCountDownClock.Models;

namespace MacPCountDownClock;

public partial class MainPage : ContentPage
{
	private DateTime countDownDateTime;

    public MainPage()
	{
		InitializeComponent();
	}

	private void OnPageLoaded(object sender, EventArgs e)
	{
		CountDownData countDownData = IOUtils.GetCountDownData();
		CounterForLbl.Text = countDownData.CounterFor;
		countDownDateTime = countDownData.CountDownDateTime;
		CountDownTimer();
    }

	private async void OnSettingsClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//Settings");
	}

	private async void CountDownTimer()
	{
        TimeSpan countDownToEvent;

		try
		{
			do
			{

				countDownToEvent = countDownDateTime - DateTime.Now;
				CountdownLbl.Text = string.Format("{0} days - {1} hours - {2} minutes - {3} seconds", countDownToEvent.Days, countDownToEvent.Hours, countDownToEvent.Minutes, countDownToEvent.Seconds);

				await Task.Delay(1000);

			} while (countDownToEvent.TotalMilliseconds > 0);
		}
		catch (Exception ex)
		{

		}	
	}
}

