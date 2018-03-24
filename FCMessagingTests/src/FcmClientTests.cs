using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UTurista.FCMessaging;

namespace FCMessagingTests.src
{
    [TestClass]
    public class FcmClientTests
    {

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException),
            "FCMClient must throw error if credential files is inexistente")]
        public void LoadWrongCredentials_NoArguments()
        {
            FCMClient client = new FCMClient();
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException),
            "FCMClient must throw error if credential files is inexistente")]
        public void LoadWrongCredentials_BadArguments()
        {
            FCMClient client = new FCMClient("a_bad_file.json");
        }

        [TestMethod]
        public void LoadCorrectCredentials()
        {
            FCMClient client = new FCMClient("credentials.json");
        }


        [TestMethod]
        public void SimpleSend()
        {
            FCMClient client = new FCMClient("credentials.json");

            var message = new Message
                .Builder()
                .Title("")
                .ToTopic("aTopic")
                .Build();

            // Lets send it
            string id = client.Send(message, true).GetAwaiter().GetResult();

            Assert.IsNotNull(id);
        }
    }
}
