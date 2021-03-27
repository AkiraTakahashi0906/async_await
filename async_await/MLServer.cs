using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace async_await
{
    internal class MLServer : IMlRepository
    {
        static HttpClient client = new HttpClient();

        //python
        //return jsonify([{"language":"太郎1","language2":"M"},{"language":"太郎2","language2":"M"}])

        static async Task<List<MlEntity>> GetProductAsync(string path)
        {
            List<MlEntity> product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<List<MlEntity>>();
            }
            System.Threading.Thread.Sleep(3000);
            return product;
        }

        public async Task<List<MlEntity>> GetML(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            using (client = new HttpClient())
            {
                // Update port # in the following line.
                client.BaseAddress = new Uri("http://127.0.0.1:8888/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                List<MlEntity> tmp = null;

                try
                {
                    // Get the product
                    var product = await GetProductAsync("http://127.0.0.1:8888/");
                    tmp = product;
                    Console.WriteLine(product[0].language);
                    Console.WriteLine(product[1].language);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //Console.ReadLine();
                return tmp;
            }
        }
    }
}
