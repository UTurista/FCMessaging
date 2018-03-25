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
        public string Name { get; internal set; }

        [JsonProperty("data")]
        public Dictionary<string, string> Data { get; internal set; }

        [JsonProperty("notification")]
        public Notification Notification { get; internal set; }

        [JsonProperty("android")]
        public AndroidConfig Android { get; internal set; }

        [JsonProperty("webpush")]
        public WebpushConfig Web { get; internal set; }

        [JsonProperty("apns")]
        public ApnsConfig Ios { get; internal set; }

        [JsonProperty("token")]
        public string Token { get; internal set; }

        [JsonProperty("topic")]
        public string Topic { get; internal set; }

        [JsonProperty("condition")]
        public string Condition { get; internal set; }


        [JsonConstructor]
        private Message(string name)
        {
            // Name is the only property sent by the server so will just ignore the others
            Name = name;
        }

        internal Message()
        {
            // Only the builder can instantiate this class
        }


        public class Builder
        {
            private static readonly Regex TOPIC_REGEX = new Regex("^[a-zA-Z0-9-_.~%/]+$");

            private Message mMessage = new Message();


            public Builder AddData(string key, string value)
            {
                if (mMessage.Data == null)
                {
                    mMessage.Data = new Dictionary<string, string>();
                }
                mMessage.Data.Add(key, value);
                return this;
            }


            public Builder SetData(Dictionary<string, string> data)
            {
                mMessage.Data = data;
                return this;
            }


            public Builder Title(string title)
            {
                if (mMessage.Notification == null)
                {
                    mMessage.Notification = new Notification(title, null);
                }
                else
                {
                    mMessage.Notification = new Notification(title, mMessage.Notification.Body);
                }


                return this;
            }


            public Builder Body(string body)
            {
                if (mMessage.Notification == null)
                {
                    mMessage.Notification = new Notification(null, body);
                }
                else
                {
                    mMessage.Notification = new Notification(mMessage.Notification.Title, body);
                }

                return this;
            }


            public Builder AndroidCfg(AndroidConfig config)
            {
                mMessage.Android = config;
                return this;
            }


            public Builder IosCfg(ApnsConfig config)
            {
                mMessage.Ios = config;
                return this;
            }


            public Builder WebCfg(WebpushConfig config)
            {
                mMessage.Web = config;
                return this;
            }


            public Builder ToDevice(string token)
            {
                mMessage.Token = token;

                return this;
            }


            public Builder ToTopic(string topic)
            {
                if (!IsTopicValid(topic))
                    throw new Exception("Topic must match " + TOPIC_REGEX);

                mMessage.Topic = topic;

                return this;
            }


            public Builder ToTopic(params string[] topics)
            {
                if (topics == null)
                {
                    mMessage.Condition = null;
                    return this;
                }

                if (topics.Any(x => !IsTopicValid(x)))
                    throw new Exception("Topics must match " + TOPIC_REGEX);

                topics = topics.Select(top => string.Format("'{0}' in topics", top)).ToArray();
                mMessage.Condition = string.Join(" && ", topics);

                return this;
            }

            public Builder ToCondition(string condition)
            {
                mMessage.Condition = condition;

                return this;
            }


            public Message Build()
            {
                // Assert that there is only one target defined
                if (new string[] { mMessage.Token, mMessage.Topic, mMessage.Condition }.Where(x => !string.IsNullOrEmpty(x)).Count() != 1)
                {
                    throw new Exception("Exactly one of token, topic or condition must be specified");
                }


                return mMessage;
            }


            private static bool IsTopicValid(string topic)
            {
                return TOPIC_REGEX.Match(topic).Success;
            }
        }
    }
}
