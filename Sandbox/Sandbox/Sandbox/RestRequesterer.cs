using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Sandbox
{
	class RestRequesterer
	{
		private static HttpClient _client = new HttpClient();
		private static TaskFactory _taskFactory = new TaskFactory();

		public void GetCreatureTypes()
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://api.scryfall.com/catalog/creature-types");

			Action getCreatureTypesRquest = async () =>
			{
				HttpResponseMessage response = await _client.SendAsync(request);

				string responseBody = await response.Content.ReadAsStringAsync();

				RestRequester.ScryfallCatalogResponse responseObj = JsonConvert.DeserializeObject<RestRequester.ScryfallCatalogResponse>(responseBody);

				StringBuilder sb = new StringBuilder();

				sb.AppendLine($" REQUEST MADE TO: {request.RequestUri}");
				sb.AppendLine("");
				sb.AppendLine(" ~(^_^)~~(^_^)~~(^_^)~");
				sb.AppendLine("");
				sb.AppendLine($" HOW'S IT GOING?: {(int)response.StatusCode} ({response.StatusCode})");
				sb.AppendLine("");
				sb.Append(" THESE BE CREATURES: [");

				for (int i = 0; i < responseObj.Data.Length; i++)
				{
					if (i % 10 == 0)
                    {
						sb.AppendLine("");
                    }

					sb.Append(responseObj.Data[i]);
					if (i < responseObj.Data.Length - 1)
					{
						sb.Append(", ");
					}
				}

				sb.AppendLine("]");
				sb.AppendLine("");
				sb.AppendLine(" (^_^)/(^_^)/(^_^)/");

				Console.WriteLine(sb.ToString());
			};

			_taskFactory.StartNew(getCreatureTypesRquest);
		}
	}
}
