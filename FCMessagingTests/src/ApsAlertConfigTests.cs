using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using UTurista.FCMessaging;

namespace FCMessagingTests
{
  [TestClass]
  public class ApsAlertConfigTests
  {
    static readonly JsonSerializerSettings JSON_SETTINGS = new JsonSerializerSettings
    {
      NullValueHandling = NullValueHandling.Ignore
    };

    [TestMethod]
    public void SerializationTest_Title()
    {
      var config = new ApsAlertConfig.Builder().Title("foo").Build();
      var test = "{\"title\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_Body()
    {
      var config = new ApsAlertConfig.Builder().Body("foo").Build();
      var test = "{\"body\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_TitleLocationKey()
    {
      var config = new ApsAlertConfig.Builder().TitleLocationKey("foo").Build();
      var test = "{\"title-loc-key\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_TitleLocationArgs()
    {
      var config = new ApsAlertConfig.Builder().TitleLocationArgs(new string[] { "foo" }).Build();
      var test = "{\"title-loc-args\":[\"foo\"]}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_ActionLocationKey()
    {
      var config = new ApsAlertConfig.Builder().ActionLocationKey("foo").Build();
      var test = "{\"action-loc-key\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_LocationKey()
    {
      var config = new ApsAlertConfig.Builder().LocationKey("foo").Build();
      var test = "{\"loc-key\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_LocationArgs()
    {
      var config = new ApsAlertConfig.Builder().LocationArgs(new string[] { "foo" }).Build();
      var test = "{\"loc-args\":[\"foo\"]}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_LaunchImage()
    {
      var config = new ApsAlertConfig.Builder().LaunchImage("foo").Build();
      var test = "{\"launch-image\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }
  }
}