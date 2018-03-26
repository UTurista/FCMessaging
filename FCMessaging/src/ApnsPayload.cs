using Newtonsoft.Json;
using System.Collections.Generic;

namespace UTurista.FCMessaging
{
  public class ApnsPayload
  {
    // https://developer.apple.com/library/content/documentation/NetworkingInternet/Conceptual/RemoteNotificationsPG/PayloadKeyReference.html#//apple_ref/doc/uid/TP40008194-CH17-SW1

    [JsonProperty("aps")]
    public ApsConfig ApsConfig { get; set; }

    [JsonProperty("data")]
    public Dictionary<string, object> Data { get; internal set; } = new Dictionary<string, object>();

    internal ApnsPayload() { }

    public class Builder
    {
      ApnsPayload config = new ApnsPayload();

      public Builder ApsConfig(ApsConfig apsConfig)
      {
        config.ApsConfig = apsConfig;
        return this;
      }

      public Builder AddData(string key, object value)
      {
        config.Data.Add(key, value);
        return this;
      }

      public ApnsPayload Build()
      {
        return config;
      }
    }
  }
}