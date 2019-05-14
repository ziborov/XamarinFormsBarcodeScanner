using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using InfoplusTest2.Models;
using InfoplusTest2.Views;
using InfoplusTest2.ViewModels;
using ZXing.Mobile;

namespace InfoplusTest2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        /// <summary>
        /// Product code scanning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Code_Clicked(object sender, EventArgs e)
        {
            
            var scanner = new MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result == null) return;

            var resultString = result.Text;

            foreach(Item item in viewModel.Items)
            {
                if (item.CodeString.Equals(resultString))
                {
                    await DisplayAlert("Product is detected", 
                        "Scanner code is " + resultString,
                        "OK");
                    await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
                    return;
                }
                
            }

            await DisplayAlert("Product is not detected", 
                "Scanner code is " + resultString 
                + ". Press ADD for new product adding", 
                "OK");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}