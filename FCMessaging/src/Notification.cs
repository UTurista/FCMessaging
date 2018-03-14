using Newtonsoft.Json;

namespace UTurista.FCMessaging
{
    public class Notification
    {
        [JsonProperty("title")]
        public string Title { get; private set; }

        [JsonProperty("body")]
        public string Body { get; private set; }


        public Notification(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}
