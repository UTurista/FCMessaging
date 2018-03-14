using Newtonsoft.Json;
using System.Collections.Generic;

namespace UTurista.FCMessaging
{
    public class ApnsConfig
    {
        // See: https://developer.apple.com/library/content/documentation/NetworkingInternet/Conceptual/RemoteNotificationsPG/CommunicatingwithAPNs.html#//apple_ref/doc/uid/TP40008194-CH11-SW1
        [JsonProperty("headers")]
        public Dictionary<string, string> headers { get; internal set; }

        // See: https://developer.apple.com/library/content/documentation/NetworkingInternet/Conceptual/RemoteNotificationsPG/PayloadKeyReference.html#//apple_ref/doc/uid/TP40008194-CH17-SW1
        [JsonProperty("payload")]
        public Dictionary<string, object> payload { get; internal set; }
    }
}
