using Przegladarka.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
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
        private string _homePage = "https://www.google.pl/";
        private Library _library { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            InitializeMainPage();
            _library = new Library();
            _library.ImportFromFile();
            FavoritesComboBox.DataContext = _library.GetFavorites();
        }
    
        private void InitializeMainPage()
        {
            var appView = ApplicationView.GetForCurrentView();
            appView.Title = "Misioskiper.dev Internet Browser";
            HomePage = new Uri(_homePage);
            webView.Navigate(HomePage);
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if(webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if(webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            webView.Stop();
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            webView.Refresh();
        }

        private async void AddToFav_Click(object sender, RoutedEventArgs e)
        {
            var currentSiteUrl = webView.Source.ToString();
            var addToFavoriteDialog = new AddFavorite(currentSiteUrl, _library);
            await addToFavoriteDialog.ShowAsync();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string link = _urlTextBox.Text;
            Page = new Uri(link);
            webView.Navigate(Page);
        }

        private async void _urlTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key != VirtualKey.Enter)
                return;

            var searchedSite = _urlTextBox.Text;

            if (searchedSite.HasHttpScheme() || searchedSite.HasHttpsScheme())
            {
                webView.Navigate(new Uri(searchedSite));
            }
            else
            {
                var dialog = new MessageDialog("Please type valid site address.");
                await dialog.ShowAsync();
            }

        }

        private void WebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            _urlTextBox.Text = sender.Source.ToString();
            Prev.IsEnabled = sender.CanGoBack;
            Next.IsEnabled = sender.CanGoForward;
        }

        private void FavoritesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedFav = (Favorite)FavoritesComboBox.SelectedItem;
            webView.Navigate(new Uri(selectedFav.SiteUrl));
        }
    }
}
