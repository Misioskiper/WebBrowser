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
using Przegladarka.Logic;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Przegladarka
{
    public enum AddFavoriteResult
    {
        Add,
        Cancel
    }
    public sealed partial class AddFavorite : ContentDialog
    {
        public AddFavoriteResult Result { get; set; }
        public string SiteName { get; set; }
        public string SiteUrl { get; set; }
        Library library = new Library();
        public AddFavorite(string siteUrl, Library lib)
        {
            this.InitializeComponent();
            _siteUrlTextBox.Text = siteUrl;
            library = lib;
        }

        private void AddButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Result = AddFavoriteResult.Add;

            SiteName = _siteNameTextBox.Text;
            SiteUrl = _siteUrlTextBox.Text;
            Favorite fav = new Favorite(SiteName, SiteUrl);
            library.AddFavorite(fav);
        }

        private void CancelButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Result = AddFavoriteResult.Cancel;
        }
    }
}
