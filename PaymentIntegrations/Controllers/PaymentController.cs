using Microsoft.AspNetCore.Mvc;
using PaymentIntegrations.Modals;
using PaymentIntegrations.PaymentFactory;

namespace PaymentIntegrations.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }
        [HttpPost(Name = "CapturePayment")]
        public Task<Payment> CapturePaymentAsync(string requestId, string requestObject, string token, string paymentMethod)
        {
            var factory = new PaymentGatewayFactory();
            IPaymentGateway paymentGateway = factory.GetPaymentGateway(paymentMethod);
            /*parse token for sandbox and live*/
            bool sandBox = false;
            return paymentGateway.CapturePaymentAsync(requestId, requestObject, sandBox);
        }
    }
}
