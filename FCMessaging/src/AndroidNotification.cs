using Newtonsoft.Json;

namespace UTurista.FCMessaging
{

    public class AndroidNotification
    {
        [JsonProperty("title")]
        public string Title { get; }

        [JsonProperty("body")]
        public string Body { get;  }

        [JsonProperty("icon")]
        public string Icon { get; }

        [JsonProperty("color")]
        public string Color { get; }

        [JsonProperty("sound")]
        public string Sound { get;  }

        [JsonProperty("tag")]
        public string Tag { get;}

        [JsonProperty("click_action")]
        public string Action { get; }

        [JsonProperty("body_loc_key")]
        public string LocalizedBody { get; }

        [JsonProperty("body_loc_args")]
        public string[] LocalizedBodyArgs { get; }

        [JsonProperty("title_loc_key")]
        public string LocalizedTitle { get;  }

        [JsonProperty("title_loc_args")]
        public string[] LocalizedTitleArgs { get;  }

        public AndroidNotification(Builder builder)
        {
            Title = builder.mTitle;
            Body = builder.mBody;
            Icon = builder.mIcon;
            Color = builder.mColor;
            Sound = builder.mSound;
            Tag = builder.mTag;
            Action = builder.mAction;
            LocalizedBody = builder.mLocalizedBody;
            LocalizedBodyArgs = builder.mLocalizedBodyArgs;
            LocalizedTitle = builder.mLocalizedTitle;
            LocalizedTitleArgs = builder.mLocalizedTitleArgs;
        }


        public class Builder
        {
            internal string mTitle;
            internal string mBody;
            internal string mIcon;
            internal string mColor;
            internal string mSound;
            internal string mTag;
            internal string mAction;
            internal string mLocalizedBody;
            internal string[] mLocalizedBodyArgs;
            internal string mLocalizedTitle;
            internal string[] mLocalizedTitleArgs;


            /// <summary>
            /// The notification's title
            /// </summary>
            public Builder Title(string title)
            {
                mTitle = title;
                return this;
            }

            /// <summary>
            /// The notification's body text
            /// </summary>
            public Builder Body(string body)
            {
                mBody = body;
                return this;
            }

            /// <summary>
            /// Sets the notification icon to myicon for drawable resource myicon. If you don't send this key in the request, FCM displays the launcher icon specified in your app manifest. 
            /// </summary>
            public Builder Icon(string body)
            {
                mIcon = body;
                return this;
            }

            /// <summary>
            /// The notification's icon color
            /// </summary>
            public Builder Color(byte red, byte green, byte blue)
            {
                mColor = string.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue);
                return this;
            }

            /// <summary>
            /// The sound to play when the device receives the notification. Supports "default" or the filename of a sound resource bundled in the app.
            /// </summary>
            public Builder Sound(string sound = "default")
            {
                mSound = sound;
                return this;
            }

            /// <summary>
            /// If specified any notification with the same tag that is already being shown, will be replaced with this new one. 
            /// </summary>
            public Builder Tag(string tag)
            {
                mTag = tag;
                return this;
            }

            /// <summary>
            /// The action associated with a user click on the notification. If specified, an activity with a matching intent filter is launched when a user clicks on the notification. 
            /// </summary>
            public Builder Action(string action)
            {
                mAction = action;
                return this;
            }

            /// <summary>
            /// Defines the key to the string resource that will be used in the notification's body and the respective arguments (if any) 
            /// </summary>
            public Builder LocalizedBody(string body, params string[] args)
            {
                mLocalizedBody = body;
                mLocalizedBodyArgs = args;
                return this;
            }

            /// <summary>
            /// Defines the key to the string resource that will be used in the notification's title and the respective arguments (if any) 
            /// </summary>
            public Builder LocalizedTitle(string title, params string[] args)
            {
                mLocalizedTitle = title;
                mLocalizedTitleArgs = args;
                return this;
            }

            public AndroidNotification Build()
            {
                return new AndroidNotification(this);
            }
        }
    }
}