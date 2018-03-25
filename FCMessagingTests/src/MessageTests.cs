using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UTurista.FCMessaging;

namespace FCMessagingTests
{
    [TestClass]
    public class MessageTests
    {

        #region "Multiple Targets"
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Builder allowed setting topic AND device target inappropriately")]
        public void PreventMultipleTargets_TopicDevice()
        {
            // A message may only have 1 of 3 targets (topic, device, condition)
            // Setting more than one target should throw an exception
            Message message = new Message
                .Builder()
                .ToTopic("aTopic")
                .ToDevice("aDevice")
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Builder allowed setting topic AND condition target inappropriately")]
        public void PreventMultipleTargets_TopicCondition()
        {
            // A message may only have 1 of 3 targets(topic, device, condition)
            // Setting more than one target should throw an exception
            Message message = new Message
                .Builder()
                .ToTopic("aTopic")
                .ToCondition("aCondition")
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Builder allowed setting device AND condition target inappropriately")]
        public void PreventMultipleTargets_ConditionDevice()
        {
            // A message may only have 1 of 3 targets(topic, device, condition)
            // Setting more than one target should throw an exception
            Message message = new Message
                .Builder()
                .ToDevice("aDevice")
                .ToCondition("aCondition")
                .Build();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Builder allowed setting device AND condition AND topic target inappropriately")]
        public void PreventMultipleTargets_TopicDeviceCondition()
        {
            // A message may only have 1 of 3 targets(topic, device, condition)
            // Setting more than one target should throw an exception
            Message message = new Message
                .Builder()
                .ToTopic("aTopic")
                .ToDevice("aDevice")
                .ToCondition("aCondition")
                .Build();
        }
        #endregion


        #region "Single Targets"



        #endregion
    }
}
