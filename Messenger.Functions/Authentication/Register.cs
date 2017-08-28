using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Net;
using System.Net.Http;

namespace Messenger.Functions.Authentication
{
    public static class Register
    {
        [FunctionName("Register")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "HttpTriggerCSharp/authentication/register")]HttpRequestMessage req, string emailAddress, string password, TraceWriter log)
        {
            try
            {
                log.Info($"Authentication/Register?emailAddress={emailAddress}&password=<obfuscated>");

                return req.CreateResponse(HttpStatusCode.OK, true);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex, $"Authentication/Register?emailAddress={emailAddress}&password=<obfuscated>");

                return req.CreateResponse(HttpStatusCode.OK, false);
            }
        }
    }
}