using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace sunset
{
	class Program
	{
		static void Main(string[] args)
		{
			string categoryUrl = "https://api.sunrise-sunset.org/json?lat=59.436962&lng=24.753574&date=today"; //Tallinna pikkuse-laiuse koordinaadid on siin sees
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(categoryUrl);
			request.Method = "GET";
			
			var webResponce = request.GetResponse();
			var webStream = webResponce.GetResponseStream();

			using (var responceReader = new StreamReader(webStream))
			{

				var responce = responceReader.ReadToEnd();
				SunMode sunMode = JsonConvert.DeserializeObject<SunMode>(responce); //võtab stringi ja vaatab mis prop on seal kirjeldatud, loeb selle stringi maha ja hakkab salvestama

				Console.WriteLine(sunMode.Status);
				Console.WriteLine($"Sunrise: {sunMode.Results.Sunrise}");
				Console.WriteLine($"Sunset: {sunMode.Results.Sunset}");
			}
			Console.ReadLine();
		}
	}
}
