using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UTurista.FCMessaging
{

    public enum AndroidMessagePriority
    {
        NORMAL,
        HIGH
    }

    /// <summary>
    /// Represents the Android-specific options that can be included in a {#Message}.
    /// Instances of this class are thread-safe and immutable.
    /// </summary>
    public class AndroidConfig
    {
        [JsonProperty("collapse_key")]
        public string CollapsedKey { get; internal set; }

        [JsonProperty("priority")]
        public string Priority { get; internal set; }

        [JsonProperty("ttl")]
        public string TimeToLive { get; internal set; }

        [JsonProperty("restricted_package_name")]
        public string PackageName { get; internal set; }

        [JsonProperty("data")]
        public Dictionary<string, string> Data { get; internal set; }

        [JsonProperty("notification")]
        public AndroidNotification Notification { get; internal set; }

        internal AndroidConfig()
        {
            // Only the builder can instantiate this class
        }

        public class Builder
        {
           private AndroidConfig mConfig = new AndroidConfig();

            /// <summary>
            /// An identifier of a group of messages that can be collapsed, so that only the last message gets sent when delivery can be resumed
            /// </summary>
            public Builder CollapsedKey(string key)
            {
                mConfig.CollapsedKey = key;
                return this;
            }

            public Builder Priority(AndroidMessagePriority priority)
            {
                mConfig.Priority = priority.ToString().ToLowerInvariant(); ;
                return this;
            }

            /// <summary>
            /// How long the message should be kept in FCM storage if the device is offline.
            /// </summary>
            public Builder TimeToLive(TimeSpan ttl)
            {
                mConfig.TimeToLive = String.Format("{0}s", ttl.TotalSeconds);
                return this;
            }

            /// <summary>
            /// Package name of the application where the registration tokens must match in order to receive the message. 
            /// </summary>
            public Builder Package(string package)
            {
                mConfig.PackageName = package;
                return this;
            }

            /// <summary>
            /// Arbitrary key/value payload. If present, it will override google.firebase.fcm.v1.Message.data.
            /// </summary>
            public Builder AddData(string key, string value)
            {
                if (mConfig.Data == null)
                {
                    mConfig.Data = new Dictionary<string, string>();
                }

                mConfig.Data.Add(key, value);
                return this;
            }

            /// <summary>
            /// Notification to send to android devices. 
            /// </summary>
            public Builder Notification(AndroidNotification notification)
            {
                mConfig.Notification = notification;
                return this;
            }


            public AndroidConfig Build()
            {
                return mConfig;
            }
        }
    }
}
