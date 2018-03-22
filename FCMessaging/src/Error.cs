using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace UTurista.FCMessaging
{
    /// <summary>
    /// The error schema for Google REST APIs. NOTE: this schema is not used for
    /// other wire protocols.
    /// </summary>
    /// 
    /// <source>
    /// https://cloud.google.com/apis/design/errors#http_mapping
    /// </source>
    public struct Error
    {
        // The actual error payload. The nested message structure is for backward
        // compatibility with Google API client libraries. It also makes the error
        // more readable to developers.
        [JsonProperty("error")]
        private Status InnerError;


        public int Code { get { return InnerError.Code; } }
        public string Message { get { return InnerError.Message; } }
        public ErrorCode Status { get { return InnerError.StatusCode; } }
        public IDictionary<string, object>[] Details { get { return InnerError.Details; } }
    }


    internal struct Status
    {
        // A simple error code that can be easily handled by the client. The
        // actual error code is defined by `google.rpc.Code`.
        [JsonProperty("code")]
        internal int Code;

        // A developer-facing human-readable error message in English. It should
        // both explain the error and offer an actionable resolution to it.
        [JsonProperty("message")]
        internal string Message;

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        internal ErrorCode StatusCode;
        // Additional error information that the client code can use to handle
        // the error, such as retry delay or a help link.
        // Each entry in the array details is a regular representation of the
        // deserialized message with an additional field `@type` which contains
        // the type URL. Example:
        //
        //     package google.profile;
        //     message Person {
        //       string first_name = 1;
        //       string last_name = 2;
        //     }
        //
        //     {
        //       "@type": "type.googleapis.com/google.profile.Person",
        //       "firstName": <string>,
        //       "lastName": <string>
        //     }
        //
        // If the embedded message type is well-known and has a custom JSON
        // representation, that representation will be embedded adding a field
        // `value` which holds the custom JSON in addition to the `@type`
        // field. Example (for message [google.protobuf.Duration][]):
        //
        //     {
        //       "@type": "type.googleapis.com/google.protobuf.Duration",
        //       "value": "1.212s"
        //     }
        [JsonProperty("details")]
        internal IDictionary<string, object>[] Details;
    }


    /// <summary>
    /// Error codes for FCM failure conditions.
    /// </summary>
    /// 
    /// <source>
    /// https://firebase.google.com/docs/reference/fcm/rest/v1/ErrorCode
    /// </source>
    public enum ErrorCode
    {
        /// <summary>
        /// No more information is available about this error.
        /// </summary>
        UNSPECIFIED_ERROR,

        /// <summary>
        /// Request parameters were invalid. An extension of type google.rpc.BadRequest
        /// is returned to specify which field was invalid.
        /// </summary>
        INVALID_ARGUMENT,

        /// <summary>
        /// App instance was unregistered from FCM. This usually means that the
        /// token used is no longer valid and a new one must be used.
        /// </summary>
        UNREGISTERED,

        /// <summary>
        /// The authenticated sender ID is different from the sender ID for the
        /// registration token.
        /// </summary>
        SENDER_ID_MISMATCH,

        /// <summary>
        /// Sending limit exceeded for the message target. An extension of type
        /// google.rpc.QuotaFailure is returned to specify which quota got exceeded.
        /// </summary>
        QUOTA_EXCEEDED,

        /// <summary>
        /// APNs certificate or auth key was invalid or missing.
        /// </summary>
        APNS_AUTH_ERROR,

        /// <summary>
        /// The server is overloaded.
        /// </summary>
        UNAVAILABLE,

        /// <summary>
        /// An unknown internal error occurred.
        /// </summary>
        INTERNAL,
    }
}
