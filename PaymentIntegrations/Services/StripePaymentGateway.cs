using PaymentIntegrations.Modals;

namespace PaymentIntegrations.Services
{
    public class StripePaymentGateway : IPaymentGateway
    {
        public Task<bool> AuthorizeApiAsync(bool sandbox)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> CapturePaymentAsync(string requestId, string requestObject, bool sandBox)
        {
            throw new NotImplementedException();
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
