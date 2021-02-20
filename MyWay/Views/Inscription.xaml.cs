using MyWay.data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;


namespace MyWay.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class Inscription : ContentPage
    {

        private HttpClient httpClient;
        public Inscription()
        {
            InitializeComponent();

            httpClient = new HttpClient();
        }

        private async void sinscrire_Clicked(object sender, EventArgs e)
        {
            try
            {
                User userajoute = new User();

                userajoute.user_name = Entry_Username.Text.Trim(); 
                userajoute.password = Entry_Password.Text;
                
                userajoute.latitude = EntryUserLatitude.Text.Trim();
                userajoute.longitude = EntryUserLongitude.Text.Trim();
                

                Uri uri;
                string json;
                StringContent content;
                HttpResponseMessage response = null;

                uri = new Uri(string.Format(Constants.inscription, string.Empty));
                json = JsonConvert.SerializeObject(userajoute);
                content = new StringContent(json, Encoding.UTF8, "application/json");


                response = await httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    string res = response.Content.ReadAsStringAsync().Result;
                    JObject jRes = JObject.Parse(res);
                    
                   await  Navigation.PushAsync(new AffichageUsers(userajoute));
                }

            }
            catch (Exception)
            {
                await DisplayAlert("Erreur", "Essayez ultérieurement ", "ok");
            }
            
        }
    }
}

