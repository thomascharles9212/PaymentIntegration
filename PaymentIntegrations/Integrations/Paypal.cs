using Newtonsoft.Json;
using PaymentIntegrations.Modals;
using PaymentIntegrations.Modals.Paypal;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PaymentIntegrations.Integrations
{
    public class Paypal
    {
        string sandboxApiUrl = "https://api-m.sandbox.paypal.com/v2/payments/authorizations/0VF52814937998046/capture";
        string sandboxAuthToken = "A21AAFs9YK9gWL6Vl6AqeoPtm-nf6JmtPOwAc8kfzHVdeigPEhrOJLCvbeIt3fJ4NKvyZo_iWic7sC3RIQrVUdu7igagcuMVQ";
        string ApiUrl = "https://api-m.sandbox.paypal.com/v2/payments/authorizations/0VF52814937998046/capture";
        string AuthToken = "A21AAFs9YK9gWL6Vl6AqeoPtm-nf6JmtPOwAc8kfzHVdeigPEhrOJLCvbeIt3fJ4NKvyZo_iWic7sC3RIQrVUdu7igagcuMVQ";


        public async Task<bool> AuthorizeApiAsync(bool sandbox)
        {
            bool authorized = false;
            try
            {
                string apiUrl = sandbox ? sandboxApiUrl : ApiUrl;
                string authToken = sandbox ? sandboxAuthToken : AuthToken;

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");
                client.DefaultRequestHeaders.Add("Content-Type", "application/json");

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    authorized = true;
                }
            }
            catch (Exception ex)
            {

            }
            return authorized;
        }

        public async Task<CapturedRoot> CapturePaymentAsync(string requestId, string requestObject, bool sandbox)
        {
            CapturedRoot result = new CapturedRoot();
            try
            {
                string apiUrl = sandbox ? sandboxApiUrl : ApiUrl;
                string authToken = sandbox ? sandboxAuthToken : AuthToken;

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");
                client.DefaultRequestHeaders.Add("PayPal-Request-Id", requestId);
                client.DefaultRequestHeaders.Add("Content-Type", "application/json");


                HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(requestObject, Encoding.UTF8, "application/json"));

                result = JsonConvert.DeserializeObject<CapturedRoot>(response.Content.ToString());
            }
            catch(Exception ex)
            {

            }
            return result;
        }
    }
}
