using Newtonsoft.Json;
using System.Collections.Generic;

namespace UTurista.FCMessaging
{
  public class ApnsConfig
  {
    // See: https://developer.apple.com/library/content/documentation/NetworkingInternet/Conceptual/RemoteNotificationsPG/CommunicatingwithAPNs.html#//apple_ref/doc/uid/TP40008194-CH11-SW1
    [JsonProperty("headers")]
    public ApnsHeader Headers { get; internal set; }

    // See: https://developer.apple.com/library/content/documentation/NetworkingInternet/Conceptual/RemoteNotificationsPG/PayloadKeyReference.html#//apple_ref/doc/uid/TP40008194-CH17-SW1
    [JsonProperty("payload")]
    public ApnsPayload Payload { get; internal set; }

    internal ApnsConfig() { }

    public class Builder
    {
      ApnsConfig config = new ApnsConfig();

      public ApnsConfig Build()
      {
        return config;
      }

      public Builder Headers(ApnsHeader headers)
      {
        config.Headers = headers;
        return this;
      }

      public Builder Payload(ApnsPayload payload)
      {
        config.Payload = payload;
        return this;
      }
    }
  }
}
