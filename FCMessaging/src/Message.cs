using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace UTurista.FCMessaging
{
    public class Message
    {
        [JsonProperty("name")]
        public string Name { get; }

        [JsonProperty("data")]
        public Dictionary<string, string> Data { get; }

        [JsonProperty("notification")]
        public Notification Notification { get; }

        [JsonProperty("android")]
        public AndroidConfig Android { get;}

        [JsonProperty("webpush")]
        public WebpushConfig Web { get; }

        [JsonProperty("apns")]
        public ApnsConfig Ios { get; }

        [JsonProperty("token")]
        public string Token { get;  }

        [JsonProperty("topic")]
        public string Topic { get;  }

        [JsonProperty("condition")]
        public string Condition { get; }


        [JsonConstructor]
        private Message(string name)
        {
            // Name is the only property sent by the server so will just ignore the others
            Name = name;
        }

        public Message(Builder builder)
        {
            Notification = builder.mNotification;
            Android = builder.mAndroid;
            Web = builder.mWeb;
            Ios = builder.mIos;

            // Assert that there is only one target defined
            if (new string[] { builder.mToken, builder.mTopic, builder.mCondition }.Where(x => !string.IsNullOrEmpty(x)).Count() != 1)
            {
                throw new Exception("Exactly one of token, topic or condition must be specified");
            }

            Token = builder.mToken;
            Topic = builder.mTopic;
            Condition = builder.mCondition;


            if (builder.mData.Count > 0)
            {
                Data = builder.mData;
            }
        }


        public class Builder
        {
            private static readonly Regex TOPIC_REGEX = new Regex("^[a-zA-Z0-9-_.~%/]+$");

            internal Dictionary<string, string> mData = new Dictionary<string, string>();
            internal Notification mNotification;
            internal AndroidConfig mAndroid;
            internal WebpushConfig mWeb;
            internal ApnsConfig mIos;
            internal string mToken;
            internal string mTopic;
            internal string mCondition;


            public Builder AddData(string key, string value)
            {
                mData.Add(key, value);
                return this;
            }


            public Builder SetData(Dictionary<string, string> data)
            {
                mData = data;
                return this;
            }


            public Builder Title(string title)
            {
                if (mNotification == null)
                {
                    mNotification = new Notification(title, null);
                }
                else
                {
                    mNotification = new Notification(title, mNotification.Body);
                }


                return this;
            }


            public Builder Body(string body)
            {
                if (mNotification == null)
                {
                    mNotification = new Notification(null, body);
                }
                else
                {
                    mNotification = new Notification(mNotification.Title, body);
                }

                return this;
            }


            public Builder AndroidCfg(AndroidConfig config)
            {
                mAndroid = config;
                return this;
            }


            public Builder IosCfg(ApnsConfig config)
            {
                mIos = config;
                return this;
            }


            public Builder WebCfg(WebpushConfig config)
            {
                mWeb = config;
                return this;
            }


            public Builder ToDevice(string token)
            {
                mToken = token;

                return this;
            }


            public Builder ToTopic(string topic)
            {
                if (!IsTopicValid(topic))
                    throw new Exception("Topic must match " + TOPIC_REGEX);

                mTopic = topic;

                return this;
            }


            public Builder ToTopic(params string[] topics)
            {
                if (topics == null)
                {
                    mCondition = null;
                    return this;
                }

                if (topics.Any(x => !IsTopicValid(x)))
                    throw new Exception("Topics must match " + TOPIC_REGEX);

                topics = topics.Select(top => string.Format("'{0}' in topics", top)).ToArray();
                mCondition = String.Join(" && ", topics);

                return this;
            }

            public Builder ToCondition(string condition)
            {
                mCondition = condition;

                return this;
            }


            public Message Build()
            {
                return new Message(this);
            }


            private static bool IsTopicValid(string topic)
            {
                return TOPIC_REGEX.Match(topic).Success;
            }
        }
    }
}
