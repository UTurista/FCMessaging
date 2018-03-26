using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using UTurista.FCMessaging;

namespace FCMessagingTests
{
  [TestClass]
  public class ApnsPayloadConfigTests
  {
    static readonly JsonSerializerSettings JSON_SETTINGS = new JsonSerializerSettings
    {
      NullValueHandling = NullValueHandling.Ignore
    };

    [TestMethod]
    public void SerializationTest_Alert()
    {
      var config = new ApnsPayload.Builder().ApsConfig(new ApsConfig.Builder().Build()).Build();
      var test = "{\"aps\":{\"badge\":0,\"sound\":\"default\"},\"data\":{}}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_Data()
    {
      var config = new ApnsPayload.Builder().AddData("foo", "bar").Build();
      var test = "{\"data\":{\"foo\":\"bar\"}}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }
  }
}