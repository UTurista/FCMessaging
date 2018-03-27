using Newtonsoft.Json;
using System.Collections.Generic;

namespace UTurista.FCMessaging
{
  public class ApsAlertConfig
  {
    [JsonProperty("title")]
    public string Title { get; internal set; }

    [JsonProperty("body")]
    public string Body { get; internal set; }

    [JsonProperty("title-loc-key")]
    public string TitleLocationKey { get; internal set; }

    [JsonProperty("title-loc-args")]
    public string[] TitleLocationArgs { get; internal set; }

    [JsonProperty("action-loc-key")]
    public string ActionLocationKey { get; internal set; }

    [JsonProperty("loc-key")]
    public string LocationKey { get; internal set; }

    [JsonProperty("loc-args")]
    public string[] LocationArgs { get; internal set; }

    [JsonProperty("launch-image")]
    public string LaunchImage { get; internal set; }

    internal ApsAlertConfig() { }

    public class Builder
    {
      ApsAlertConfig config = new ApsAlertConfig();

      public Builder Title(string title)
      {
        config.Title = title;
        return this;
      }
      public Builder Body(string body)
      {
        config.Body = body;
        return this;
      }
      public Builder TitleLocationKey(string titleLocationKey)
      {
        config.TitleLocationKey = titleLocationKey;
        return this;
      }
      public Builder TitleLocationArgs(string[] titleLocationArgs)
      {
        config.TitleLocationArgs = titleLocationArgs;
        return this;
      }
      public Builder ActionLocationKey(string actionLocationKey)
      {
        config.ActionLocationKey = actionLocationKey;
        return this;
      }
      public Builder LocationKey(string locationKey)
      {
        config.LocationKey = locationKey;
        return this;
      }
      public Builder LocationArgs(string[] locationArgs)
      {
        config.LocationArgs = locationArgs;
        return this;
      }
      public Builder LaunchImage(string launchImage)
      {
        config.LaunchImage = launchImage;
        return this;
      }

      public ApsAlertConfig Build()
      {
        return config;
      }
    }
  }
}