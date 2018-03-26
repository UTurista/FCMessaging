using Newtonsoft.Json;
using System.Collections.Generic;

namespace UTurista.FCMessaging
{
  public class ApsConfig
  {
    [JsonProperty("alert")]
    public ApsAlertConfig Alert { get; internal set; }

    [JsonProperty("badge")]
    public int Badge { get; internal set; }

    [JsonProperty("sound")]
    public string Sound { get; internal set; } = "default";

    [JsonProperty("content-available")]
    public int? isContentAvailable = null;

    [JsonIgnore]
    public bool? IsContentAvailable
    {
      get
      {
        if (isContentAvailable.HasValue) return Convert.ToBoolean(isContentAvailable.Value);
        else return false;
      }
      internal set
      {
        isContentAvailable = Convert.ToInt32(value);
      }
    }

    [JsonProperty("category")]
    public string Category { get; internal set; }

    [JsonProperty("thread-id")]
    public string ThreadId { get; internal set; }

    internal ApsConfig() { }

    public class Builder
    {
      ApsConfig config = new ApsConfig();

      public Builder Alert(ApsAlertConfig alert)
      {
        config.Alert = alert;
        return this;
      }
      public Builder Badge(int badge)
      {
        config.Badge = badge;
        return this;
      }
      public Builder Sound(string sound)
      {
        config.Sound = sound;
        return this;
      }
      public Builder IsContentAvailable(bool isContentAvailable)
      {
        config.IsContentAvailable = isContentAvailable;
        return this;
      }
      public Builder Category(string category)
      {
        config.Category = category;
        return this;
      }
      public Builder ThreadId(string threadId)
      {
        config.ThreadId = threadId;
        return this;
      }

      public ApsConfig Build()
      {
        return config;
      }
    }
  }
}