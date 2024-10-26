using System;
using Microsoft.Maui.Controls;
using System.Web;

namespace DeleteApp
{
    public partial class MyWebPage : ContentPage
    {
        public MyWebPage()
        {
            InitializeComponent();
        }

        private void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            // ���� �� ���� URL
            if (Uri.TryCreate(e.Url, UriKind.Absolute, out Uri uri))
            {
                // ����� �������� �� URL
                var queryParams = HttpUtility.ParseQueryString(uri.Query);
                // ���� ��� ��� ��� ������� "registrationId" �������
                string registrationId = queryParams.Get("registrationId");

                if (!string.IsNullOrEmpty(registrationId))
                {
                    // ��� ����� ������� �� ����� ������
                    DisplayAlert("Received from WebView", registrationId, "OK");

                    // ����� ������ ���� ����� ����� ������
                    e.Cancel = true;
                }
            }
        }

        private async void OnSendNameClicked(object sender, EventArgs e)
        {
            string nameToSend = "Yousef Sayed";
            // ����� ����� ��� ��� WebView �������� InvokeScriptAsync
            await MyWebView.EvaluateJavaScriptAsync($"document.getElementById('welcome').innerHTML = 'Welcome {nameToSend}';");
        }

    }
}
