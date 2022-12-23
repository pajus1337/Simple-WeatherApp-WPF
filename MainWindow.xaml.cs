using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;


namespace WeatherApp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string weatherAppAPI = "4f4b53ca543b359fc5077b4f66500be0";
        private string requestUrl = "https://api.openweathermap.org/data/2.5/weather";
        public MainWindow()
        {
            InitializeComponent();
            UpdateData("Tuchola");
        }

         public void UpdateData(string city)
        {
            WeatherMapRespons result = GetWeatherData(city);
            string finalImage = "sun.png";
            string currentWeather = result.weather[0].main.ToLower();

            if (currentWeather.Contains("cloud"))
            {
                finalImage = "cloud.png";
            }

            else if (currentWeather.Contains("rain"))
            {
                finalImage = "rain.png";
            }
            else if (currentWeather.Contains("snow"))
            {
                finalImage = "rain.png";
            }
            backgroundImage.ImageSource = new BitmapImage(new Uri(@"Images/" + finalImage, UriKind.RelativeOrAbsolute));
            labelTemperature.Content = result.main.temp.ToString("F0") + "°C";
            labelWeather.Content = result.weather[0].description.ToString();
        }
        public WeatherMapRespons GetWeatherData(string city)
        {
            HttpClient httpClient = new HttpClient();
            var finalUri = requestUrl + "?q=" + city + "&appid=" + weatherAppAPI + "&units=metric";
            HttpResponseMessage httpResponse = httpClient.GetAsync(finalUri).Result; // waiting for the resultat of Get A Sync -> proby synchronizacji
            string response = httpResponse.Content.ReadAsStringAsync().Result;
            WeatherMapRespons weatherMapRespons = JsonConvert.DeserializeObject<WeatherMapRespons>(response);
            return weatherMapRespons;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = textBoxQuery.Text;
            UpdateData(query);
        }
    }
}
