using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZData.LoanCalculator.Client.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient c, string address, List<(string header, string value)> headers = null)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, c.BaseAddress + address))
            {
                if (headers != null)
                {
                    foreach (var (header, value) in headers)
                    {
                        request.Headers.Add(header, value);
                    }
                }
                var response = await c.SendAsync(request);
                var resContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(resContent);
            }
        }


        public static async Task<T> PostJsonAsync<T>(this HttpClient c, string address, object body, List<(string header, string value)> headers = null)
        {
            var serObj = JsonConvert.SerializeObject(body);
            using (var content = new StringContent(serObj, Encoding.UTF8, "application/json"))
            {
                if (headers != null)
                {
                    foreach (var (header, value) in headers)
                    {
                        content.Headers.Add(header, value);
                    }
                }
                var response = await c.PostAsync(address, content);
                var resContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(resContent);
            }
        }

    }
}
