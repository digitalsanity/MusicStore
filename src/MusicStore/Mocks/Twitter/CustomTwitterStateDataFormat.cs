﻿using Microsoft.AspNet.Security;
using Microsoft.AspNet.Security.Twitter.Messages;
using Newtonsoft.Json;

namespace MusicStore.Mocks.Twitter
{
    /// <summary>
    /// Summary description for CustomTwitterStateDataFormat
    /// </summary>
    public class CustomTwitterStateDataFormat : ISecureDataFormat<RequestToken>
    {
        private static string lastSavedRequestToken;

        public string Protect(RequestToken data)
        {
            data.Token = "valid_oauth_token";
            lastSavedRequestToken = Serialize(data);
            return "valid_oauth_token";
        }

        public RequestToken Unprotect(string state)
        {
            return state == "valid_oauth_token" ? DeSerialize(lastSavedRequestToken) : null;
        }

        private string Serialize(RequestToken data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        private RequestToken DeSerialize(string state)
        {
            return JsonConvert.DeserializeObject<RequestToken>(state);
        }
    }
}