using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using InfoplusTest2.Models;
using InfoplusTest2.ViewModels;

namespace InfoplusTest2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Product name",
                Description = "This is an item description.",
                CodeString = "Product code string",
                PictureURL = "https://drive.google.com/uc?export=download&id=1hkPeWdtlTYLQyx4RX8PCiQtb3Zal7-Th"
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}