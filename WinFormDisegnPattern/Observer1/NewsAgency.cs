using System.Text;
using System;

namespace WinFormDisegnPattern.Observer1
{
    public class NewsAgency : IObserver
    {

        public string AgencyName { get; set; }

        public NewsAgency(string agencyname) {
            AgencyName = agencyname;
        }

        public void Update(ISubject subject)
        {
            StringBuilder sb = new StringBuilder();

            if (subject is WeatherStation w) 
            {
                sb.AppendLine(AgencyName);
                sb.AppendLine(w.Temperature.ToString());
            }
            sb.AppendLine("News Agency");

            Console.Write(sb.ToString());
        }
    }
}
