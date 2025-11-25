using Avalonia.Controls.Converters;
using RestPunk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RestPunk
{
    public class PunkHttpClient : HttpClient
    {
        public async Task<string> SendRequestAsync(SavedQuery query)
        {
            return await SendRequestAsync(query.HttpVerb, query.Uri, query.Body?.Body, query.Params?.Params, query.Headers?.Headers);
        }
        public async Task<string> SendRequestAsync(string verb, string url, string body, List<Parameter> queryParams, List<Header> headers)
        {
            var returnValue = string.Empty;

            using var client = new HttpClient();

            // Build the URL with query parameters
            var builder = new UriBuilder(url);
            if (queryParams != null && queryParams.Any())
            {
                var query = HttpUtility.ParseQueryString(builder.Query);
                foreach (var param in queryParams)
                {
                    query[param.Key] = param.Value;
                }
                builder.Query = query.ToString();
            }
            var method = HttpMethod.Get;
            switch (verb)
            {
                case VerbType.PostConst:
                    method = HttpMethod.Post;
                    break;
                case VerbType.PutConst:
                    method = HttpMethod.Put;
                    break;
                case VerbType.PatchConst:
                    method = HttpMethod.Patch;
                    break;
                case VerbType.DeleteConst:
                    method = HttpMethod.Delete;
                    break;
                case VerbType.HeadConst:
                    method = HttpMethod.Head;
                    break;
                case VerbType.OptionsConst:
                    method = HttpMethod.Options;
                    break;
                case VerbType.TraceConst:
                    method = HttpMethod.Trace;
                    break;
                case VerbType.GetConst:
                default:
                    method = HttpMethod.Get;
                    break;
            }

            // Create the request
            // TODO: Allow for Encoding and Media Type
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = builder.Uri,
                Content = new StringContent(body, Encoding.UTF8, "application/json")
            };

            // Add headers
            if (headers != null && headers.Any())
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            // Send
            HttpResponseMessage response = await client.SendAsync(request);

            string responseBody = response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : string.Empty;

            if (response.IsSuccessStatusCode)
            {
                // Read response
                return responseBody;
            }

            return $"Error: {response.StatusCode} - {responseBody}";
        }
    }
}
