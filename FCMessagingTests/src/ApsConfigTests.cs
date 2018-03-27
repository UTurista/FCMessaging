using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using UTurista.FCMessaging;

namespace FCMessagingTests
{
  [TestClass]
  public class ApsConfigTests
  {
    static readonly JsonSerializerSettings JSON_SETTINGS = new JsonSerializerSettings
    {
      NullValueHandling = NullValueHandling.Ignore
    };

    [TestMethod]
    public void SerializationTest_Alert()
    {
      var config = new ApsConfig.Builder().Alert(new ApsAlertConfig.Builder().Title("foo").Build()).Build();
      var test = "{\"alert\":{\"title\":\"foo\"},\"badge\":0,\"sound\":\"default\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_Badge()
    {
      var config = new ApsConfig.Builder().Badge(1).Build();
      var test = "{\"badge\":1,\"sound\":\"default\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_Sound()
    {
      var config = new ApsConfig.Builder().Sound("red_alert").Build();
      var test = "{\"badge\":0,\"sound\":\"red_alert\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_IsContentAvailable()
    {
      var config = new ApsConfig.Builder().IsContentAvailable(true).Build();
      var test = "{\"content-available\":1,\"badge\":0,\"sound\":\"default\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_Category()
    {
      var config = new ApsConfig.Builder().Category("foo").Build();
      var test = "{\"badge\":0,\"sound\":\"default\",\"category\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_ThreadId()
    {
      var config = new ApsConfig.Builder().ThreadId("foo").Build();
      var test = "{\"badge\":0,\"sound\":\"default\",\"thread-id\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }
  }
}