using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using UTurista.FCMessaging;

namespace FCMessagingTests
{
  [TestClass]
  public class ApnsConfigTests
  {
    static readonly JsonSerializerSettings JSON_SETTINGS = new JsonSerializerSettings
    {
      NullValueHandling = NullValueHandling.Ignore
    };

    [TestMethod]
    public void SerializationTest_Headers()
    {
      var config = new ApnsConfig.Builder().Headers(new ApnsHeader.Builder().Build()).Build();
      var test = "{\"headers\":{}}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_Payload()
    {
      var config = new ApnsConfig.Builder().Payload(new ApnsPayload.Builder().Build()).Build();
      var test = "{\"payload\":{\"data\":{}}}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

  }
}