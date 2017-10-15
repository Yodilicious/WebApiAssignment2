namespace Assignment2Music.Client.Helper
{
    using Newtonsoft.Json;
    using RestSharp;

    public static class RestClientHelper
    {
        public static string GetRequest(string resource)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest();

            request.Method = Method.GET;
            request.Resource = resource;

            IRestResponse response = client.Execute(request);

            dynamic parsedJson = JsonConvert.DeserializeObject(response.Content);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        public static string PostRequest(string resource, object body)
        {
            return RestRequest(resource, body, Method.POST);
        }

        public static string PutRequest(string resource, object body)
        {
            return RestRequest(resource, body, Method.PUT);
        }

        private static string RestRequest(string resource, object body, Method method)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest();

            request.Method = method;
            request.RequestFormat = DataFormat.Json;
            request.AddBody(body);

            request.Resource = resource;

            IRestResponse response = client.Execute(request);

            dynamic parsedJson = JsonConvert.DeserializeObject(response.Content);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        public static string DeleteRequest(string resource)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest();

            request.Method = Method.DELETE;
            request.Resource = resource;

            IRestResponse response = client.Execute(request);

            dynamic parsedJson = JsonConvert.DeserializeObject(response.Content);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        private static string baseUrl = "http://localhost:56119/api";
    }
}
