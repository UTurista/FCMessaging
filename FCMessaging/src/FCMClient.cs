using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UTurista.FCMessaging
{
    public class FCMClient
    {
        private readonly Logger LOG = LogManager.GetCurrentClassLogger();

        private static readonly string FCM_URI = "https://fcm.googleapis.com/v1/projects/{0}/messages:send";
        private static readonly IEnumerable<string> SCOPES = new List<string>(new string[] { "https://www.googleapis.com/auth/firebase.messaging" });

        private readonly Uri mFirebaseEndpoint;
        private readonly string mCredentialsFile;


        public FCMClient(string file = "service-account.json")
        {
            string projectId = GetProjectId(file);
            mFirebaseEndpoint = new Uri(string.Format(FCM_URI, projectId));
            mCredentialsFile = file;

            LOG.Debug("Created FCMClient({0})", mFirebaseEndpoint);
        }

        public async Task<string> Send(Message message, bool dryrun = false)
        {
            // Prepare the request
            RequestPayload payload = new RequestPayload()
            {
                Message = message,
                DryRun = dryrun
            };


            // Serialize the request
            string serializedMessage = JsonConvert.SerializeObject(payload, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });
            LOG.Trace("Request: {0}", serializedMessage);

            // Prepare the request
            var token = await GetAccessToken(mCredentialsFile);
            LOG.Trace("Token: {0} Endpoint: {1}", token, mFirebaseEndpoint);

            using (var request = new HttpRequestMessage(HttpMethod.Post, mFirebaseEndpoint))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                request.Content = new StringContent(serializedMessage, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var result = await client.SendAsync(request);

                    if (result.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        var errorMessage = await result.Content.ReadAsStringAsync();
                        Error error = JsonConvert.DeserializeObject<Error>(errorMessage);

                        throw new FcmException(error);
                    }

                    // As per documentation: "If successful, the response body contains an instance of Message"
                    var content = await result.Content.ReadAsStringAsync();
                    LOG.Trace("Response: {0}", content);
                    Message responseMessage = JsonConvert.DeserializeObject<Message>(content);

                    // But (currently) only the 'Name' property is outputed so we cheat a bit
                    return responseMessage.Name;
                }
            }
        }

        private async static Task<string> GetAccessToken(string file)
        {
            GoogleCredential googleCredential = GoogleCredential
                .FromFile(file)
                .CreateScoped(SCOPES);

            string token = await googleCredential.UnderlyingCredential.GetAccessTokenForRequestAsync();
            return token;
        }

        private static string GetProjectId(string file)
        {
            using (StreamReader stream = File.OpenText(file))
            {
                Credential credentialParameters;
                try
                {
                    JsonSerializer serializer = new JsonSerializer();
                    credentialParameters = (Credential)serializer.Deserialize(stream, typeof(Credential));
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException("Error deserializing JSON credential data.", e);
                }
                return credentialParameters.ProjectId;
            }
        }


        private class RequestPayload
        {
            [JsonProperty("validate_only")]
            public bool DryRun { get; set; }

            [JsonProperty("message")]
            public Message Message { get; set; }
        }

        private class Credential : JsonCredentialParameters
        {
            [JsonProperty("project_id")]
            public string ProjectId { get; set; }
        }
    }
}
