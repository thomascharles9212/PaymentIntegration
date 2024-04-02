using PaymentIntegrations.Modals;

namespace PaymentIntegrations
{
    public interface IPaymentGateway
    {
        Task<Payment> CreatePaymentAsync(decimal amount, PaymentMethod paymentMethod, string customerId, string orderId);
        Task<Payment> CapturePaymentAsync(string requestId, string requestObject, bool sandBox);
        Task<Payment> RefundPaymentAsync(string paymentId);
        Task<Payment> GetPaymentAsync(string paymentId);
        Task<List<Payment>> GetPaymentsAsync(string customerId);
        Task<bool> AuthorizeApiAsync(bool sandbox);
    }
}