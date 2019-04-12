using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Przegladarka
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Uri HomePage { get; set; }
        public Uri Page { get; set; }
        private string _homePage = "https://google.pl";

        public MainPage()
        {
            this.InitializeComponent();
            this.HomePage = new Uri(_homePage);
            this.webView.Navigate(HomePage);
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            this.webView.Stop();
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            this.webView.Refresh();
        }

        private void AddToFav_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string link = TextBoxSearch.Text;
            this.Page = new Uri(link);
            this.webView.Navigate(Page);
        }

        private void TextBoxSearch_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                this.Page = new Uri(TextBoxSearch.Text);
                this.webView.Navigate(Page);
            }
        }
    }
}
