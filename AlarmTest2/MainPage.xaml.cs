#if ANDROID
using AlarmTest2.Platforms.Android;
#endif

namespace AlarmTest2;

public partial class MainPage : ContentPage
{
	int count = 0;
	int notificationNumber = 0;
	INotificationManagerService notificationManager;

	public MainPage(INotificationManagerService manager)
	{
		InitializeComponent();
		this.notificationManager = manager;

		notificationManager.NotificationReceived += (sender, eventArgs) =>
        {
            var eventData = (NotificationEventArgs)eventArgs;
        };
	}

#if ANDROID
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        PermissionStatus status = await Permissions.RequestAsync<NotificationPermission>();
    }
#endif

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private void OnTimedNotifClicked(object sender, EventArgs e)
	{
		notificationNumber++;
        string title = $"Local Alarm #{notificationNumber}";
        //string message = $"You have now received {notificationNumber} notifications!";
		string message = $"Your alarm is ringing!";
		Console.WriteLine("TimeEntry.Text: " + TimeEntry.Text);
		notificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(Convert.ToInt32(TimeEntry.Text)));
	}
}

