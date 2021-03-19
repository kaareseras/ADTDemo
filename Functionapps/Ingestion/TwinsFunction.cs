using System;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using Azure.DigitalTwins.Core;
using Azure.DigitalTwins.Core.Serialization;
using Azure.Identity;
using System.Net.Http;
using Azure.Core.Pipeline;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace My.Function
{
    public class TwinsFunction
    {
        //Your Digital Twins URL is stored in an application setting in Azure Functions.
        private static readonly string adtInstanceUrl = Environment.GetEnvironmentVariable("ADT_SERVICE_URL");
        private static readonly HttpClient httpClient = new HttpClient();

        [FunctionName("TwinsFunction")]
        public async void Run([EventGridTrigger] EventGridEvent eventGridEvent, ILogger log)
        {
            //log.LogInformation("Starting function");
            //log.LogInformation(eventGridEvent.Data.ToString());
            if (adtInstanceUrl == null) log.LogError("Application setting \"ADT_SERVICE_URL\" not set");
            try
            {
                //Authenticate with Digital Twins.
                //log.LogInformation("Starting ManagedIdentityCredential");
                ManagedIdentityCredential cred = new ManagedIdentityCredential("https://digitaltwins.azure.net");
                //log.LogInformation("Starting DigitalTwinsClient to: " + adtInstanceUrl.ToString());
                DigitalTwinsClient client = new DigitalTwinsClient(new Uri(adtInstanceUrl), cred, new DigitalTwinsClientOptions { Transport = new HttpClientTransport(httpClient) });
                log.LogInformation($"Azure digital twins service client connection created.");
                if (eventGridEvent != null && eventGridEvent.Data != null)
                {
                    
                    
                    //log.LogInformation(eventGridEvent.Data.ToString());
                    // Read deviceId and temperature for IoT Hub JSON.
                    
                    

                    JObject deviceMessage = (JObject)JsonConvert.DeserializeObject(eventGridEvent.Data.ToString());

                    String body = Base64StringDecode(deviceMessage["body"].ToString());

                    JObject deviceMessageBody = (JObject)JsonConvert.DeserializeObject(body);

                    //log.LogInformation(body);

                    string deviceId = (string)deviceMessage["systemProperties"]["iothub-connection-device-id"];
                    var temperature = deviceMessageBody["Temperature"];
                    log.LogInformation($"Device:{deviceId} Temperature is:{temperature}");

                    //Update twin by using device temperature.
                    var patch = new Azure.JsonPatchDocument();
                    patch.AppendReplace<double>("/Temperature", temperature.Value<double>()); 

                    await client.UpdateDigitalTwinAsync(deviceId, patch); 
                }
            }
            catch (Exception e)
            {
                log.LogError(e.Message);
            }

        }    
        
        public string Base64StringDecode(string encodedString)
        {
            var bytes = Convert.FromBase64String(encodedString);

            var decodedString = Encoding.UTF8.GetString(bytes);

            return decodedString;
        }

        public string Base64StringEncode(string originalString)
        {
            var bytes = Encoding.UTF8.GetBytes(originalString);

            var encodedString = Convert.ToBase64String(bytes);

            return encodedString;
        }
    }


}