using Newtonsoft.Json;
using System.Drawing;

namespace UTurista.FCMessaging
{

    public class AndroidNotification
    {
        [JsonProperty("title")]
        public string Title { get; internal set; }

        [JsonProperty("body")]
        public string Body { get; internal set; }

        [JsonProperty("icon")]
        public string Icon { get; internal set; }

        [JsonProperty("color")]
        public string Color { get; internal set; }

        [JsonProperty("sound")]
        public string Sound { get; internal set; }

        [JsonProperty("tag")]
        public string Tag { get; internal set; }

        [JsonProperty("click_action")]
        public string Action { get; internal set; }

        [JsonProperty("body_loc_key")]
        public string LocalizedBody { get; internal set; }

        [JsonProperty("body_loc_args")]
        public string[] LocalizedBodyArgs { get; internal set; }

        [JsonProperty("title_loc_key")]
        public string LocalizedTitle { get; internal set; }

        [JsonProperty("title_loc_args")]
        public string[] LocalizedTitleArgs { get; internal set; }

        internal AndroidNotification()
        {
            // Only the builder can instantiate this class
        }


        public class Builder
        {
            AndroidNotification mNotification = new AndroidNotification();


            /// <summary>
            /// The notification's title
            /// </summary>
            public Builder Title(string title)
            {
                mNotification.Title = title;
                return this;
            }

            /// <summary>
            /// The notification's body text
            /// </summary>
            public Builder Body(string body)
            {
                mNotification.Body = body;
                return this;
            }

            /// <summary>
            /// Sets the notification icon to myicon for drawable resource myicon. If you don't send this key in the request, FCM displays the launcher icon specified in your app manifest. 
            /// </summary>
            public Builder Icon(string body)
            {
                mNotification.Icon = body;
                return this;
            }

            /// <summary>
            /// The notification's icon color
            /// </summary>
            public Builder Color(Color color)
            {
                mNotification.Color = string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
                return this;
            }

            /// <summary>
            /// The sound to play when the device receives the notification. Supports "default" or the filename of a sound resource bundled in the app.
            /// </summary>
            public Builder Sound(string sound = "default")
            {
                mNotification.Sound = sound;
                return this;
            }

            /// <summary>
            /// If specified any notification with the same tag that is already being shown, will be replaced with this new one. 
            /// </summary>
            public Builder Tag(string tag)
            {
                mNotification.Tag = tag;
                return this;
            }

            /// <summary>
            /// The action associated with a user click on the notification. If specified, an activity with a matching intent filter is launched when a user clicks on the notification. 
            /// </summary>
            public Builder Action(string action)
            {
                mNotification.Action = action;
                return this;
            }

            /// <summary>
            /// Defines the key to the string resource that will be used in the notification's body and the respective arguments (if any) 
            /// </summary>
            public Builder LocalizedBody(string body, params string[] args)
            {
                mNotification.LocalizedBody = body;
                mNotification.LocalizedBodyArgs = args;
                return this;
            }

            /// <summary>
            /// Defines the key to the string resource that will be used in the notification's title and the respective arguments (if any) 
            /// </summary>
            public Builder LocalizedTitle(string title, params string[] args)
            {
                mNotification.LocalizedTitle = title;
                mNotification.LocalizedTitleArgs = args;
                return this;
            }

            public AndroidNotification Build()
            {
                return mNotification;
            }
        }
    }
}