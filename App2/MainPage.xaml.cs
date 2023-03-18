using MuseumXamarin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Xamarin.Forms;
using System.Net.Security;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        //public static WebClient client = new WebClient();

        //public string response = client.DownloadString("https://846f-46-146-73-126.eu.ngrok.io/api/drivers");
        void SecuredConnect()
        {
            ServicePointManager.ServerCertificateValidationCallback =
                            new RemoteCertificateValidationCallback
                            (delegate
                            { return true; }
                            );
        }
        void ConnectAPIWebDefault()
        {
            var client = new WebClient();
            var response = client.DownloadString("https://846f-46-146-73-126.eu.ngrok.io/api/drivers");
            LViewExhibits.ItemsSource = JsonConvert.DeserializeObject<List<Driver>>(response);

        }
        public MainPage()
        {
            
            InitializeComponent();
            SecuredConnect();
            ConnectAPIWebDefault();

        }

        

        
        

        private void LViewExhibits_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }


        

        private void btnFind_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(srchBarFindDriver.Text))
            {
                DisplayAlert("Упс", "Поле поиска не должно быть пустым", "Хорошо");

            }
            else 
            {
                var client = new WebClient();
                SecuredConnect();
                var response = client.DownloadString("https://846f-46-146-73-126.eu.ngrok.io/api/drivers");
                

                switch (pckSortBy.SelectedIndex)
                {
                    case 0:
                        
                        LViewExhibits.ItemsSource = JsonConvert.DeserializeObject<List<Driver>>(response).
                            Where(p => p.DriverSurname.ToLower().Contains(srchBarFindDriver.Text.ToLower()));
                        break;
                    case 1:
                        
                        LViewExhibits.ItemsSource = JsonConvert.DeserializeObject<List<Driver>>(response).
                            Where(p => p.DriverName.ToLower().Contains(srchBarFindDriver.Text.ToLower()));
                        break;
                    case 2:
                        LViewExhibits.ItemsSource = JsonConvert.DeserializeObject<List<Driver>>(response).
                            Where(p => p.DriverPassSeries.ToLower().Contains(srchBarFindDriver.Text.ToLower()));
                        break;
                    case 3:
                        LViewExhibits.ItemsSource = JsonConvert.DeserializeObject<List<Driver>>(response).
                            Where(p => p.DriverPassNumber.ToLower().Contains(srchBarFindDriver.Text.ToLower()));
                        break;
                }


                

            }


            

        }

        private void btnDeleteFilters_Clicked(object sender, EventArgs e)
        {
            
            SecuredConnect();
            ConnectAPIWebDefault();
            srchBarFindDriver.Text = "";
            DisplayAlert("Внимание", "Фильтры сброшены", "Хорошо");
        }

        
        private void pckSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
