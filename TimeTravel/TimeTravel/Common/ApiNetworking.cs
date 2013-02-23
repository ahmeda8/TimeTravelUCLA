using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace TimeTravel.Common
{
    class ApiNetworking
    {
        string url;

        ApiNetworking(string getUrl)
        {
            this.url = getUrl;
        }

        public async Task<string> Fetch()
        {
            try
            {
                HttpClient HC = new HttpClient();
                HttpRequestMessage HRM = new HttpRequestMessage();
                HRM.Method = new HttpMethod("GET");
                HRM.RequestUri = new Uri(this.url);
                var response = await HC.SendAsync(HRM);
                var RespText = await response.Content.ReadAsStringAsync();
                return RespText;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
