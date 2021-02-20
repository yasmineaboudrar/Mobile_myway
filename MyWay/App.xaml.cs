using MyWay.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWay
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           /* MainPage = new GeolocationPa();*/
            

           NavigationPage np = new NavigationPage(new MainPage());
            MainPage = np;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
