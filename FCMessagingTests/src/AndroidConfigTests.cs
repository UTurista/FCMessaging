using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UTurista.FCMessaging;

namespace FCMessagingTests.src
{
    [TestClass]
    public class AndroidConfigTests
    {
        static readonly JsonSerializerSettings JSON_SETTINGS = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };


        [TestMethod]
        public void SerializationTest_CollapsedKey()
        {
            AndroidConfig cnfg = new AndroidConfig.Builder().CollapsedKey("aCollapsedKey").Build();

            string json = JsonConvert.SerializeObject(cnfg, JSON_SETTINGS);

            Assert.AreEqual("{\"collapse_key\":\"aCollapsedKey\"}", json);
        }

        [TestMethod]
        public void SerializationTest_Priority()
        {
            // Testing HIGH Priority
            {
                AndroidConfig cnfg = new AndroidConfig.Builder().Priority(AndroidMessagePriority.HIGH).Build();
                string json = JsonConvert.SerializeObject(cnfg, JSON_SETTINGS);

                Assert.AreEqual("{\"priority\":\"high\"}", json);
            }

            // Testing Normal Priority
            {
                AndroidConfig cnfg = new AndroidConfig.Builder().Priority(AndroidMessagePriority.NORMAL).Build();
                string json = JsonConvert.SerializeObject(cnfg, JSON_SETTINGS);

                Assert.AreEqual("{\"priority\":\"normal\"}", json);
            }
        }

        [TestMethod]
        public void SerializationTest_TimeToLive()
        {
            AndroidConfig cnfg = new AndroidConfig.Builder().TimeToLive(TimeSpan.FromHours(3)).Build();
            string json = JsonConvert.SerializeObject(cnfg, JSON_SETTINGS);

            Assert.AreEqual("{\"ttl\":\"10800s\"}", json);
        }

        [TestMethod]
        public void SerializationTest_TimeToLive_MaxValue()
        {
            AndroidConfig cnfg = new AndroidConfig.Builder().TimeToLive(TimeSpan.FromDays(30)).Build();
            string json = JsonConvert.SerializeObject(cnfg, JSON_SETTINGS);

            Assert.AreEqual("{\"ttl\":\"2419200s\"}", json);
        }

        [TestMethod]
        public void SerializationTest_PackageName()
        {
            AndroidConfig cnfg = new AndroidConfig.Builder().Package("aPackage").Build();
            string json = JsonConvert.SerializeObject(cnfg, JSON_SETTINGS);

            Assert.AreEqual("{\"restricted_package_name\":\"aPackage\"}", json);
        }


        [TestMethod]
        public void SerializationTest_Data()
        {
            AndroidConfig cnfg = new AndroidConfig.Builder().AddData("aKey", "aValue").Build();
            string json = JsonConvert.SerializeObject(cnfg, JSON_SETTINGS);

            Assert.AreEqual("{\"data\":{\"aKey\":\"aValue\"}}", json);
        }

        [TestMethod]
        public void SerializationTest_Data_MultipleEntries()
        {
            AndroidConfig cnfg = new AndroidConfig.Builder().AddData("aKey", "aValue").AddData("aSecondKey", "aSecondValue").Build();
            string json = JsonConvert.SerializeObject(cnfg, JSON_SETTINGS);

            Assert.AreEqual("{\"data\":{\"aKey\":\"aValue\",\"aSecondKey\":\"aSecondValue\"}}", json);
        }

        [TestMethod]
        public void SerializationTest_Notification()
        {
            AndroidNotification notification = new AndroidNotification.Builder().Build();
            AndroidConfig cnfg = new AndroidConfig.Builder().Notification(notification).Build();
            string json = JsonConvert.SerializeObject(cnfg, JSON_SETTINGS);

            Assert.AreEqual("{\"notification\":{}}", json);
        }
    }
}
