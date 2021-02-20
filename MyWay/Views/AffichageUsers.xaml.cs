using MyWay.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyWay.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AffichageUsers : ContentPage
    {
        private HttpClient useraffiche = new HttpClient();

        private HttpClient httpClient = new HttpClient();
        User myuser;
        public AffichageUsers(User user)
        {
            InitializeComponent();
            this.myuser = user;
        }  
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            HttpResponseMessage response = await useraffiche.GetAsync(Constants.affichageusers+"/"+myuser.id_user);
            
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                List<User> users = JsonConvert.DeserializeObject<List<User>>(responseBody);


                Console.WriteLine(responseBody);

                MyListView.ItemsSource = users;
            }
        }

        private async void RefuserUser_Clicked(object sender, EventArgs e)
        {
            try
            {
                
                Request newrequest = new Request();
                newrequest.me = myuser.id_user;
                User selecteduser = (User)((Button)sender).CommandParameter;
                newrequest.other = selecteduser.id_user;
                newrequest.status_id = 3;

               

                Uri uri;
                string json;
                StringContent content;
                HttpResponseMessage response = null;

                uri = new Uri(string.Format(Constants.refuseruser, string.Empty));
                
                
                json = JsonConvert.SerializeObject(newrequest);
                content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await httpClient.PostAsync(uri, content);

                //string res = response.Content.ReadAsStringAsync().Result;
                // Request newrequest2 = JsonConvert.DeserializeObject<Request>(res);

                




                if (response.IsSuccessStatusCode)
                {
                    // successful
                }
                else
                {
                    // error in the connection with the server api
                    await DisplayAlert("Erreur", "Essayez ultérieurement ", "ok");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", "Essayez ultérieurement ", "ok");

                Console.Write(ex);
            }
        }

        private async void clicme_Clicked(object sender, EventArgs e)
        {
            try
            {

                Request newrequest = new Request();
                newrequest.me = myuser.id_user;
                User selecteduser = (User)((Button)sender).CommandParameter;
                newrequest.other = selecteduser.id_user;
                newrequest.status_id = 1;

                Uri uri;
                string json;
                StringContent content;
                HttpResponseMessage response = null;


                uri = new Uri(string.Format(Constants.ajouteruser, string.Empty));
                json = JsonConvert.SerializeObject(newrequest);
                content = new StringContent(json, Encoding.UTF8, "application/json");


                response = await httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Button button = sender as Button;
                    
                        button.Text = "En attente";
                  
                }
                else
                {
                    // error in the connection with the server api
                    await DisplayAlert("Erreur", "Essayez ultérieurement ", "ok");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", "Essayez ultérieurement ", "ok");

                Console.Write(ex);
            }
        
    }
    }
}