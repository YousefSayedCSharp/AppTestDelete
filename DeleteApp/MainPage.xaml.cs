
namespace DeleteApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        load();
    }

    private async void load()
    {
        List<string> str1 = new()
        {
            "item 1/1",
            "item 1/2",
            "item 1/3"
        };
        cv1.ItemsSource = str1;

        List<string> str2 = new()
        {
            "item 2/1",
            "item 2/2",
            "item 2/3"
        };
        cv2.ItemsSource = str2;

        List<string> str3 = new()
        {
            "item 3/1",
            "item 3/2",
            "item 3/3",
            "item 3/4",
            "item 3/5",
            "item 3/6",
            "item 3/7",
            "item 3/8",
            "item 3/9"
        };
        cv3.ItemsSource = str3;

        await Task.Run(async () =>
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                while(true)
                {
                    await Task.Delay(100);
                    double dbl = btn1.HeightRequest + 20;
                    cv3.Margin = new Thickness(0,dbl,0,0);
                    if (dbl > 20)
                    {
                        break;
                    }
                }
            });
        });
    }

    private void btn1_Clicked(object sender, EventArgs e)
    {
        if (cv1.IsVisible)
        {
            cv1.IsVisible = false;
        }
        else
        {
            cv1.IsVisible = true;
            cv2.IsVisible = false;
        }
    }

    private void btn2_Clicked(object sender, EventArgs e)
    {
        if (cv2.IsVisible)
        {
            cv2.IsVisible = false;
        }
        else
        {
            cv2.IsVisible = true;
            cv1.IsVisible = false;
        }
    }

    private async void btnGO_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.Navigation.PushAsync(new MyWebPage());
        }catch(Exception ex)
        {
            await DisplayAlert("",ex.Message,"OK");
        }
    }
}
