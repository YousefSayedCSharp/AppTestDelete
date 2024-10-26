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
            //  Õﬁﬁ „‰ ÊÃÊœ URL
            if (Uri.TryCreate(e.Url, UriKind.Absolute, out Uri uri))
            {
                //  Õ·Ì· «·„⁄·„«  ›Ì URL
                var queryParams = HttpUtility.ParseQueryString(uri.Query);
                //  Õﬁﬁ „„« ≈–« ﬂ«‰ «·„⁄«„· "registrationId" „ÊÃÊœ«
                string registrationId = queryParams.Get("registrationId");

                if (!string.IsNullOrEmpty(registrationId))
                {
                    // ⁄—÷ «·«”„ «·„” ·„ ›Ì ‰«›–… „‰»Àﬁ…
                    DisplayAlert("Received from WebView", registrationId, "OK");

                    // ≈·€«¡ «· ‰ﬁ· ·„‰⁄ ≈⁄«œ…  Õ„Ì· «·’›Õ…
                    e.Cancel = true;
                }
            }
        }

        private async void OnSendNameClicked(object sender, EventArgs e)
        {
            string nameToSend = "Yousef Sayed";
            // ≈—”«· «·«”„ ≈·Ï «·‹ WebView »«” Œœ«„ InvokeScriptAsync
            await MyWebView.EvaluateJavaScriptAsync($"document.getElementById('welcome').innerHTML = 'Welcome {nameToSend}';");
        }

    }
}
