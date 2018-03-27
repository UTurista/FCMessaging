using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using UTurista.FCMessaging;

namespace FCMessagingTests
{
  [TestClass]
  public class ApnsHeaderConfigTests
  {
    static readonly JsonSerializerSettings JSON_SETTINGS = new JsonSerializerSettings
    {
      NullValueHandling = NullValueHandling.Ignore
    };

    [TestMethod]
    public void SerializationTest_Authorization()
    {
      var config = new ApnsHeader.Builder().Authorization("foo").Build();
      var test = "{\"authorization\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_Id()
    {
      var config = new ApnsHeader.Builder().Id("foo").Build();
      var test = "{\"apns-id\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_Expiration()
    {
      var config = new ApnsHeader.Builder().Expiration("foo").Build();
      var test = "{\"apns-expiration\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_Priority()
    {
      var config = new ApnsHeader.Builder().Priority("foo").Build();
      var test = "{\"apns-priority\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_Topic()
    {
      var config = new ApnsHeader.Builder().Topic("foo").Build();
      var test = "{\"apns-topic\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }

    [TestMethod]
    public void SerializationTest_CollapseId()
    {
      var config = new ApnsHeader.Builder().CollapseId("foo").Build();
      var test = "{\"apns-collapse-id\":\"foo\"}";
      var actual = JsonConvert.SerializeObject(config, JSON_SETTINGS);

      Assert.AreEqual(test, actual);
    }
  }
}