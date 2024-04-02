using Newtonsoft.Json;
using PaymentIntegrations.Integrations;
using PaymentIntegrations.Modals;
using PaymentIntegrations.Modals.Paypal;
using PaymentIntegrations.PaymentFactory;

namespace PaymentIntegrations.Services
{
    public class PayPalPaymentGateway : IPaymentGateway
    {
        private readonly Paypal paypal;
        public PayPalPaymentGateway()
        {
            paypal = new Paypal();
        }
        public async Task<bool> AuthorizeApiAsync(bool sandbox)
        {
            return await paypal.AuthorizeApiAsync(sandbox);
        }

        public async Task<Payment> CapturePaymentAsync(string requestId, string requestObject, bool sandBox)
        {
            try
            {
                if (await AuthorizeApiAsync(sandBox))
                {
                    var captureResponse = await paypal.CapturePaymentAsync(requestId, requestObject, sandBox);
                    if (captureResponse?.status?.Equals("Completed", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        return new Payment { Status = PaymentStatus.Captured };
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
            }

            return new Payment();
        }

        public Task<Payment> CreatePaymentAsync(decimal amount, PaymentMethod paymentMethod, string customerId, string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetPaymentAsync(string paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Payment>> GetPaymentsAsync(string customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> RefundPaymentAsync(string paymentId)
        {
            throw new NotImplementedException();
        }
    }
}
