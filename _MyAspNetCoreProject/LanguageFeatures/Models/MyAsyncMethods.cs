using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        //Actual Code in use Async calling ContinueWith
        public static Task<long?> TraditionalGetPageLength()
        {
            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> httpTask = httpClient.GetAsync("http://apress.com");
            //return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
            //{
            //    return antecedent.Result.Content.Headers.ContentLength;
            //});
            return httpTask.ContinueWith(e => e.Result.Content.Headers.ContentLength);
        }

        public async static Task<long?> SimplifyGetPageLength()
        {
            HttpClient httpClient = new HttpClient();
            var httpMessage = await httpClient.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;
        }

        public async static IAsyncEnumerable<long?> GetPageLength(List<String> outputs, params string[] urls)
        {
            HttpClient httpClient = new HttpClient();
            foreach (String url in urls)
            {
                outputs.Add($"Started request for {url}");
                var httpMessage = await httpClient.GetAsync($"http://{url}");
                outputs.Add($"Completed request for {url}");
                yield return httpMessage.Content.Headers.ContentLength;
            }
        }
    }
}
