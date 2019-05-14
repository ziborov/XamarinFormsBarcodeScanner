using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using InfoplusTest2.Models;

namespace InfoplusTest2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Product name",
                Description = "This is an item description.",
                CodeString = "Product code string",
                PictureURL = "https://drive.google.com/uc?export=download&id=1hkPeWdtlTYLQyx4RX8PCiQtb3Zal7-Th"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}