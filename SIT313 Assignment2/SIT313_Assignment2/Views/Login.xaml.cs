using SIT313_Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SIT313_Assignment2
{
    public partial class Login : ContentPage
    {
        public CustomerQuery _CustomerQuery;
        public CustomersDB _CustomerDB;

        public Login()
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
            this.Title = "Login";
            var image = new Image { Source = "newlogo.png", WidthRequest = 250 };
            var lo = new Label { Text = "Login", TextColor = Color.Maroon, FontSize = 20 };
            var username = new Entry { Placeholder = "Username", BackgroundColor = Color.White, PlaceholderColor = Color.Gray, TextColor=Color.Black};
            var password = new Entry { IsPassword = true, Placeholder = "Password", BackgroundColor = Color.White, PlaceholderColor = Color.Gray, TextColor = Color.Black };
            var login = new Button { Text = "Login", BackgroundColor = Color.Maroon, TextColor = Color.White };
            var lbl_signup = new Label { Text = "Not a Member? Click the button and sign up now!", TextColor = Color.Black, FontSize = 10 };
            var signup = new Button { Text = "Sign up", BackgroundColor = Color.Maroon, TextColor = Color.White };

            signup.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushAsync(new SignUp());
            };

            login.Clicked += (object sender, EventArgs e) =>
            {
                CustomersDB _CustomerDB = new CustomersDB();
                CustomerQuery _CustomerQuery = new CustomerQuery();



                CustomersDB c = _CustomerQuery.GetCustName(username.Text);
                if (c != null)
                {
                    if (password.Text == c.Password)
                    {
                        // DisplayAlert("Alert", "Login succesful!", "OK");
                        Navigation.PushAsync(new Views.PayNow());
                    }
                    else
                    {
                        DisplayAlert("Alert", "Login failed", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Alert", "Login failed", "OK");
                }
                //     DisplayAlert("Alert", "ID: " + c.Id + "  UserName: " + c.Name + " Password: " + c.Password, "OK");

            };



            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("#f2e6d9"),
                Children = { image, lo, username, password, login, lbl_signup, signup }
            };
        }


    }
}
