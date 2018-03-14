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
        public string CollapsedKey { get; }

        [JsonProperty("priority")]
        public string Priority { get; }

        [JsonProperty("ttl")]
        public string TimeToLive { get; }

        [JsonProperty("restricted_package_name")]
        public string PackageName { get; }

        [JsonProperty("data")]
        public Dictionary<string, string> Data { get; }

        [JsonProperty("notification")]
        public AndroidNotification Notification { get; }

        public AndroidConfig(Builder builder)
        {
            CollapsedKey = builder.mCollapseKey;
            Priority = builder.mPriority;
            PackageName = builder.mPackage;
            Notification = builder.mNotification;

            if (builder.mData.Count > 0)
            {
                Data = builder.mData;
            }

            if (builder.mTTL >= 0)
            {
                TimeToLive = String.Format("{0}s", builder.mTTL);
            }
        }

        public class Builder
        {
            internal string mCollapseKey;
            internal string mPriority;
            internal double mTTL = -1;
            internal string mPackage;
            internal Dictionary<string, string> mData = new Dictionary<string, string>();
            internal AndroidNotification mNotification;

            /// <summary>
            /// An identifier of a group of messages that can be collapsed, so that only the last message gets sent when delivery can be resumed
            /// </summary>
            public Builder CollapsedKey(string key)
            {
                mCollapseKey = key;
                return this;
            }

            public Builder Priority(AndroidMessagePriority priority)
            {
                mPriority = priority.ToString().ToLowerInvariant(); ;
                return this;
            }

            /// <summary>
            /// How long the message should be kept in FCM storage if the device is offline.
            /// </summary>
            public Builder TimeToLive(TimeSpan ttl)
            {
                mTTL = ttl.TotalSeconds;
                return this;
            }

            /// <summary>
            /// Package name of the application where the registration tokens must match in order to receive the message. 
            /// </summary>
            public Builder Package(string package)
            {
                mPackage = package;
                return this;
            }

            /// <summary>
            /// Arbitrary key/value payload. If present, it will override google.firebase.fcm.v1.Message.data.
            /// </summary>
            public Builder AddData(string key, string value)
            {
                mData.Add(key, value);
                return this;
            }

            /// <summary>
            /// Notification to send to android devices. 
            /// </summary>
            public Builder Notification(AndroidNotification notification)
            {
                mNotification = notification;
                return this;
            }


            public AndroidConfig Build()
            {
                return new AndroidConfig(this);
            }
        }
    }
}
