using RestSharp;

namespace DnDCharacterManager.Util
{
    public static class RestSharpHelper
    {
        public static RestClient GetClient(string url)
        {
            var client = new RestClient(Constants.Urls.DND_BEYOND_CHARACTER_SERVICE);
            client.AddHandler("application/json", () => new JsonNetSerializer());
            client.AddHandler("text/json", () => new JsonNetSerializer());
            client.AddHandler("text/x-json", () => new JsonNetSerializer());
            client.AddHandler("text/javascript", () => new JsonNetSerializer());
            client.AddHandler("*+json", () => new JsonNetSerializer());
            return client;
        }
    }
}
