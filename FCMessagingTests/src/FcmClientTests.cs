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
            FcmClient client = new FcmClient();
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException),
            "FCMClient must throw error if credential files is inexistente")]
        public void LoadWrongCredentials_BadArguments()
        {
            FcmClient client = new FcmClient("a_bad_file.json");
        }

        [TestMethod]
        public void LoadCorrectCredentials()
        {
            FcmClient client = new FcmClient("credentials.json");
        }


        [TestMethod]
        public void SimpleSend()
        {
            FcmClient client = new FcmClient("credentials.json");

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
