using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using UTurista.FCMessaging;

namespace FCMessagingTests
{
    [TestClass]
    public class AndroidNotificationsTests
    {

        [TestMethod]
        public void ColorTest()
        {
            // Even if Color has a ToString() that gives the '#RRGGBB'
            // that we want, this gives more control 
            Tuple<Color, string>[] colorTests = new Tuple<Color, string>[]
            {
                new Tuple<Color, string>(Color.Red, "#FF0000"),
                new Tuple<Color, string>(Color.Lime, "#00FF00"),
                new Tuple<Color, string>(Color.Blue, "#0000FF"),
                new Tuple<Color, string>(Color.Black, "#000000"),
                new Tuple<Color, string>(Color.White, "#FFFFFF"),
                new Tuple<Color, string>(Color.Coral, "#FF7F50")
            };

            foreach (var color in colorTests)
            {
                AndroidNotification notification = new AndroidNotification.Builder().Color(color.Item1).Build();

                Assert.AreEqual(color.Item2, notification.Color);
            }


        }
    }
}
