using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sandbox
{
    class RestRequester
    {
        // A static client is the most efficient thing to use for multiple calls. If you decide to make this not static, there are
        // other things you need to do for your code to work well, as this class implements IDisposable. We'll talk about that some
        // other time.
        private static HttpClient _client = new HttpClient();

        public void MakeRequests()
        {
            Console.WriteLine("Making web requests. Please wait.");

            // LOOK AT THESE IN ORDER!!!! You will confuse yourself otherwise.
            Task createUserTask = CreateUserAsync(); 
            Task getUserTask = GetUserAsync();
            Task<string[]> getArtifactsTask = GetMtgArtifactTypesAsync();

            Task.WaitAll(createUserTask, getUserTask, getArtifactsTask); // Wait for all async tasks to finish before proceeding.
            Console.WriteLine("All web requests complete.");
        }

        // https://reqres.in/
        // ^^^^ THIS SITE IS AMAZING FOR TESTING YOUR REST REQUESTS!!!! It's basically a realistic fake back-end server
        // that has all sorts of requests it supports, and will give you realistic responses. It doesn't store any data though,
        // so if you "create" a user, it's not going to remember that user.

        private async Task CreateUserAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://reqres.in/api/users");

            // Add post "body" JSON. This allows us to add additional information to our request.
            // For this request, the API wants us to pass up a "name" and a "job":
            //
            // {
            //     "name": "morpheus",
            //     "job": "leader"
            // }
            // 
            // I've taken the liberty of adding the Newtonsoft.JSON library to this project, since
            // it's the #1 go-to library for C# JSON stuff.

            // Here's how you would create JSON that looks like the block above using Newtonsoft.JSON:
            Dictionary<string, string> body = new Dictionary<string, string>();
            body.Add("name", "morpheus");
            body.Add("job", "leader");

            string requestBodyJson = JsonConvert.SerializeObject(body); // You could easily inline this on the next line. I just separated it out for clarity.

            // This isn't limited to dictionaries, btw. You can serialize pretty much ANYTHING, and it automatically knows
            // how to do it. It's magical. Like we could pass in an instance of a custom class and it would know how to
            // serialize that just fine. You can see an example of that with the GetMtgArtifactTypes() request below.

            request.Content = new StringContent(requestBodyJson, Encoding.UTF8, "application/json");

            await MakeRequestAsync(request);
        }

        private async Task GetUserAsync()
        {
            int userId = 2;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://reqres.in/api/users/{userId}");
            // No content or "body" for this request, since it's a GET.

            await MakeRequestAsync(request);
        }

        private async Task MakeRequestAsync(HttpRequestMessage request) // async keyword means that this method will run asynchronously IF AND ONLY IF the "await" keyword is also used in it. 
        {   
            HttpResponseMessage response = await _client.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();

            StringBuilder sb = new StringBuilder();  // This is a cute way to make large strings.
            sb.AppendLine("******");
            sb.AppendLine($"* REQUEST {request.RequestUri}");
            sb.AppendLine("* -------");
            sb.AppendLine($"* STATUS CODE: {(int)response.StatusCode} ({response.StatusCode})");
            sb.AppendLine($"* RESPONSE BODY: {responseBody}");
            sb.AppendLine("******");

            // Why wouldn't I just do multiple Console.WriteLine statements, you might ask?
            // Because this method is being run asynchronously, it's possible that this method is also being called
            // for a different request on another thread. Because of that, if I had multiple print statements, they
            // could become interleaved, like:
            // *****
            // REQUEST: https://reqres.in/api/users/2
            // ----
            // REQUEST: https://reqres.in/api/users
            // STATUS CODE: 200 (OK)
            // STATUS CODE: 201 (Created)
            // -----
            Console.WriteLine(sb.ToString());
        }

        // What if you want to get fancy and parse the response from the server into an object that's
        // a little easier to manage than a big jumbled string of JSON? Newtonsoft.JSON to the rescue!
        private async Task<string[]> GetMtgArtifactTypesAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://api.scryfall.com/catalog/artifact-types");
            // No content or "body" for this request, since it's a GET.

            HttpResponseMessage response = await _client.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();

            // Try parsing the response body into our custom class!
            ScryfallCatalogResponse responseObj = JsonConvert.DeserializeObject<ScryfallCatalogResponse>(responseBody);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("******");
            sb.AppendLine($"* REQUEST {request.RequestUri}");
            sb.AppendLine("* -------");
            sb.AppendLine($"* STATUS CODE: {(int)response.StatusCode} ({response.StatusCode})");
            sb.Append("* ARTIFACT TYPES: [");
            for (int i = 0; i < responseObj.Data.Length; i++)
            {
                sb.Append(responseObj.Data[i]);
                if (i < responseObj.Data.Length - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.AppendLine("]");
            sb.AppendLine("******");

            Console.WriteLine(sb.ToString());

            return responseObj.Data;
        }

        private class ScryfallCatalogResponse
        {
            // If you look at Scryfall's "catalog" endpoints, their responses are all formatted the same way: https://scryfall.com/docs/api/catalogs/spell-types
            // That means we can make an object that should map to any of those responses just fine.
            // EX: {"object":"catalog","uri":"https://api.scryfall.com/catalog/spell-types","total_values":4,"data":["Adventure","Arcane","Lesson","Trap"]}
            // Try making your own call to one of the other catalog endpoints (like the one that returns all enchantment types or spell types) and parsing the response into this class!

            public string Object;
            
            public string Uri;

            [JsonProperty("total_values")] // This tells it that it should look for the specified string rather than relying on the var name. Didn't want to put an underscore in our var name lol
            public int TotalValues;
            
            public string[] Data;
        }
    }
}
