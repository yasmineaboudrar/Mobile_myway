using MyWay.data;
using MyWay.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyWay
{
    public partial class MainPage : ContentPage
    {
        private HttpClient httpClient;
        public MainPage()
        {
            InitializeComponent();

            httpClient = new HttpClient();
        }

        private async  void SeConnecter_Clicked(object sender, EventArgs e)
        {
            try
            {
                User userauthentifie = new User();

                userauthentifie.user_name = Entry_Username.Text.Trim();
                userauthentifie.password = Entry_Password.Text.Trim();

                Uri uri;
                string json;
                StringContent content;
                HttpResponseMessage response = null;

                uri = new Uri(string.Format(Constants.mainpage, string.Empty));
                json = JsonConvert.SerializeObject(userauthentifie);
                content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await httpClient.PostAsync(uri, content);
                string res = response.Content.ReadAsStringAsync().Result;
                User user1= JsonConvert.DeserializeObject<User>(res);


                if (userauthentifie.user_name==user1.user_name && userauthentifie.password == user1.password)
                {
                   await Navigation.PushAsync(new AffichageUsers(user1));   
                }
                else
                {
                    await DisplayAlert("Erreur", "nom ou mot de passe erroné ","ok")  ;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", "nom ou mot de passe erroné ", "ok");
            }
           
        }

        private void nouveaucompte_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Inscription());
        }
    }
}
