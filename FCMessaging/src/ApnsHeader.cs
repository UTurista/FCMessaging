using Newtonsoft.Json;
using System.Collections.Generic;

namespace UTurista.FCMessaging
{
  public class ApnsHeader
  {
    // https://developer.apple.com/library/content/documentation/NetworkingInternet/Conceptual/RemoteNotificationsPG/CommunicatingwithAPNs.html#//apple_ref/doc/uid/TP40008194-CH11-SW1

    [JsonProperty("authorization")]
    public string Authorization { get; internal set; }

    [JsonProperty("apns-id")]
    public string Id { get; internal set; }

    [JsonProperty("apns-expiration")]
    public string Expiration { get; internal set; }

    [JsonProperty("apns-priority")]
    public string Priority { get; internal set; }

    [JsonProperty("apns-topic")]
    public string Topic { get; internal set; }

    [JsonProperty("apns-collapse-id")]
    public string CollapseId { get; internal set; }

    internal ApnsHeader() { }

    public class Builder
    {
      ApnsHeader config = new ApnsHeader();

      public Builder Authorization(string authorization)
      {
        config.Authorization = authorization;
        return this;
      }
      public Builder Id(string id)
      {
        config.Id = id;
        return this;
      }
      public Builder Expiration(string expiration)
      {
        config.Expiration = expiration;
        return this;
      }
      public Builder Priority(string priority)
      {
        config.Priority = priority;
        return this;
      }
      public Builder Topic(string topic)
      {
        config.Topic = topic;
        return this;
      }
      public Builder CollapseId(string collapseId)
      {
        config.CollapseId = collapseId;
        return this;
      }

      public ApnsHeader Build()
      {
        return config;
      }
    }
  }
}