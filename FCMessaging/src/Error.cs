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
    /// All of the gRPC error codes defined in google.rpc.Code
    /// </summary>
    /// 
    /// <source>
    /// https://cloud.google.com/apis/design/errors#error_codes
    /// </source>
    public enum ErrorCode
    {
        /// <summary>
        /// No error.
        /// </summary>
        OK = 200,

        /// <summary>
        /// Client specified an invalid argument. Check error message and error details for more information.
        /// </summary>
        INVALID_ARGUMENT = 400,

        /// <summary>
        /// Request can not be executed in the current system state, such as deleting a non-empty directory.
        /// </summary>
        FAILED_PRECONDITION = 400,

        /// <summary>
        /// Client specified an invalid range.
        /// </summary>
        OUT_OF_RANGE = 400,

        /// <summary>
        /// Request not authenticated due to missing, invalid, or expired OAuth token.
        /// </summary>
        UNAUTHENTICATED = 401,

        /// <summary>
        /// Client does not have sufficient permission. This can happen because the OAuth token does not have the right scopes, the client doesn't have permission, or the API has not been enabled for the client project.
        /// </summary>
        PERMISSION_DENIED = 403,

        /// <summary>
        /// A specified resource is not found, or the request is rejected by undisclosed reasons, such as whitelisting.
        /// </summary>
        NOT_FOUND = 404,

        /// <summary>
        /// Concurrency conflict, such as read-modify-write conflict.
        /// </summary>
        ABORTED = 409,

        /// <summary>
        /// The resource that a client tried to create already exists.
        /// </summary>
        ALREADY_EXISTS = 409,

        /// <summary>
        /// Either out of resource quota or reaching rate limiting. The client should look for google.rpc.QuotaFailure error detail for more information.
        /// </summary>
        RESOURCE_EXHAUSTED = 429,

        /// <summary>
        /// Request cancelled by the client.
        /// </summary>
        CANCELLED = 499,

        /// <summary>
        /// Unrecoverable data loss or data corruption. The client should report the error to the user.
        /// </summary>
        DATA_LOSS = 500,

        /// <summary>
        /// Unknown server error. Typically a server bug.
        /// </summary>
        UNKNOWN = 500,

        /// <summary>
        /// Internal server error. Typically a server bug.
        /// </summary>
        INTERNAL = 500,

        /// <summary>
        /// API method not implemented by the server.
        /// </summary>
        NOT_IMPLEMENTED = 501,

        /// <summary>
        /// Service unavailable. Typically the server is down.
        /// </summary>
        UNAVAILABLE = 503,

        /// <summary>
        /// Request deadline exceeded. This will happen only if the caller sets a deadline that is shorter than the method's default deadline (i.e. requested deadline is not enough for the server to process the request) and the request did not finish within the deadline.
        /// </summary>
        DEADLINE_EXCEEDED = 504
    }


    /// <summary>
    /// Error codes for FCM failure conditions.
    /// </summary>
    /// 
    /// <source>
    /// https://firebase.google.com/docs/reference/fcm/rest/v1/ErrorCode
    /// </source>
    public enum FcmErrorCode
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
