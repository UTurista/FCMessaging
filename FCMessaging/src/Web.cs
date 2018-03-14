using Newtonsoft.Json;
using System.Collections.Generic;

namespace UTurista.FCMessaging
{
    public class WebpushConfig
    {
        [JsonProperty("headers")]
        public Dictionary<string, string> headers { get; internal set; }

        [JsonProperty("data")]
        public Dictionary<string, string> data { get; internal set; }

        [JsonProperty("notification")]
        public WebpushNotification notification { get; internal set; }
    }


    public class WebpushNotification
    {
        [JsonProperty("title")]
        public string title { get; internal set; }

        [JsonProperty("body")]
        public string body { get; internal set; }

        [JsonProperty("icon")]
        public string icon { get; internal set; }
    }
}
