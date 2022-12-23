using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp_WPF
{
       public class WeatherMapRespons
    {
        public Main main;
        public List<Weather> weather;
    }
}
